using BenchmarkDotNet.Running;

namespace EmptyArrays
{
	class Program
	{
		static void Main() =>
			BenchmarkRunner.Run<ReturnEmptyArrays>();
	}
}
