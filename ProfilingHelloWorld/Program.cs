using BenchmarkDotNet.Running;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;

namespace ProfilingHelloWorld
{
	public static class Program
	{
		public const string HelloWorldFile = "HelloWorld.exe";

		public static void Foo(int[] values) { }

		public static void Main()
		{
			Program.Foo(Array.Empty<int>());
			Program.BuildHelloWorld();
			Program.ProfileHelloWorld();
		}

		private static void BuildHelloWorld()
		{
			var code =
@"using System;

namespace HelloWorld 
{  
	class Program  
	{    
		static void Main(string[] args)    
		{      
			if(args != null)
			{
				for(var i = 0; i < args.Length; i++)
				{
					Console.Out.WriteLine($""{i} : {args[i]}"");
				}
			}
			Console.Out.WriteLine(""Hello world!"");    
		}  
	} 
}";

			var tree = SyntaxFactory.ParseSyntaxTree(code);
			var compilation = CSharpCompilation.Create(Program.HelloWorldFile, 
				options: new CSharpCompilationOptions(OutputKind.ConsoleApplication), 
				syntaxTrees: new[] { tree }, 
				references: new[] 
				{
					MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
				});

			using (var stream = new FileStream(Program.HelloWorldFile, FileMode.Create, FileAccess.Write))
			{
				compilation.Emit(stream);
			}
		}

		private static void ProfileHelloWorld() => 
			Console.Out.WriteLine(BenchmarkRunner.Run<RunHelloWorld>());
	}
}