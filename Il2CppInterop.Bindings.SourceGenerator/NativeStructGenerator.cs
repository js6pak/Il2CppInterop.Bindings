using System.Text;
using System.Threading;
using CSharpPoet;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Il2CppInterop.Bindings.SourceGenerator;

[Generator]
public class NativeStructGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var classDeclarations = context.SyntaxProvider.CreateSyntaxProvider(
            static (node, _) => node is StructDeclarationSyntax s && s.AttributeLists.Any(),
            GetTypeSymbol
        ).Where(static s => s is not null);

        context.RegisterSourceOutput(classDeclarations, EmitSourceFile);
    }

    private static ITypeSymbol GetTypeSymbol(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        var decl = (StructDeclarationSyntax)context.Node;

        if (context.SemanticModel.GetDeclaredSymbol(decl, cancellationToken) is ITypeSymbol typeSymbol)
        {
            foreach (var attributeData in typeSymbol.GetAttributes())
            {
                if (attributeData.AttributeClass?.ToDisplayString() == "Il2CppInterop.Bindings.Utilities.NativeStructAttribute")
                {
                    return typeSymbol;
                }
            }
        }

        return null;
    }

    private static void EmitSourceFile(SourceProductionContext context, ITypeSymbol typeSymbol)
    {
        var file = new CSharpFile(typeSymbol.ContainingNamespace.ToDisplayString())
        {
            Usings = { "System.Runtime.CompilerServices" },
            Members =
            {
                new CSharpStruct(typeSymbol.Name)
                {
                    IsPartial = true,
                    IsUnsafe = true,
                    Members =
                    {
                        new CSharpProperty(typeSymbol.Name + "*", "Pointer")
                        {
                            Getter = new CSharpProperty.Accessor
                            {
                                Body = writer => writer.Write($"({typeSymbol.Name + "*"})Unsafe.AsPointer(ref this);"),
                            },
                        },
                    },
                },
            },
        };

        context.AddSource($"{typeSymbol.ToDisplayString()}.g.cs", SourceText.From(file.ToString(), Encoding.UTF8));
    }
}
