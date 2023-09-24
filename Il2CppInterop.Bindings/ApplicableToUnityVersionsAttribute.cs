namespace Il2CppInterop.Bindings;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
internal class ApplicableToUnityVersionsAttribute : Attribute
{
    public ApplicableToUnityVersionsAttribute(string startVersion, string? endVersion = null)
    {
        StartVersion = startVersion;
        EndVersion = endVersion;
    }

    public string StartVersion { get; }
    public string? EndVersion { get; }
}
