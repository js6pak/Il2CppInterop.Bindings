#pragma warning disable CS0649
#pragma warning disable CS0169
// ReSharper disable InconsistentNaming
// ReSharper disable ConvertToAutoProperty

using Il2CppInterop.Bindings.Utilities;

namespace Il2CppInterop.Bindings.Structs;

public unsafe partial struct Il2CppClass
{
    public Il2CppType* Type =>
#if DISABLE_SHORTCUTS
        Il2CppImports.il2cpp_class_get_type(Pointer);
#else
        ByVal;
#endif

    public bool IsInflated =>
#if DISABLE_SHORTCUTS
        Il2CppImports.il2cpp_class_is_inflated(Pointer);
#else
        IsGeneric;
#endif

    public IEnumerable<Handle<Il2CppClass>> GetNestedTypes()
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppClass>(Pointer, &Il2CppImports.il2cpp_class_get_nested_types);
#else
        if (IsGeneric)
        {
            throw new ArgumentException("Can't get nested types for a generic class");
        }

        // Make sure Class::SetupNestedTypes was called
        if (NestedTypes == default && NestedTypeCount > 0)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_nested_types(Pointer, &iter);
        }

        return NativeArray.From(NestedTypeCount, NestedTypes);
#endif
    }

    public IEnumerable<Handle<Il2CppMethod>> GetMethods()
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppMethod>(Pointer, &Il2CppImports.il2cpp_class_get_methods);
#else
        // Make sure Class::SetupMethods was called
        if (Rank > 0 || MethodCount > 0)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_methods(Pointer, &iter);
        }

        return NativeArray.From(MethodCount, Methods);
#endif
    }

    public Il2CppMethod* GetMethodByToken(uint token)
    {
        foreach (var (method, _) in GetMethods())
        {
            if (method->Token == token)
            {
                return method;
            }
        }

        return default;
    }

    public IEnumerable<Handle<Il2CppField>> GetFields()
    {
#if DISABLE_SHORTCUTS
        return new NativeIterEnumerator<Il2CppClass, Il2CppField>(Pointer, &Il2CppImports.il2cpp_class_get_fields);
#else
        // Make sure Class::SetupFields was called
        if (!IsSizeInitialized)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_fields(Pointer, &iter);
        }

        return new NativeArray<Il2CppField>(FieldCount, Fields).GetHandles();
#endif
    }

    public Il2CppField* GetFieldByName(string name)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_get_field_from_name(Pointer, name);
#else
        foreach (var (field, _) in GetFields())
        {
            if (field->Name == name)
            {
                return field;
            }
        }

        return default;
#endif
    }

    // TODO make a shortcut, keep in mind newest unity moved this from class to type
    public bool IsValueType => Il2CppImports.il2cpp_class_is_valuetype(Pointer);

    public int ValueSize
    {
        get
        {
            if (!IsValueType) throw new ArgumentException("ValueSize can only be called on ValueTypes");
            return Il2CppImports.il2cpp_class_value_size(Pointer, default);
        }
    }

    public static Il2CppClass* FromName(Il2CppImage* image, string @namespace, string name)
    {
        return Il2CppImports.il2cpp_class_from_name(image, @namespace, name);
    }

    public static Il2CppClass* FromIl2CppType(Il2CppType* type)
    {
        return Il2CppImports.il2cpp_class_from_type(type);
    }

    public static Il2CppClass* FromReflectionType(Il2CppReflectionType* type)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_from_system_type(type);
#else
        return FromIl2CppType(type->Type);
#endif
    }
}
