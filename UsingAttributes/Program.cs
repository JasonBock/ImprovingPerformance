using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using System;

namespace UsingAttributes
{
	class Program
	{
		static void Main(string[] args)
		{
			var result = BenchmarkRunner.Run<FindingAttributes>(
				ManualConfig.Create(DefaultConfig.Instance)
					.With(new MemoryDiagnoser()));

			Console.Out.WriteLine(result);
		}
	}
}
