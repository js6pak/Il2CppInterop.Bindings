namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppMethodGenerator : StructGenerator
{
    public override string StructName => "Il2CppMethod";

    public override Field[] Fields { get; } =
    {
        new StringField("Name", new[] { "name" }),
        new NormalField("uint", "Token", new[] { "token" }),
    };
}
