using BenchmarkDotNet.Running;
using System;

namespace StringBuilderVersusXml
{
	class Program
	{
		static void Main(string[] args) => 
			Console.Out.WriteLine(BenchmarkRunner.Run<BuildingXml>());
	}
}