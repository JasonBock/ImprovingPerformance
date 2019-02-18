using BenchmarkDotNet.Running;
using System;

namespace UsingAttributes
{
	class Program
	{
		static void Main(string[] args) => Console.Out.WriteLine(
			BenchmarkRunner.Run<FindingAttributes>());
	}
}