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

    public string FullName
    {
        get
        {
            if (DeclaringType != null)
            {
                return DeclaringType->FullName + "+" + Name;
            }

            if (!string.IsNullOrEmpty(Namespace))
            {
                return Namespace + Name;
            }

            return Name ?? throw new InvalidOperationException("Name can't be null");
        }
    }

    public string AssemblyQualifiedName => FullName + ", " + Image->NameWithoutExtension;

    public NativeArray<Pointer<Il2CppClass>> GetNestedTypes()
    {
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
    }

    public NativeArray<Pointer<Il2CppMethod>> GetMethods()
    {
        // Make sure Class::SetupMethods was called
        if (Rank > 0 || MethodCount > 0)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_methods(Pointer, &iter);
        }

        return NativeArray.From(MethodCount, Methods);
    }

    public Il2CppMethod* GetMethodByToken(uint token)
    {
        foreach (var methodPointer in GetMethods())
        {
            var method = methodPointer->Value;
            if (method->Token == token)
            {
                return method;
            }
        }

        return default;
    }

    public Il2CppMethod* GetMethodByName(string name)
    {
        var found = false;
        var result = default(Il2CppMethod*);

        foreach (var methodPointer in GetMethods())
        {
            var method = methodPointer->Value;
            if (method->Name == name)
            {
                if (found)
                {
                    throw new InvalidOperationException($"Class contains more than one method named {name}");
                }

                found = true;
                result = method;
            }
        }

        return result;
    }

    public Il2CppMethod* GetMethodByNameOrThrow(string name)
    {
        var result = GetMethodByName(name);
        if (result == null) throw new InvalidOperationException($"Class contains no method named {name}");
        return result;
    }

    public NativeArray<Il2CppField> GetFields()
    {
        // Make sure Class::SetupFields was called
        if (!IsSizeInitialized)
        {
            void* iter = default;
            Il2CppImports.il2cpp_class_get_fields(Pointer, &iter);
        }

        return new NativeArray<Il2CppField>(FieldCount, Fields);
    }

    public Il2CppField* GetFieldByName(string name)
    {
#if DISABLE_SHORTCUTS
        return Il2CppImports.il2cpp_class_get_field_from_name(Pointer, name);
#else
        foreach (var field in GetFields())
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

    public static Il2CppClass* MakePointerClass(Il2CppClass* elementClass)
    {
        var pointerType = new Il2CppType
        {
            Type = Il2CppTypeEnum.Ptr,
            Data = elementClass->Type,
        };
        return FromIl2CppType(&pointerType);
    }
}
