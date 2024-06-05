// Adapted from https://github.com/MochiLibraries/Biohazrd

using System.Runtime.InteropServices;
using System.Text;
using ClangSharp;
using ClangSharp.Interop;

namespace Il2CppInterop.Bindings.Generator;

public class CppParser : IDisposable
{
    public static void Initialize()
    {
        // Workaround for https://github.com/MochiLibraries/ClangSharp.Pathogen/issues/7
        if (OperatingSystem.IsLinux())
        {
            try
            {
                unsafe
                {
                    [DllImport("libc")]
                    static extern int setenv(byte* envname, byte* envval, int overwrite);

                    fixed (byte* nameP = "LIBCLANG_DISABLE_CRASH_RECOVERY\0"u8)
                    fixed (byte* valueP = "1\0"u8)
                    {
                        setenv(nameP, valueP, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception while applying ClangSharp.Pathogen#7 workaround: {ex}");
            }
        }
    }

    public string SourcePath { get; }

    public string[] IndexedFiles { get; }

    public List<string> CommandLineArguments { get; } = new();

    private CXIndex? _cxIndex;

    public TranslationUnit? TranslationUnit { get; private set; }

    public CppParser(string sourcePath, string[] indexedFiles)
    {
        SourcePath = sourcePath;
        IndexedFiles = indexedFiles;

        // https://github.com/js6pak/libclang.resources
        LoadClangResources();

        CommandLineArguments.Add("-I" + SourcePath);

        var extraArguments = Environment.GetEnvironmentVariable("EXTRA_CLANG_ARGS");
        if (extraArguments != null)
        {
            CommandLineArguments.AddRange(extraArguments.Split(" "));
        }
    }

    private void LoadClangResources()
    {
        var resourceDirectoryPath = Path.Combine(AppContext.BaseDirectory, "clang-resources");
        if (!Directory.Exists(resourceDirectoryPath) || !File.Exists(Path.Combine(resourceDirectoryPath, "include", "stddef.h")))
        {
            throw new DirectoryNotFoundException("Clang resources directory not found.");
        }

        CommandLineArguments.Add("-resource-dir");
        CommandLineArguments.Add(resourceDirectoryPath);
    }

    public TranslationUnit Parse()
    {
        if (TranslationUnit != null) throw new InvalidOperationException("Cannot parse twice");

        const string indexFileName = "<>IndexFile.cpp";

        CXUnsavedFile CreateIndexFile()
        {
            var builder = new StringBuilder();

            foreach (var file in IndexedFiles)
            {
                builder.AppendLine($"#include \"{file}\"");
            }

            var contents = builder.ToString();

            return CXUnsavedFile.Create(indexFileName, contents);
        }

        var cxIndex = CXIndex.Create();
        _cxIndex = cxIndex;

        var translationUnitStatus = CXTranslationUnit.TryParse(
            cxIndex,
            indexFileName,
            CollectionsMarshal.AsSpan(CommandLineArguments),
            [CreateIndexFile()],
            CXTranslationUnit_Flags.CXTranslationUnit_SkipFunctionBodies | CXTranslationUnit_Flags.CXTranslationUnit_IncludeAttributedTypes | CXTranslationUnit_Flags.CXTranslationUnit_DetailedPreprocessingRecord,
            out var translationUnitHandle
        );

        if (translationUnitStatus != CXErrorCode.CXError_Success)
        {
            throw new InvalidOperationException($"Failed to parse the index file due to a fatal Clang error {translationUnitStatus}.");
        }

        return TranslationUnit = TranslationUnit.GetOrCreate(translationUnitHandle);
    }

    public void Dispose()
    {
        _cxIndex?.Dispose();
        TranslationUnit?.Dispose();
    }
}
