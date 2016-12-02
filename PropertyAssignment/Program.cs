using System;
using BenchmarkDotNet.Running;

namespace PropertyAssignment
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Out.WriteLine(BenchmarkRunner.Run<AssigningProperties>());
		}
	}
}
