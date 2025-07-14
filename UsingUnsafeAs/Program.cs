using BenchmarkDotNet.Running;
using System.Runtime.CompilerServices;
using UsingUnsafeAs;

BenchmarkRunner.Run<CastingObjects>();

//object target = new TargetType();

//#pragma warning disable IDE0007 // Use implicit type
//try
//{
//   string stringTarget = ((string)target)!;
//   Console.WriteLine(stringTarget.GetType().FullName);
//	Console.WriteLine(stringTarget.Length);
//}
//catch (InvalidCastException e)
//{
//	Console.WriteLine($"Cast exception: {e.Message}");
//}

//Console.WriteLine();

//try
//{
//	string stringTarget = Unsafe.As<string>(target);
//	Console.WriteLine(stringTarget.GetType().FullName);
//	Console.WriteLine(stringTarget.Length);
//}
//catch (InvalidCastException e)
//{
//	Console.WriteLine($"Unsafe.As() exception: {e.Message}");
//}
//#pragma warning restore IDE0007 // Use implicit type