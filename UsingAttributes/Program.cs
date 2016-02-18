using System;
using System.Diagnostics;
using System.Security.Principal;
using Spackle;
using StackExchange.Profiling;
using System.Linq;
using System.Reflection;

namespace UsingAttributes
{
	class Program
	{
		private const int Iterations = 1000000;
		private const int MaximumRuns = 10;

		static void Main(string[] args)
		{
			Program.Profile();
		}

		private static void Profile()
		{
			Console.Out.WriteLine(typeof(Program).FullName);
			ProgramState.CheckProgramState();

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			Program.FindAttributeViaGetCustomAttributes();
			Program.FindAttributeViaGetCustomAttributeData();
			Program.FindAttributeViaGenericGetCustomAttributes();

			var profiler = new MiniProfiler(Process.GetCurrentProcess().ProcessName);
			profiler.User = WindowsIdentity.GetCurrent().Name;

			Program.Profile(profiler);
			Program.DisplayStatistics(profiler);
		}

		private static void DisplayStatistics(MiniProfiler profiler)
		{
			var findAttributeViaGetCustomAttributesTotalTime = 0m;
			var findAttributeViaGetCustomAttributeDataTotalTime = 0m;
			var findAttributeViaGenericGetCustomAttributesTotalTime = 0m;

			foreach (var timing in profiler.GetTimingHierarchy())
			{
				if (timing.Name == nameof(Program.FindAttributeViaGetCustomAttributes))
				{
					Console.Out.WriteLine($"{timing.Name} - {timing.DurationMilliseconds}ms");
					findAttributeViaGetCustomAttributesTotalTime += timing.DurationMilliseconds.Value;
				}
				else if (timing.Name == nameof(Program.FindAttributeViaGetCustomAttributeData))
				{
					Console.Out.WriteLine($"{timing.Name} - {timing.DurationMilliseconds}ms");
					findAttributeViaGetCustomAttributeDataTotalTime += timing.DurationMilliseconds.Value;
				}
				else if (timing.Name == nameof(Program.FindAttributeViaGenericGetCustomAttributes))
				{
					Console.Out.WriteLine($"{timing.Name} - {timing.DurationMilliseconds}ms");
					findAttributeViaGenericGetCustomAttributesTotalTime += timing.DurationMilliseconds.Value;
				}
			}

			const string numberFormat = "#0.###########";
			var totalIterations = Program.Iterations * Program.MaximumRuns;

			Console.Out.WriteLine();

			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGetCustomAttributes)} Total time: {findAttributeViaGetCustomAttributesTotalTime.ToString(numberFormat)}ms");
			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGetCustomAttributeData)} Total time: {findAttributeViaGetCustomAttributeDataTotalTime.ToString(numberFormat)}ms");
			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGenericGetCustomAttributes)} Total time: {findAttributeViaGenericGetCustomAttributesTotalTime.ToString(numberFormat)}ms");

			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGetCustomAttributes)} Average: {(findAttributeViaGetCustomAttributesTotalTime / totalIterations).ToString(numberFormat)}ms");
			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGetCustomAttributeData)} Average: {(findAttributeViaGetCustomAttributeDataTotalTime / totalIterations).ToString(numberFormat)}ms");
			Console.Out.WriteLine(
				$"{nameof(Program.FindAttributeViaGenericGetCustomAttributes)} Average: {(findAttributeViaGenericGetCustomAttributesTotalTime/ totalIterations).ToString(numberFormat)}ms");

			Console.Out.WriteLine(
				$"Difference (GetCustomAttributeData): {((findAttributeViaGetCustomAttributesTotalTime - findAttributeViaGetCustomAttributeDataTotalTime) / findAttributeViaGetCustomAttributeDataTotalTime).ToString("#0.####%")}");
			Console.Out.WriteLine(
				$"Difference (GenericGetCustomAttributes): {((findAttributeViaGetCustomAttributesTotalTime - findAttributeViaGenericGetCustomAttributesTotalTime) / findAttributeViaGenericGetCustomAttributesTotalTime).ToString("#0.####%")}");
			Console.ReadLine();
		}

		private static void Profile(MiniProfiler profiler)
		{
			var findAttributeViaGetCustomAttributesRemainingRuns = 0;
			var findAttributeViaGetCustomAttributeDataRemainingRuns = 0;
			var findAttributeViaGenericGetCustomAttributeDataRemainingRuns = 0;
			var random = new SecureRandom();

			while (findAttributeViaGetCustomAttributesRemainingRuns < Program.MaximumRuns ||
				findAttributeViaGetCustomAttributeDataRemainingRuns < Program.MaximumRuns ||
				findAttributeViaGenericGetCustomAttributeDataRemainingRuns < Program.MaximumRuns)
			{
				var value = random.Next(3);

				if (value == 0 && findAttributeViaGetCustomAttributesRemainingRuns < Program.MaximumRuns)
				{
					using (profiler.Step(nameof(Program.FindAttributeViaGetCustomAttributes)))
					{
						for (var i = 0; i < Program.Iterations; i++)
						{
							Program.FindAttributeViaGetCustomAttributes();
						}
					}

					findAttributeViaGetCustomAttributesRemainingRuns++;
				}
				else if (value == 1 && findAttributeViaGetCustomAttributeDataRemainingRuns < Program.MaximumRuns)
				{
					using (profiler.Step(nameof(Program.FindAttributeViaGetCustomAttributeData)))
					{
						for (var i = 0; i < Program.Iterations; i++)
						{
							Program.FindAttributeViaGetCustomAttributeData();
						}
					}

					findAttributeViaGetCustomAttributeDataRemainingRuns++;
				}
				else if (value == 2 && findAttributeViaGenericGetCustomAttributeDataRemainingRuns < Program.MaximumRuns)
				{
					using (profiler.Step(nameof(Program.FindAttributeViaGenericGetCustomAttributes)))
					{
						for (var i = 0; i < Program.Iterations; i++)
						{
							Program.FindAttributeViaGenericGetCustomAttributes();
						}
					}

					findAttributeViaGenericGetCustomAttributeDataRemainingRuns++;
				}
			}
		}

		private static void FindAttributeViaGetCustomAttributeData()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes(false).Any(a => a is CustomAttribute));
		}

		private static void FindAttributeViaGetCustomAttributes()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributesData().Any(a => a.AttributeType == typeof(CustomAttribute)));
		}

		private static void FindAttributeViaGenericGetCustomAttributes()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes<CustomAttribute>().Any());
		}
	}
}
