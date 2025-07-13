#pragma warning disable CA1024 // Use properties where appropriate

using BenchmarkDotNet.Attributes;
using System.Runtime.InteropServices;

namespace RefReturns;

[MemoryDiagnoser]
public class ListIndexPerformance
{
	const uint Capacity = 1_000;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	private List<GiantStruct> listData;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

	[GlobalSetup]
	public void Setup()
	{
		this.listData = [.. new GiantStruct[ListIndexPerformance.Capacity]];

		for (var i = 0; i < ListIndexPerformance.Capacity; i++)
		{
			var value = Guid.NewGuid();
			this.listData[i] = new GiantStruct { Value1 = i, Value2 = value, Value3 = i, Value4 = value.ToString() };
		}
	}

	[Benchmark(Baseline = true)]
	public int GetNameFromNonSpanList()
	{
		var totalSize = 0;

		foreach (var giant in this.listData)
		{
			totalSize += giant.Value4.Length;
		}

		return totalSize;
	}

	[Benchmark]
	public int GetNameFromSpanList()
	{
		var totalSize = 0;

		foreach (ref var giant in CollectionsMarshal.AsSpan(this.listData))
		{
			totalSize += giant.Value4.Length;
		}

		return totalSize;
	}
}