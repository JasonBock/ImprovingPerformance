using BenchmarkDotNet.Running;
using UsingAttributes;

Console.WriteLine(BenchmarkRunner.Run<FindingAttributes>());