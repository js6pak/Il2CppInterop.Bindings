using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppClassGenerator : StructGenerator
{
    public override string StructName => "Il2CppClass";

    public override Field[] Fields { get; } =
    {
        new NormalField("Il2CppImage*", "Image", new[] { "image" }),
        new StringField("Name", new[] { "name" }),
        new StringField("Namespace", new[] { "namespaze" }),
        new NormalField("Il2CppClass*", "DeclaringType", new[] { "declaringType" }),
        new BoolField("IsGeneric", new[] { "is_generic" }),
        new BoolField("IsSizeInitialized", new[] { "size_inited" }),

        new ByValField(),

        new NormalField("Il2CppClass**", "NestedTypes", new[] { "nestedTypes" }),
        new NormalField("ushort", "NestedTypeCount", new[] { "nested_type_count" }),

        new NormalField("Il2CppMethod**", "Methods", new[] { "methods" }),
        new NormalField("ushort", "MethodCount", new[] { "method_count" }),

        new NormalField("Il2CppField*", "Fields", new[] { "fields" }),
        new NormalField("ushort", "FieldCount", new[] { "field_count" }),

        new NormalField("byte", "Rank", new[] { "rank" }),
    };

    private record ByValField() : PointerField("Il2CppType", "ByVal", new[] { "byval_arg" })
    {
        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            if (context.UnityVersion <= new UnityVersion(5, 6, 0, UnityVersionType.Final))
            {
                writer.WriteLine($"return _->{context.FieldName};");
            }
            else
            {
                base.WriteGetterBody(writer, context);
            }
        }
    }
}
