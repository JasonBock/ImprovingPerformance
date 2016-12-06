using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using System;

namespace StringBuilderVersusXml
{
	class Program
	{
		static void Main(string[] args)
		{
			var result = BenchmarkRunner.Run<BuildingXml>(
				ManualConfig.Create(DefaultConfig.Instance)
					.With(new MemoryDiagnoser()));
			Console.Out.WriteLine(result);
		}
	}
}