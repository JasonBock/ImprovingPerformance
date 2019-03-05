using BenchmarkDotNet.Running;
using System;

namespace UsingAttributes
{
	class Program
	{
		static void Main() => 
			Console.Out.WriteLine(BenchmarkRunner.Run<FindingAttributes>());
	}
}