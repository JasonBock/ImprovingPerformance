using BenchmarkDotNet.Running;
using System;

namespace PropertyAssignment
{
	class Program
	{
		static void Main() => 
			Console.Out.WriteLine(BenchmarkRunner.Run<AssigningProperties>());
	}
}