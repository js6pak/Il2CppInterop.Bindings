namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppMethodGenerator : StructGenerator
{
    public override string StructName => "Il2CppMethod";

    public override Field[] Fields { get; } =
    {
        new NormalField("void*", "MethodPointer", new[] { "methodPointer", "method" }),
        new NormalField("void*", "InvokerMethod", new[] { "invoker_method" }),
        new NormalField("Il2CppClass*", "Class", new[] { "klass", "declaring_type" }),
        new StringField("Name", new[] { "name" }),
        new NormalField("uint", "Token", new[] { "token" }),
    };
}
