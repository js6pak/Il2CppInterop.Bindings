namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppClassGenerator : StructGenerator
{
    public override string StructName => "Il2CppClass";

    public override Field[] Fields { get; } =
    {
        new StringField("Name", new[] { "name" }),
    };
}
