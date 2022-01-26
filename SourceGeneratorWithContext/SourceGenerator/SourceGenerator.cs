using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGenerator
{
    [Generator]
    public class SourceGenerator : ISourceGenerator
    {

        public void Execute(GeneratorExecutionContext context)
        {

            var syntaxTree = context.Compilation.SyntaxTrees;
            var mappers = syntaxTree.Where(x => x.GetText().ToString().Contains("IMapFrom<"));

            var sourceBuilder = new StringBuilder(@"
using System;
namespace MapProfilesGenerated
{
    public static class ProfileProvider
    {
        public static void Get()
        {
");
            // using the context, get a list of syntax trees in the users compilation
            foreach (var mapper in mappers)
            {
                var classDeclarations = mapper.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (classDeclarations != null)
                {
                    var className = classDeclarations.Identifier.ToString();
                    sourceBuilder.AppendLine($@"Console.WriteLine(@"" --- {className}"");");
                }
            }

            // finish creating the source to inject
            sourceBuilder.Append(@"
        }
    }

}");
            // inject the created source into the users compilation
            context.AddSource("mapProfilesGenerated", SourceText.From(sourceBuilder.ToString(), Encoding.UTF8));
        }

        public void Initialize(GeneratorInitializationContext context)
        {

            if (!Debugger.IsAttached)
            {
                Debugger.Launch();
            }

        }
    }
}