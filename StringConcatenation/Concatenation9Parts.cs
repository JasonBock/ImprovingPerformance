using BenchmarkDotNet.Attributes;
using System.Text;

namespace StringConcatenation;

[MemoryDiagnoser]
public class Concatenation9Parts
{
	private static readonly string dataOf5Length = StringCreation.Create(5);
	private static readonly string dataOf25Length = StringCreation.Create(25);
	private static readonly string dataOf200Length = StringCreation.Create(200);

	[Benchmark(Baseline = true)]
	public int ConcatenateWithAddition() =>
		(Concatenation9Parts.dataOf5Length + " and " +
		Concatenation9Parts.dataOf200Length + " and " +
		Concatenation9Parts.dataOf25Length + " and " +
		Concatenation9Parts.dataOf5Length + " and " +
		Concatenation9Parts.dataOf200Length + " and " +
		Concatenation9Parts.dataOf25Length + " and " +
		Concatenation9Parts.dataOf5Length + " and " +
		Concatenation9Parts.dataOf200Length + " and " +
		Concatenation9Parts.dataOf25Length).Length;

	[Benchmark]
	public int ConcatenateWithStringBuilder()
	{
		var builder = new StringBuilder();
		builder.Append(Concatenation9Parts.dataOf5Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf200Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf25Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf5Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf200Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf25Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf5Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf200Length);
		builder.Append(" and ");
		builder.Append(Concatenation9Parts.dataOf25Length);

		return builder.ToString().Length;
	}

	[Benchmark]
	public int ConcatenateWithInterpolation() =>
		$"{Concatenation9Parts.dataOf5Length} and {Concatenation9Parts.dataOf200Length} and {Concatenation9Parts.dataOf25Length} and {Concatenation9Parts.dataOf5Length} and {Concatenation9Parts.dataOf200Length} and {Concatenation9Parts.dataOf25Length} and {Concatenation9Parts.dataOf5Length} and {Concatenation9Parts.dataOf200Length} and {Concatenation9Parts.dataOf25Length}".Length;
}
