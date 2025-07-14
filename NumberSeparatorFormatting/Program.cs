using BenchmarkDotNet.Running;
using NumberSeparatorFormatting;

BenchmarkRunner.Run<PerformSeparation>();

//var perform = new PerformSeparation();
//Console.WriteLine(perform.AddSeparatorsNoSpans("1234567890123456789012345678901234567890"));
//Console.WriteLine(perform.AddSeparatorsSpansNoStackallock("1234567890123456789012345678901234567890"));
//Console.WriteLine(perform.AddSeparatorsSpansStackallock("1234567890123456789012345678901234567890"));