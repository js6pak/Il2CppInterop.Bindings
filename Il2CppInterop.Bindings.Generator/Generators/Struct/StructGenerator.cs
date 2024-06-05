using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

public abstract class StructGenerator
{
    private const string BaseNamespace = "Il2CppInterop.Bindings.Structs";

    public abstract string StructName { get; }
    public string HandlerName => $"Native{StructName}StructHandler";
    public string HandlerInterfaceName => "I" + HandlerName;

    public CSharpNamespace Namespace => new(BaseNamespace + $".VersionSpecific.{StructName}Handlers");

    public Dictionary<UnityVersion, Il2CppVersion.Struct> Versions { get; } = new();

    public abstract Field[] Fields { get; }

    private CSharpFile Generate(UnityVersion unityVersion, Il2CppVersion.Struct @struct)
    {
        var structName = StructName + "_" + unityVersion.ToSanitizedString();

        var csharpStruct = new CSharpStruct(Visibility.Private, structName);

        var anonCount = 0;
        var bitFieldCount = -1;
        foreach (var field in @struct.Fields)
        {
            var type = field.Type;

            // Special handling for const size array
            if (type.EndsWith("[0]"))
            {
                type = type[..^3] + "*";
                csharpStruct.Add(new CSharpProperty(type, field.Name)
                {
                    Getter = new CSharpProperty.Accessor
                    {
                        Body = writer => writer.Write($"({type})(({structName}*)Unsafe.AsPointer(ref this) + sizeof({structName}));"),
                    },
                });

                continue;
            }

            if (field is Il2CppVersion.Struct.BitField bitField)
            {
                var offset = bitField.Start;

                if (offset == 0) bitFieldCount++;

                var bitFieldName = $"__bitfield_{bitFieldCount}";

                if (offset == 0)
                {
                    csharpStruct.Add(new CSharpBlankLine());
                    csharpStruct.Add(new CSharpField(type, bitFieldName));
                }

                var bitMask = (1 << bitField.Width) - 1;
                var bitMaskText = "0b" + Convert.ToString(bitMask, 2);

                csharpStruct.Add(new CSharpProperty(type, field.Name)
                {
                    Getter = new CSharpProperty.Accessor
                    {
                        Body = writer => writer.Write($"({type})(({bitFieldName} >> {offset}) & {bitMaskText});"),
                    },
                    Setter = new CSharpProperty.Accessor
                    {
                        BodyType = BodyType.Block,
                        Body = writer =>
                        {
                            writer.WriteLine($"var shiftedValue = (value & {bitMaskText}) << {offset};");
                            writer.WriteLine($"var otherBits = {bitFieldName} & ~({bitMaskText} << {offset});");
                            writer.WriteLine($"{bitFieldName} = ({type})(otherBits | shiftedValue);");
                        },
                    },
                });
            }
            else
            {
                csharpStruct.Add(new CSharpField(Visibility.Public, type, string.IsNullOrEmpty(field.Name) ? $"anon{anonCount++}" : field.Name));
            }
        }

        var @class = new CSharpClass(Visibility.Internal, HandlerName + "_" + unityVersion.ToSanitizedString())
        {
            IsUnsafe = true,
            Extends = { HandlerInterfaceName },
            Members =
            {
                new CSharpProperty("int", "Size")
                {
                    Getter = new CSharpProperty.Accessor
                    {
                        Body = writer => writer.Write($"sizeof({structName});"),
                    },
                },
                csharpStruct,
            },
        };

        foreach (var field in Fields)
        {
            var structField = @struct.Fields.SingleOrDefault(f => field.NativeFieldNames.Contains(f.Name));
            if (structField == null) throw new Exception($"Failed to find {field.Name} in {unityVersion}");
            @class.Members.AddRange(field.GetMethods(this, new FieldContext(structName, unityVersion, CodeWriter.SanitizeIdentifier(structField.Name))));
        }

        return new CSharpFile(Namespace)
        {
            Header = writer =>
            {
                // Disable "is never assigned to" warning
                writer.WriteLine("#pragma warning disable CS0649");
                writer.WriteLine();
            },
            Usings = { "System.Runtime.CompilerServices", "System.Runtime.InteropServices" },
            Members =
            {
                @class,
            },
        };
    }

    private CSharpFile GenerateInterface()
    {
        var @interface = new CSharpInterface(HandlerInterfaceName)
        {
            Extends = { "INativeStructHandler" },
            IsUnsafe = true,
        };

        foreach (var field in Fields)
        {
            @interface.Members.AddRange(field.GetMethods(this, null));
        }

        return new CSharpFile(Namespace)
        {
            Members = { @interface },
        };
    }

    private CSharpFile GenerateAccessor()
    {
        var @struct = new CSharpStruct(StructName)
        {
            IsUnsafe = true,
            IsPartial = true,
            Attributes =
            {
                new CSharpAttribute("NativeStruct"),
            },
            Members =
            {
                new CSharpProperty("int", "Size")
                {
                    IsStatic = true,
                    Getter = new CSharpProperty.Accessor
                    {
                        Body = writer => writer.Write($"UnityVersionHandler.{StructName}.Size;"),
                    },
                },
                new CSharpBlankLine(),
            },
        };

        var first = true;
        foreach (var field in Fields)
        {
            if (first) first = false;
            else @struct.Add(new CSharpBlankLine());

            @struct.Members.AddRange(field.GetProperties(this));
        }

        return new CSharpFile(BaseNamespace)
        {
            Usings = { "Il2CppInterop.Bindings.Utilities", },
            Members =
            {
                @struct,
            },
        };
    }

