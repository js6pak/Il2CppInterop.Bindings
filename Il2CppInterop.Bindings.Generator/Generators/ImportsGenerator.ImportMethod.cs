using System.Runtime.InteropServices;
using AssetRipper.VersionUtilities;
using CSharpPoet;

namespace Il2CppInterop.Bindings.Generator.Generators;

public static partial class ImportsGenerator
{
    private class ImportMethod
    {
        private record UnityVersionRange(UnityVersion Start, UnityVersion? End);

        private readonly List<(UnityVersionRange, Il2CppVersion.Function)> _ranges = new();

        private (UnityVersion UnityVersion, Il2CppVersion.Function Function)? _current;

        public void Add(UnityVersion unityVersion, Il2CppVersion.Function function)
        {
            if (_current == null)
            {
                _current = (unityVersion, function);
            }
            else if (_current.Value.Function != function)
            {
                Finish(unityVersion);
                _current = (unityVersion, function);
            }
        }

        public void Finish(UnityVersion? endUnityVersion)
        {
            if (_current == null) return;

            _ranges.Add((new UnityVersionRange(_current.Value.UnityVersion, endUnityVersion), _current.Value.Function));
            _current = null;
        }

        public IEnumerable<CSharpMethod> ToCSharpMethods()
        {
            if (_current != null)
            {
                Finish(null);
            }

            foreach (var (range, function) in _ranges)
            {
                yield return ToCSharpMethod(range, function, _ranges.Count > 1);
            }
        }

        private static CSharpMethod ToCSharpMethod(UnityVersionRange range, Il2CppVersion.Function function, bool duplicate = false)
        {
            var dllImportAttribute = new CSharpAttribute("LibraryImportAttribute") { new CSharpAttribute.Parameter("\"GameAssembly\"") };

            if (duplicate)
            {
                dllImportAttribute.Add(new CSharpAttribute.Property("EntryPoint", $"\"{function.Name}\""));
            }

            var rangeAttribute = new CSharpAttribute("ApplicableToUnityVersions")
            {
                new CSharpAttribute.Parameter($"\"{range.Start.ToFriendlyString()}\""),
            };

            if (range.End != null)
            {
                rangeAttribute.Add(new CSharpAttribute.Parameter($"\"{range.End.Value.ToFriendlyString()}\""));
            }
            
            var method = new CSharpMethod(function.ReturnType, function.Name)
            {
                IsStatic = true,
                IsPartial = true,
                Attributes =
                {
                    rangeAttribute,
                    dllImportAttribute,
                },
                Parameters = function.Parameters.Select(parameter =>
                {
                    var name = parameter.Name;
                    if (name == string.Empty)
                    {
                        if (parameter.Type == "Il2CppException*" ) name = "ex";
                        else if (parameter.Type == "Il2CppMethod*") name = "method";
                        else throw new InvalidOperationException($"Parameter name was empty in {function.Name}");
                    }

                    var type = parameter.Type;

                    var csharpParameter = new CSharpParameter(type, name);

                    UnmanagedType? stringType = null;
                    if (type.StartsWith("byte*")) stringType = UnmanagedType.LPUTF8Str;
                    if (type.StartsWith("char*")) stringType = UnmanagedType.LPWStr;
                    if (!function.Name.StartsWith("il2cpp_format_") && stringType != null)
                    {
                        var isArray = type.EndsWith("[]");
                        csharpParameter.Type = isArray ? "string?[]" : "string?";

                        var attribute = new CSharpAttribute("MarshalAs");

                        if (isArray)
                        {
                            attribute.Add(new CSharpAttribute.Parameter("UnmanagedType.LPArray"));
                            attribute.Add(new CSharpAttribute.Property("ArraySubType", "UnmanagedType." + stringType));
                        }
                        else
                        {
                            attribute.Add(new CSharpAttribute.Parameter("UnmanagedType." + stringType));
                        }

                        csharpParameter.Attributes.Add(attribute);
                    }

                    if (type == "bool")
                    {
                        csharpParameter.Attributes.Add(new CSharpAttribute("MarshalAs")
                        {
                            new CSharpAttribute.Parameter("UnmanagedType.U1"),
                        });
                    }

                    return csharpParameter;
                }).ToList(),
            };

            if (function.ReturnType == "bool")
            {
                method.Attributes.Add(new CSharpAttribute("return: MarshalAs")
                {
                    new CSharpAttribute.Parameter("UnmanagedType.U1"),
                });
            }

            if (duplicate)
            {
                method.Name += "_" + range.Start.ToSanitizedString();
            }

            return method;
        }
    }
}
