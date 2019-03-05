using BenchmarkDotNet.Running;

namespace RefReturns
{
	class Program
	{
		static void Main() =>
			BenchmarkRunner.Run<ListIndexPerformance>();
	}
}
