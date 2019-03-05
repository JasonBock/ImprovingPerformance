using BenchmarkDotNet.Running;
using System;

namespace StringBuilderVersusXml
{
	class Program
	{
		static void Main() => 
			Console.Out.WriteLine(BenchmarkRunner.Run<BuildingXml>());
	}
}