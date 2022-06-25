using AssetRipper.VersionUtilities;

namespace Il2CppInterop.Bindings;

public static partial class UnityVersionHandler
{
    public static void Initialize(UnityVersion unityVersion)
    {
        InitializeNativeStructHandlers(unityVersion);
    }
}

public interface INativeStructHandler
{
    public int Size { get; }
}
