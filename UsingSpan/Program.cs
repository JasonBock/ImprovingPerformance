using BenchmarkDotNet.Running;

namespace UsingSpan
{
	class Program
	{
		static void Main() =>
			BenchmarkRunner.Run<ReturnEmptyArrays>();
	}
}
