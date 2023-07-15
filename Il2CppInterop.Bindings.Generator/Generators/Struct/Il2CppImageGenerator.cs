using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppImageGenerator : StructGenerator
{
    public override string StructName => "Il2CppImage";

    public override Field[] Fields { get; } =
    {
        new StringField("Name", new[] { "name" }),
        new AssemblyField("Il2CppAssembly*", "Assembly", new[] { "assembly", "assemblyIndex" }) { IsReadOnly = true },
    };

    private record AssemblyField(string Type, string Name, string[] NativeFieldNames) : NormalField(Type, Name, NativeFieldNames)
    {
        protected override void WriteGetterBody(CodeWriter writer, FieldContext context)
        {
            if (context.UnityVersion.IsLess(2018, 1, 0))
            {
                writer.WriteLine("return Il2CppImports.il2cpp_image_get_assembly(o);");
            }
            else
            {
                base.WriteGetterBody(writer, context);
            }
        }
    }
}
