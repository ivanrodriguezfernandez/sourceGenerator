## sourceGenerator

dotnet new sln -n SourceGeneratorWithContext     
dotnet new classlib-o SourceGenerator -f netstandar2.0 
dotnet sln add SourceGenerator 
cd SourceGenerator
dotnet add package Microsoft.CodeAnalysis.Analyzers
dotnet add package Microsoft.CodeAnalysis.CSharp


dotnet new console -o SGConsole
dotnet sln add SGConsole 



dotnet run --project SGHelloConsole