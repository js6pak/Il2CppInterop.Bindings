namespace Il2CppInterop.Bindings;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
internal class ApplicableToUnityVersionsSinceAttribute : Attribute
{
    public ApplicableToUnityVersionsSinceAttribute(string startVersion)
    {
        StartVersion = startVersion;
    }

    public string StartVersion { get; }
}
