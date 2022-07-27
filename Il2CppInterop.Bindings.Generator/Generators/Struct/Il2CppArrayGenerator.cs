using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppArrayGenerator : StructGenerator
{
    public override string StructName => "Il2CppArray";

    public override Field[] Fields { get; } =
    {
        new LengthField("int", "Length", new[] { "max_length" }),
    };

    private record LengthField(string Type, string Name, string[] NativeFieldNames) : NormalField(Type, Name, NativeFieldNames)
    {
        private static readonly UnityVersion _version = new(2017, 2, 0, UnityVersionType.Final);

        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            if (context.UnityVersion >= _version)
            {
                writer.WriteLine($"return (int)_->{context.FieldName};");
            }
            else
            {
                base.WriteGetterBody(writer, context);
            }
        }

        protected override void WriteSetterBody(CodeWriter writer, FieldContext context)
        {
            if (context.UnityVersion >= _version)
            {
                writer.WriteLine($"_->{context.FieldName} = (nuint)value;");
            }
            else
            {
                base.WriteSetterBody(writer, context);
            }
        }
    }
}
