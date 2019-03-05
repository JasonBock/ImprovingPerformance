using BenchmarkDotNet.Attributes;
using System;

namespace RefReturns
{
	[MemoryDiagnoser]
	public class ListIndexPerformance
	{
		private SlowList<GiantStruct> slowListData;
		private FastList<GiantStruct> fastListData;

		[GlobalSetup]
		public void Setup()
		{
			this.slowListData = new SlowList<GiantStruct>(100000);
			this.slowListData[40000] = new GiantStruct { Value1 = 222, Value2 = Guid.NewGuid(), Value3 = 22.2, Value4 = "A bunch of data" };
			this.fastListData = new FastList<GiantStruct>(100000);
			this.fastListData[40000] = new GiantStruct { Value1 = 222, Value2 = Guid.NewGuid(), Value3 = 22.2, Value4 = "A bunch of data" };
		}

		[Benchmark(Baseline = true)]
		public int GetNameFromFastList() => ListIndexPerformance.GetStringValueLength(this.fastListData[40000].Value4);

		[Benchmark]
		public int GetNameFromSlowList() => ListIndexPerformance.GetStringValueLength(this.slowListData[40000].Value4);

		private static int GetStringValueLength(string value) => value.Length;
	}
}
