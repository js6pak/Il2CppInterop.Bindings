// Adapted from https://github.com/MochiLibraries/Biohazrd

global using ClangType = ClangSharp.Type;
using System.Diagnostics;
using System.Reflection;
using ClangSharp;
using ClangSharp.Interop;
using ClangSharp.Pathogen;
using Il2CppInterop.Bindings.Generator.Generators;

namespace Il2CppInterop.Bindings.Generator;

public static class ClangSharpExtensions
{
    internal static ClangType FindType(this TranslationUnit translationUnit, CXType handle)
    {
        if (handle.kind == CXTypeKind.CXType_Invalid)
        {
            throw new ArgumentException("The specified type handle is invalid.", nameof(handle));
        }

        var ret = translationUnit.GetOrCreate(handle);
        Debug.Assert(ret is not null);
        return ret;
    }

    public static string ToCSharpString(this ClangType clangType)
    {
        if (clangType.IsLocalConstQualified)
        {
            return ToCSharpString(clangType.Desugar);
        }

        switch (clangType)
        {
            case FunctionProtoType: return "void";
            case PointerType or ReferenceType: return ToCSharpString(clangType.PointeeType) + "*";
            case ConstantArrayType constantArrayType: return ToCSharpString(constantArrayType.ElementType) + $"[{constantArrayType.Size}]";
            case ArrayType arrayType: return ToCSharpString(arrayType.ElementType) + "[]";
            case ElaboratedType elaboratedType: return ToCSharpString(elaboratedType.NamedType);
            case EnumType enumType: return ToCSharpString(enumType.Decl.IntegerType);
            case TypedefType typedefType:
            {
                switch (typedefType.AsString)
                {
                    case "size_t" or "uintptr_t ": return "nuint";
                    case "ptrdiff_t" or "intptr_t": return "nint";
                    // case "methodPointerType": return "Il2CppMethodPointer";
                }

                if (typedefType.IsSugared)
                {
                    return ToCSharpString(typedefType.Desugar);
                }

                break;
            }
            case BuiltinType:
            {
                switch (clangType.Kind)
                {
                    case CXTypeKind.CXType_Bool: return "bool";
                    case CXTypeKind.CXType_Char_S or CXTypeKind.CXType_Char_U: return "byte";
                    case CXTypeKind.CXType_Char16: return "char";

                    case CXTypeKind.CXType_UChar: return "byte";
                    case CXTypeKind.CXType_UShort: return "ushort";
                    case CXTypeKind.CXType_UInt: return "uint";
                    case CXTypeKind.CXType_ULong:
                        return clangType.Handle.SizeOf switch
                        {
                            1 => "byte",
                            2 => "ushort",
                            4 => "uint",
                            8 => "ulong",
                            _ => throw new ArgumentOutOfRangeException(),
                        };
                    case CXTypeKind.CXType_ULongLong: return "ulong";

                    case CXTypeKind.CXType_SChar: return "sbyte";
                    case CXTypeKind.CXType_Short: return "short";
                    case CXTypeKind.CXType_Int: return "int";
                    case CXTypeKind.CXType_Long:
                        return clangType.Handle.SizeOf switch
                        {
                            1 => "sbyte",
                            2 => "short",
                            4 => "int",
                            8 => "long",
                            _ => throw new ArgumentOutOfRangeException(),
                        };
                    case CXTypeKind.CXType_LongLong: return "long";

                    case CXTypeKind.CXType_Float: return "float";
                    case CXTypeKind.CXType_Double: return "double";
                }

                break;
            }
        }

        var name = clangType.AsString;

        switch (name)
        {
            case "Il2CppArray":
            case "Il2CppGenericClass":
            case "Il2CppTypeDefinition":
            case "Il2CppInteropData":
            case "Il2CppRGCTXData":
            case "Il2CppCodeGenModule":
            case "Il2CppNameToTypeDefinitionIndexHashTable":
            case "Il2CppNameToTypeHandleHashTable":
            case "___Il2CppMetadataTypeHandle":
            case "___Il2CppMetadataGenericContainerHandle":
            case "___Il2CppMetadataImageHandle":
                return "void";
        }

        return StructsGenerator.RenameStruct(name);
    }

    private static readonly FieldInfo _createdCursorsField = typeof(TranslationUnit).GetField("_createdCursors", BindingFlags.Instance | BindingFlags.NonPublic)!;

    // Clean after ClangSharp in a dirty way
    public static void CleanCursors(this TranslationUnit translationUnit)
    {
        var createdCursors = (Dictionary<CXCursor, WeakReference<Cursor?>>)_createdCursorsField.GetValue(translationUnit)!;

        foreach (var value in createdCursors.Values)
        {
            value.SetTarget(null);
        }

        createdCursors.Clear();
    }
}
