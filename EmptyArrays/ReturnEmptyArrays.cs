using BenchmarkDotNet.Attributes;

namespace EmptyArrays;

[MemoryDiagnoser]
public class ReturnEmptyArrays
{
	[Benchmark]
#pragma warning disable CA1825 // Avoid zero-length array allocations
	public int[] EmptyViaNew() => new int[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations

	[Benchmark]
	public int[] EmptyViaArray() => Array.Empty<int>();
}
