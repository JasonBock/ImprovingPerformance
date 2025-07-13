using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using ProfilingHelloWorld;
using System.Reflection;

BuildHelloWorld();
ProfileHelloWorld();

static void BuildHelloWorld()
{
	var code =
		"""
		using System;

		if (args is not null)
		{
			for (var i = 0; i < args.Length; i++)
			{
				Console.WriteLine($"{i} : {args[i]}");
			}
		}

		Console.WriteLine("Hello world!");    
		""";

	var tree = SyntaxFactory.ParseSyntaxTree(code);
	var dotNetCoreDir = Path.GetDirectoryName(typeof(object).GetTypeInfo().Assembly.Location)!;
	var compilation = CSharpCompilation.Create(Shared.HelloWorldFile,
		options: new CSharpCompilationOptions(OutputKind.ConsoleApplication).WithPlatform(Platform.AnyCpu),
		syntaxTrees: [tree])
		.AddReferences(
			MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
			MetadataReference.CreateFromFile(typeof(Console).GetTypeInfo().Assembly.Location),
			MetadataReference.CreateFromFile(Path.Combine(dotNetCoreDir, "System.Runtime.dll")));

	using var stream = new FileStream(Shared.HelloWorldFile, FileMode.Create, FileAccess.Write);
	var result = compilation.Emit(stream);
}

static void ProfileHelloWorld() =>
	Console.WriteLine(BenchmarkRunner.Run<RunHelloWorld>());