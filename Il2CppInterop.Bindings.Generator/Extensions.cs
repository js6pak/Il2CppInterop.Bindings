using AssetRipper.VersionUtilities;

namespace Il2CppInterop.Bindings.Generator;

public static class Extensions
{
    public static string ToFriendlyString(this UnityVersion unityVersion)
    {
        return unityVersion.Type == UnityVersionType.Final ? unityVersion.ToStringWithoutType() : unityVersion.ToString();
    }

    public static string ToSanitizedString(this UnityVersion unityVersion)
    {
        var result = $"{unityVersion.Major}_{unityVersion.Minor}_{unityVersion.Build}";

        if (unityVersion.Type != UnityVersionType.Final)
        {
            var type = unityVersion.Type switch
            {
                UnityVersionType.Alpha => "A",
                UnityVersionType.Beta => "B",
                UnityVersionType.China => "C",
                UnityVersionType.Final => "F",
                UnityVersionType.Patch => "P",
                UnityVersionType.Experimental => "E",
                _ => throw new ArgumentOutOfRangeException(),
            };
            result += $"_{type}{unityVersion.TypeNumber}";
        }

        return result;
    }

    public static string ToConstructorParameters(this UnityVersion unityVersion)
    {
        var result = $"{unityVersion.Major}, {unityVersion.Minor}, {unityVersion.Build}";

        if (unityVersion.Type != UnityVersionType.Final)
        {
            // Avoid MinValue/MaxValue from getting serialized
            var type = unityVersion.Type switch
            {
                UnityVersionType.Alpha => nameof(UnityVersionType.Alpha),
                UnityVersionType.Beta => nameof(UnityVersionType.Beta),
                UnityVersionType.China => nameof(UnityVersionType.China),
                UnityVersionType.Final => nameof(UnityVersionType.Final),
                UnityVersionType.Patch => nameof(UnityVersionType.Patch),
                UnityVersionType.Experimental => nameof(UnityVersionType.Experimental),
                _ => throw new ArgumentOutOfRangeException(),
            };
            result += $", UnityVersionType.{type}, {unityVersion.TypeNumber}";
        }

        return result;
    }

    public static string Intern(this string value)
    {
        return string.Intern(value);
    }
}
