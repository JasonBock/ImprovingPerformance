using BenchmarkDotNet.Attributes;

namespace UsingSpan
{
	[MemoryDiagnoser]
	public class BufferGeneratorPerformance
	{
		[Benchmark]
		public byte[] GetConverterBytes() =>
			BufferGenerators.GenerateWithConverters(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");

		[Benchmark(Baseline = true)]
		public byte[] GetSpanBytes() =>
			BufferGenerators.GenerateWithSpan(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");

		[Benchmark]
		public byte[] GetStreamBytes() =>
			BufferGenerators.GenerateWithStream(
				22, new Coordinate { X = 10, Y = 20, Z = 30 },
				"This is a lot of string data. This is a lot of string data. This is a lot of string data.");
	}
}
