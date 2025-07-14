using BenchmarkDotNet.Running;
using NumberSeparatorFormatting;

var x = "a,b,c";
var items = x.Split(',');

BenchmarkRunner.Run<PerformSeparation>();

//var perform = new PerformSeparation();
//Console.WriteLine(perform.AddSeparatorsNoSpans("1234567890123456789012345678901234567890"));
//Console.WriteLine(perform.AddSeparatorsSpansNoStackallock("1234567890123456789012345678901234567890"));
//Console.WriteLine(perform.AddSeparatorsSpansStackallock("1234567890123456789012345678901234567890"));