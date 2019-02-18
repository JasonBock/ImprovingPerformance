using BenchmarkDotNet.Running;
using System;

namespace PropertyAssignment
{
	class Program
	{
		static void Main(string[] args) => 
			Console.Out.WriteLine(BenchmarkRunner.Run<AssigningProperties>());
	}
}