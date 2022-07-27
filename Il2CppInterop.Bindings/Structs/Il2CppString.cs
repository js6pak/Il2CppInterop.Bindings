#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using System.Runtime.InteropServices;
using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

[NativeStruct]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe partial struct Il2CppString
{
    private Il2CppObject @object;
    private int length;
    private char* chars => (char*)(Pointer + 1);

    public int Length => length;

    public ReadOnlySpan<char> Chars => new(chars, length);

    public override string ToString()
    {
        return new string(chars, 0, Length);
    }

    public static Il2CppString* From(string value)
    {
        return Il2CppImports.il2cpp_string_new_utf16(value, value.Length);
    }

    public static Il2CppString* Intern(Il2CppString* str)
    {
        return Il2CppImports.il2cpp_string_intern(str);
    }

    public static Il2CppString* IsInterned(Il2CppString* str)
    {
        return Il2CppImports.il2cpp_string_is_interned(str);
    }
}