    public void Generate(string outputPath)
    {
        GenerateAccessor().WriteTo(Path.Join(outputPath, "Structs", $"{StructName}.generated.cs"));

        var basePath = Path.Combine(outputPath, "Structs", "VersionSpecific", StructName);

        GenerateInterface().WriteTo(Path.Combine(basePath, HandlerInterfaceName + ".generated.cs"));

        foreach (var (unityVersion, @struct) in Versions)
        {
            Generate(unityVersion, @struct).WriteTo(Path.Join(basePath, $"{StructName}.{unityVersion.ToSanitizedString()}.generated.cs"));
        }
    }

    public record FieldContext(string StructName, UnityVersion UnityVersion, string FieldName)
    {
        public string StoreCast { get; } = $"var _ = ({StructName}*)o;";
    }

    public abstract record Field(string Name, string[] NativeFieldNames)
    {
        public bool IsReadOnly { get; set; }
        public abstract string Type { get; }

        public virtual IEnumerable<CSharpProperty> GetProperties(StructGenerator structGenerator)
        {
            yield return new CSharpProperty(Type, Name)
            {
                Getter = new CSharpProperty.Accessor { Body = writer => writer.Write($"UnityVersionHandler.{structGenerator.StructName}.Get{Name}(Pointer);") },
                Setter = IsReadOnly ? null : new CSharpProperty.Accessor { Body = writer => writer.Write($"UnityVersionHandler.{structGenerator.StructName}.Set{Name}(Pointer, value);") },
            };
        }

        public virtual IEnumerable<CSharpMethod> GetMethods(StructGenerator structGenerator, FieldContext? context)
        {
            var structParameter = new CSharpParameter(structGenerator.StructName + "*", "o");

            yield return new CSharpMethod(Type, "Get" + Name)
            {
                Parameters = { structParameter },
                Body = context == null
                    ? null
                    : writer =>
                    {
                        writer.WriteLine(context.StoreCast);
                        WriteGetterBody(writer, context);
                    },
            };

            if (!IsReadOnly)
            {
                yield return new CSharpMethod("void", "Set" + Name)
                {
                    Parameters = { structParameter, new CSharpParameter(Type, "value") },
                    Body = context == null
                        ? null
                        : writer =>
                        {
                            writer.WriteLine(context.StoreCast);
                            WriteSetterBody(writer, context);
                        },
                };
            }
        }

        protected virtual void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"return _->{context.FieldName};");
        }

        protected virtual void WriteSetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"_->{context.FieldName} = value;");
        }
    }

    public record NormalField(string Type, string Name, string[] NativeFieldNames) : Field(Name, NativeFieldNames)
    {
        public override string Type { get; } = Type;
    }

    public record PointerField(string Type, string Name, string[] NativeFieldNames) : Field(Name, NativeFieldNames)
    {
        public override string Type { get; } = Type;

        public override IEnumerable<CSharpProperty> GetProperties(StructGenerator structGenerator)
        {
            yield return new CSharpProperty(Type + "*", Name)
            {
                Getter = new CSharpProperty.Accessor { Body = writer => writer.Write($"UnityVersionHandler.{structGenerator.StructName}.Get{Name}(Pointer);") },
            };
        }

        public override IEnumerable<CSharpMethod> GetMethods(StructGenerator structGenerator, FieldContext? context)
        {
            yield return new CSharpMethod(Type + "*", "Get" + Name)
            {
                Parameters = { new CSharpParameter(structGenerator.StructName + "*", "o") },
                Body = context == null
                    ? null
                    : writer =>
                    {
                        writer.WriteLine(context.StoreCast);
                        WriteGetterBody(writer, context);
                    },
            };
        }

        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"return &_->{context.FieldName};");
        }
    }

    public record StringField(string Name, string[] NativeFieldNames) : Field(Name, NativeFieldNames)
    {
        public override string Type => "string?";
        public string NativeType => "byte*";

        public override IEnumerable<CSharpProperty> GetProperties(StructGenerator structGenerator)
        {
            foreach (var property in base.GetProperties(structGenerator)) yield return property;

            yield return new CSharpProperty("ref " + NativeType, Name + "Pointer")
            {
                Getter = new CSharpProperty.Accessor { Body = writer => writer.Write($"ref UnityVersionHandler.{structGenerator.StructName}.Get{Name}Pointer(Pointer);") },
            };
        }

        public override IEnumerable<CSharpMethod> GetMethods(StructGenerator structGenerator, FieldContext? context)
        {
            foreach (var method in base.GetMethods(structGenerator, context)) yield return method;

            yield return new CSharpMethod("ref " + NativeType, "Get" + Name + "Pointer")
            {
                Parameters = { new CSharpParameter(structGenerator.StructName + "*", "o") },
                Body = context == null
                    ? null
                    : writer =>
                    {
                        writer.WriteLine(context.StoreCast);
                        writer.WriteLine($"return ref _->{context.FieldName};");
                    },
            };
        }

        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"return _->{context.FieldName} == default ? null : Marshal.PtrToStringUTF8((IntPtr)_->{context.FieldName});");
        }

        protected override void WriteSetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"_->{context.FieldName} = value == null ? default : (byte*)Marshal.StringToHGlobalAnsi(value);");
        }
    }

    public record BoolField(string Name, string[] NativeFieldNames) : Field(Name, NativeFieldNames)
    {
        public override string Type => "bool";

        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"return _->{context.FieldName} != 0 ? true : false;");
        }

        protected override void WriteSetterBody(CodeWriter writer, FieldContext context)
        {
            writer.WriteLine($"_->{context.FieldName} = (byte)(value ? 1 : 0);");
        }
    }
}
