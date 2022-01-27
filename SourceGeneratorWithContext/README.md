## sourceGenerator


```
dotnet new sln -n SourceGeneratorWithContext     
```

```
dotnet new classlib -o SourceGenerator -f netstandard2.1
```                                       

```
dotnet sln add SourceGenerator 
```

```
cd SourceGenerator
dotnet add package Microsoft.CodeAnalysis.Analyzers
dotnet add package Microsoft.CodeAnalysis.CSharp
```

```
cd ..
dotnet new console -o SGConsole
dotnet sln add SGConsole 
```

```
dotnet run --project SGHelloConsole
```