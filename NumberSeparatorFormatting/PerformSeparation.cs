#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;

namespace NumberSeparatorFormatting;

[MemoryDiagnoser]
public class PerformSeparation
{
	[Benchmark]
	[Arguments("1234567890")]
	[Arguments("12345678901234567890")]
	[Arguments("1234567890123456789012345678901234567890")]
	[Arguments("12345678901234567890123456789012345678901234567890123456789012345678901234567890")]
	public string AddSeparatorsNoSpans(string numberFormat) =>
		PerformSeparation.SeparateCharactersNoSpan(numberFormat, 3, true);

	[Benchmark]
	[Arguments("1234567890")]
	[Arguments("12345678901234567890")]
	[Arguments("1234567890123456789012345678901234567890")]
	[Arguments("12345678901234567890123456789012345678901234567890123456789012345678901234567890")]
	public string AddSeparatorsSpansNoStackallock(string numberFormat) =>
		PerformSeparation.SeparateCharactersSpanNoStackallock(numberFormat, 3, true);

	[Benchmark]
	[Arguments("1234567890")]
	[Arguments("12345678901234567890")]
	[Arguments("1234567890123456789012345678901234567890")]
	[Arguments("12345678901234567890123456789012345678901234567890123456789012345678901234567890")]
	public string AddSeparatorsSpansStackallock(string numberFormat) =>
		PerformSeparation.SeparateCharactersSpanStackallock(numberFormat, 3, true);

	private static string SeparateCharactersNoSpan(string numberFormat, uint spacingSize, bool inReverse)
	{
		// Calculate the total number of underscores to be inserted
		var inputLength = numberFormat.Length;
		var underscoreCount = (inputLength - 1) / spacingSize;

		// Create buffer.
		var bufferLength = inputLength + (int)underscoreCount;
		var buffer = new char[bufferLength];

		// Initialize indices
		var readIndex = inReverse ? inputLength - 1 : 0;
		var writeIndex = inReverse ? bufferLength - 1 : 0;
		var charactersSinceSeparator = 0;

		if (inReverse)
		{
			// Fill buffer right to left
			while (readIndex >= 0)
			{
				buffer[writeIndex--] = numberFormat[readIndex--];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex >= 0)
				{
					buffer[writeIndex--] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}
		else
		{
			// Fill buffer left to right
			while (readIndex < inputLength)
			{
				buffer[writeIndex++] = numberFormat[readIndex++];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex < inputLength)
				{
					buffer[writeIndex++] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}

		// Create and output string
		return new(buffer);
	}

	private static string SeparateCharactersSpanNoStackallock(ReadOnlySpan<char> chars, uint spacingSize, bool inReverse)
	{
		// Calculate the total number of underscores to be inserted
		var inputLength = chars.Length;
		var underscoreCount = (inputLength - 1) / spacingSize;

		// Create buffer.
		var bufferLength = inputLength + (int)underscoreCount;
		var buffer = new char[bufferLength];

		// Initialize indices
		var readIndex = inReverse ? inputLength - 1 : 0;
		var writeIndex = inReverse ? bufferLength - 1 : 0;
		var charactersSinceSeparator = 0;

		if (inReverse)
		{
			// Fill buffer right to left
			while (readIndex >= 0)
			{
				buffer[writeIndex--] = chars[readIndex--];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex >= 0)
				{
					buffer[writeIndex--] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}
		else
		{
			// Fill buffer left to right
			while (readIndex < inputLength)
			{
				buffer[writeIndex++] = chars[readIndex++];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex < inputLength)
				{
					buffer[writeIndex++] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}

		// Create and output string
		return new(buffer);
	}

	private static string SeparateCharactersSpanStackallock(ReadOnlySpan<char> chars, uint spacingSize, bool inReverse)
	{
		// Calculate the total number of underscores to be inserted
		var inputLength = chars.Length;
		var underscoreCount = (inputLength - 1) / spacingSize;

		// Create buffer.
		var bufferLength = inputLength + (int)underscoreCount;
		Span<char> buffer = stackalloc char[bufferLength];

		// Initialize indices
		var readIndex = inReverse ? inputLength - 1 : 0;
		var writeIndex = inReverse ? bufferLength - 1 : 0;
		var charactersSinceSeparator = 0;

		if (inReverse)
		{
			// Fill buffer right to left
			while (readIndex >= 0)
			{
				buffer[writeIndex--] = chars[readIndex--];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex >= 0)
				{
					buffer[writeIndex--] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}
		else
		{
			// Fill buffer left to right
			while (readIndex < inputLength)
			{
				buffer[writeIndex++] = chars[readIndex++];

				// Insert underscore if not at end of input
				charactersSinceSeparator++;

				if (charactersSinceSeparator == spacingSize && readIndex < inputLength)
				{
					buffer[writeIndex++] = '_';
					charactersSinceSeparator = 0;
				}
			}
		}

		// Create and output string
		return new(buffer);
	}
}