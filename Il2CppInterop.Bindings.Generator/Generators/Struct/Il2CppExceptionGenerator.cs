namespace Il2CppInterop.Bindings.Generator.Generators.Struct;

internal class Il2CppExceptionGenerator : StructGenerator
{
    public override string StructName => "Il2CppException";

    public override Field[] Fields { get; } =
    {
        new PointerField("Il2CppObject", "Object", new[] { "object", "base" }),
        new NormalField("Il2CppString*", "Message", new[] { "message" }),
        new NormalField("Il2CppString*", "StackTrace", new[] { "stack_trace" }),
    };
}
