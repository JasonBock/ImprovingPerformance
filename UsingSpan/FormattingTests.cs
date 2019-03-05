using BenchmarkDotNet.Attributes;
using System.Text;
using System.Text.Formatting;

namespace UsingSpan
{
	[MemoryDiagnoser]
	public class FormattingTests
	{
		[Params(100, 500, 1000, 5000)]
		public int Numbers { get; set; }

		[Benchmark]
		public string FormatWithStringBuilder()
		{
			var builder = new StringBuilder(this.Numbers);

			for (var i = 0; i < this.Numbers; i++)
			{
				builder.Append(i % 10);
			}

			return builder.ToString();
		}

		[Benchmark]
		public string FormatWithStringFormatter()
		{
			var builder = new StringFormatter(this.Numbers);

			for (var i = 0; i < this.Numbers; i++)
			{
				builder.Append(i % 10);
			}

			return builder.ToString();
		}
	}
}
