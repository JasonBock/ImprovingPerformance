using BenchmarkDotNet.Attributes;
using System;

namespace EmptyArrays
{
	[MemoryDiagnoser]
	public class ReturnEmptyArrays
	{
		[Benchmark]
		public int[] EmptyViaNew() => new int[0];

		[Benchmark]
		public int[] EmptyViaArray() => Array.Empty<int>();
	}
}
