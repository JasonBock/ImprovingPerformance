using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using System;

namespace PropertyAssignment
{
	class Program
	{
		static void Main(string[] args)
		{
			var result = BenchmarkRunner.Run<AssigningProperties>(
				ManualConfig.Create(DefaultConfig.Instance)
					.With(new MemoryDiagnoser()));

			Console.Out.WriteLine();
		}
	}
}