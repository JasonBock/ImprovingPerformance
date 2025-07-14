using BenchmarkDotNet.Attributes;
using System.Text;

namespace StringConcatenation;

[MemoryDiagnoser]
public class Concatenation3Parts
{
	private static readonly string dataOf5Length = StringCreation.Create(5);
	private static readonly string dataOf25Length = StringCreation.Create(25);
	private static readonly string dataOf200Length = StringCreation.Create(200);

	[Benchmark(Baseline = true)]
	public int ConcatenateWithAddition() =>
		(Concatenation3Parts.dataOf5Length + " and " +
		Concatenation3Parts.dataOf200Length + " and " +
		Concatenation3Parts.dataOf25Length).Length;

	[Benchmark]
	public int ConcatenateWithStringBuilder()
	{
		var builder = new StringBuilder();
		builder.Append(Concatenation3Parts.dataOf5Length);
		builder.Append(" and ");
		builder.Append(Concatenation3Parts.dataOf200Length);
		builder.Append(" and ");
		builder.Append(Concatenation3Parts.dataOf25Length);

		return builder.ToString().Length;
	}

	[Benchmark]
	public int ConcatenateWithInterpolation() =>
		$"{Concatenation3Parts.dataOf5Length} and {Concatenation3Parts.dataOf200Length} and {Concatenation3Parts.dataOf25Length}".Length;
}
