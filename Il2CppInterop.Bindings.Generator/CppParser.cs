// Adapted from https://github.com/MochiLibraries/Biohazrd

using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ClangSharp;
using ClangSharp.Interop;
using ClangSharp.Pathogen;

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

                    fixed (byte* nameP = Encoding.ASCII.GetBytes("LIBCLANG_DISABLE_CRASH_RECOVERY\0"))
                    fixed (byte* valueP = Encoding.ASCII.GetBytes("1\0"))
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

        if (!LibClangSharpResolver.TryLoadExplicitly())
        {
            throw new Exception("Failed to load LibClangSharp");
        }

        LibClangSharpResolver.VerifyResolverWasUsed();
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

        // On non-Windows platforms we need to provide the Clang resource directory.
        // This specifies the version copied to our output directory by ClangSharp.Pathogen.Runtime.
        // (One Windows the same files come from the UCRT instead.)
        // See https://github.com/InfectedLibraries/Biohazrd/issues/201 for more details
        var resourceDirectoryPath = Path.Combine(AppContext.BaseDirectory, "clang-resources");
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            if (!Directory.Exists(resourceDirectoryPath) || !File.Exists(Path.Combine(resourceDirectoryPath, "include", "stddef.h")))
            {
                throw new DirectoryNotFoundException("Clang resources directory not found.");
            }

            CommandLineArguments.Add("-resource-dir");
            CommandLineArguments.Add(resourceDirectoryPath);
        }
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

            var encoding = Encoding.UTF8;
            var filePathByteCount = encoding.GetByteCount(indexFileName);
            var contentsByteCount = encoding.GetByteCount(contents);
            var bufferSize = filePathByteCount + 1 + contentsByteCount; // +1 is the null terminator

            var buffer = GC.AllocateUninitializedArray<byte>(bufferSize, pinned: true);

            var bytesWritten = encoding.GetBytes(indexFileName.AsSpan(), buffer.AsSpan()[..filePathByteCount]);
            Debug.Assert(bytesWritten == filePathByteCount, "It's expected the encoder fills the expected portion of the buffer.");
            buffer[filePathByteCount] = 0; // Null terminator
            bytesWritten = encoding.GetBytes(contents.AsSpan(), buffer.AsSpan().Slice(filePathByteCount + 1, contentsByteCount));
            Debug.Assert(bytesWritten == contentsByteCount, "It's expected the encoder fills the expected portion of the buffer.");

            unsafe
            {
                var bufferPointer = (sbyte*)Unsafe.AsPointer(ref buffer[0]);
                return new CXUnsavedFile
                {
                    Filename = bufferPointer,
                    Contents = bufferPointer + filePathByteCount + 1,
                    Length = (nuint)contentsByteCount,
                };
            }
        }

        var cxIndex = CXIndex.Create();
        _cxIndex = cxIndex;

        CommandLineArguments.Add("-I" + SourcePath);

        var unsavedFiles = new List<CXUnsavedFile>
        {
            CreateIndexFile(),
        };

        var translationUnitStatus = CXTranslationUnit.TryParse(
            cxIndex,
            indexFileName,
            CollectionsMarshal.AsSpan(CommandLineArguments),
            CollectionsMarshal.AsSpan(unsavedFiles),
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
