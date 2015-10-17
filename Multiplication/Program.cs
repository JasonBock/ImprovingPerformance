using System;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography;

namespace Multiplication
{
	class Program
	{
		private static BigInteger result;

		static void Main(string[] args)
		{
			//Program.QuickTest();
			
			//Program.NaiveTimeTest(new BigInteger(3), new BigInteger(2));
			//Program.NaiveTimeTest(new BigInteger(30), new BigInteger(20));
			//Program.NaiveTimeTest(new BigInteger(3000), new BigInteger(2000));
			//Program.NaiveTimeTest(new BigInteger(300000), new BigInteger(200000));
			Program.NaiveTimeTest(new BigInteger(30000000), new BigInteger(20000000));
			//Program.NaiveTimeTest(new BigInteger(30000000), new BigInteger(0));
			//Program.NaiveTimeTest(new BigInteger(0), new BigInteger(30000000));

			//var data = Program.Generate(50, 4);
			//Program.Execute(data, Program.MultiplyViaOperation);
			//Program.Execute(data, Program.MultiplyViaAddition);
		}

		private static BigInteger[] Generate(int count, int maxSize)
		{
			var result = new BigInteger[count];
			var random = new Random();

			for(var i = 0; i < count; i++)
			{
				var data = new byte[random.Next(maxSize)];
				random.NextBytes(data);
				result[i] = new BigInteger(data);
			}

			return result;
		}

		private static void Execute(BigInteger[] values, 
			Func<BigInteger, BigInteger, BigInteger> f)
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			Program.result = f(new BigInteger(200), new BigInteger(300));

			var operationTime = new Stopwatch();

			for(var i = 0; i < values.Length / 2; i++)
			{
				var a = values[i];
				var b = values[i + 1];
				operationTime.Start();
				Program.result = f(a, b);
				operationTime.Stop();
			}

			Console.Out.WriteLine($"Execute time: {operationTime.Elapsed}");
		}

		private static void NaiveTimeTest(BigInteger a, BigInteger b)
		{
			var operationTime = Stopwatch.StartNew();

			Program.MultiplyViaOperation(a, b);

			operationTime.Stop();

			Console.Out.WriteLine(
				$"NaiveTestTime.MultiplyViaOperation({a}, {b}) time: {operationTime.Elapsed}");

			var additionTime = Stopwatch.StartNew();

			Program.MultiplyViaAddition(a, b);

			additionTime.Stop();

			Console.Out.WriteLine(
				$"NaiveTestTime.MultiplyViaAddition({a}, {b}) time: {additionTime.Elapsed}");
		}

		private static void QuickTest()
		{
			Console.Out.WriteLine(
				$"346 * 27 : MultiplyViaOperation is {Program.MultiplyViaOperation(new BigInteger(346), new BigInteger(27))}");
			Console.Out.WriteLine(
				$"346 * 27 : MultiplyViaAddition is {Program.MultiplyViaAddition(new BigInteger(346), new BigInteger(27))}");

			Console.Out.WriteLine(
				$"-346 * 27 : MultiplyViaOperation is {Program.MultiplyViaOperation(new BigInteger(-346), new BigInteger(27))}");
			Console.Out.WriteLine(
				$"-346 * 27 : MultiplyViaAddition is {Program.MultiplyViaAddition(new BigInteger(-346), new BigInteger(27))}");

			Console.Out.WriteLine(
				$"346 * 27 : MultiplyViaOperation is {Program.MultiplyViaOperation(new BigInteger(346), new BigInteger(-27))}");
			Console.Out.WriteLine(
				$"346 * -27 : MultiplyViaAddition is {Program.MultiplyViaAddition(new BigInteger(346), new BigInteger(-27))}");

			Console.Out.WriteLine(
				$"-346 * -27 : MultiplyViaOperation is {Program.MultiplyViaOperation(new BigInteger(-346), new BigInteger(-27))}");
			Console.Out.WriteLine(
				$"-346 * -27 : MultiplyViaAddition is {Program.MultiplyViaAddition(new BigInteger(-346), new BigInteger(-27))}");
		}

		private static BigInteger MultiplyViaOperation(BigInteger a, BigInteger b)
		{
			return a * b;
		}

		private static BigInteger MultiplyViaAddition(BigInteger a, BigInteger b)
		{
			var result = BigInteger.Zero;

			var value = BigInteger.Abs(a);
			for (var i = BigInteger.Zero; i < BigInteger.Abs(b); i++)
			{
				result += value;
			}

			return a.Sign < 0 ^ b.Sign < 0 ? BigInteger.Negate(result) : result;
		}
	}
}
