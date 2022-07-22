using AssetRipper.VersionUtilities;

namespace Il2CppInterop.Bindings;

public static partial class UnityVersionHandler
{
    public static UnityVersion Version { get; private set; }

    public static void Initialize(UnityVersion unityVersion)
    {
        Version = unityVersion;
        InitializeNativeStructHandlers(unityVersion);
        Il2CppRuntime.Initialize();
    }
}

public interface INativeStructHandler
{
    public int Size { get; }
}
