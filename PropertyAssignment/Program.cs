using System;
using System.Diagnostics;
using System.Security.Principal;
using Spackle;
using StackExchange.Profiling;

namespace PropertyAssignment
{
	class Program
	{
		private const int Iterations = 10000000;
		private const int MaximumRuns = 7;
		private const string SetValuesDirectlyLabel = "SetValuesDirectly";
		private const string SetValuesDirectlyViaTemporaryObjectLabel = "SetValuesDirectlyViaTemporaryObject";

		static void Main(string[] args)
		{
			Program.ProfileUsingPropertyValuesFromObject();
		}

		private static Root CreateRoot()
		{
			var generator = new RandomObjectGenerator();
			var root = new Root();
			root.Intermediate.Child.GuidValue0 = generator.Generate<Guid>();
			root.Intermediate.Child.GuidValue1 = generator.Generate<Guid>();
			root.Intermediate.Child.GuidValue2 = generator.Generate<Guid>();
			root.Intermediate.Child.GuidValue3 = generator.Generate<Guid>();
			root.Intermediate.Child.GuidValue4 = generator.Generate<Guid>();
			root.Intermediate.Child.IntValue0 = generator.Generate<int>();
			root.Intermediate.Child.IntValue1 = generator.Generate<int>();
			root.Intermediate.Child.IntValue2 = generator.Generate<int>();
			root.Intermediate.Child.IntValue3 = generator.Generate<int>();
			root.Intermediate.Child.IntValue4 = generator.Generate<int>();
			root.Intermediate.Child.StringValue0 = generator.Generate<string>();
			root.Intermediate.Child.StringValue1 = generator.Generate<string>();
			root.Intermediate.Child.StringValue2 = generator.Generate<string>();
			root.Intermediate.Child.StringValue3 = generator.Generate<string>();
			root.Intermediate.Child.StringValue4 = generator.Generate<string>();
			root.Intermediate.Child.UriValue0 = generator.Generate<Uri>();
			root.Intermediate.Child.UriValue1 = generator.Generate<Uri>();
			root.Intermediate.Child.UriValue2 = generator.Generate<Uri>();
			root.Intermediate.Child.UriValue3 = generator.Generate<Uri>();
			root.Intermediate.Child.UriValue4 = generator.Generate<Uri>();
			return root;
		}

		private static void ProfileUsingPropertyValuesFromObject()
		{
			ProgramState.CheckProgramState();

			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.Collect();

			var root = Program.CreateRoot();

			Program.SetValuesDirectly(root);
			Program.SetValuesDirectlyViaTemporaryObject(root);

			var profiler = new MiniProfiler(Process.GetCurrentProcess().ProcessName);
			profiler.User = WindowsIdentity.GetCurrent().Name;

			Program.Profile(root, profiler);
			Program.DisplayStatistics(profiler);
		}

		private static void DisplayStatistics(MiniProfiler profiler)
		{
			var setValuesDirectlyTotalTime = 0m;
			var setValuesDirectlyViaTemporaryObjectTotalTime = 0m;

			foreach (var timing in profiler.GetTimingHierarchy())
			{
				if (timing.Name == Program.SetValuesDirectlyLabel)
				{
					Console.Out.WriteLine(timing.Name + " - " + timing.DurationMilliseconds + "ms");
					setValuesDirectlyTotalTime += timing.DurationMilliseconds.Value;
				}
				else if (timing.Name == Program.SetValuesDirectlyViaTemporaryObjectLabel)
				{
					Console.Out.WriteLine(timing.Name + " - " + timing.DurationMilliseconds + "ms");
					setValuesDirectlyViaTemporaryObjectTotalTime += timing.DurationMilliseconds.Value;
				}
			}

			const string numberFormat = "#0.####";

			Console.Out.WriteLine();

			Console.Out.WriteLine(SetValuesDirectlyLabel + " Total time: " +
				setValuesDirectlyTotalTime.ToString(numberFormat) + "ms");
			Console.Out.WriteLine(SetValuesDirectlyViaTemporaryObjectLabel + " Total time: " +
				setValuesDirectlyViaTemporaryObjectTotalTime.ToString(numberFormat) + "ms");

			Console.Out.WriteLine(SetValuesDirectlyLabel + " Average: " +
				(setValuesDirectlyTotalTime / MaximumRuns).ToString(numberFormat) + "ms");
			Console.Out.WriteLine(SetValuesDirectlyViaTemporaryObjectLabel + " Average: " +
				(setValuesDirectlyViaTemporaryObjectTotalTime / MaximumRuns).ToString(numberFormat) + "ms");

			Console.Out.WriteLine("Difference: " +
				((setValuesDirectlyTotalTime - setValuesDirectlyViaTemporaryObjectTotalTime) / setValuesDirectlyViaTemporaryObjectTotalTime).ToString("#0.####%"));
			Console.ReadLine();
		}

		private static void Profile(Root root, MiniProfiler profiler)
		{
			var setValuesDirectlyRemainingRuns = 0;
			var setValuesDirectlyViaTemporaryObjectRemainingRuns = 0;
			var random = new SecureRandom();

			while (setValuesDirectlyRemainingRuns < Program.MaximumRuns ||
				setValuesDirectlyViaTemporaryObjectRemainingRuns < Program.MaximumRuns)
			{
				if (random.NextBoolean() && setValuesDirectlyRemainingRuns < Program.MaximumRuns)
				{
					using (profiler.Step(Program.SetValuesDirectlyLabel))
					{
						for (var i = 0; i < Program.Iterations; i++)
						{
							Program.SetValuesDirectly(root);
						}
					}

					setValuesDirectlyRemainingRuns++;
				}
				else if (setValuesDirectlyViaTemporaryObjectRemainingRuns < Program.MaximumRuns)
				{
					using (profiler.Step(Program.SetValuesDirectlyViaTemporaryObjectLabel))
					{
						for (var i = 0; i < Program.Iterations; i++)
						{
							Program.SetValuesDirectlyViaTemporaryObject(root);
						}
					}

					setValuesDirectlyViaTemporaryObjectRemainingRuns++;
				}
			}
		}

		private static void SetValuesDirectlyViaTemporaryObject(Root source)
		{
			var root = new Root();
			var child = root.Intermediate.Child;
			child.GuidValue0 = source.Intermediate.Child.GuidValue0;
			child.GuidValue1 = source.Intermediate.Child.GuidValue1;
			child.GuidValue2 = source.Intermediate.Child.GuidValue2;
			child.GuidValue3 = source.Intermediate.Child.GuidValue3;
			child.GuidValue4 = source.Intermediate.Child.GuidValue4;
			child.IntValue0 = source.Intermediate.Child.IntValue0;
			child.IntValue1 = source.Intermediate.Child.IntValue1;
			child.IntValue2 = source.Intermediate.Child.IntValue2;
			child.IntValue3 = source.Intermediate.Child.IntValue3;
			child.IntValue4 = source.Intermediate.Child.IntValue3;
			child.StringValue0 = source.Intermediate.Child.StringValue0;
			child.StringValue1 = source.Intermediate.Child.StringValue1;
			child.StringValue2 = source.Intermediate.Child.StringValue2;
			child.StringValue3 = source.Intermediate.Child.StringValue3;
			child.StringValue4 = source.Intermediate.Child.StringValue4;
			child.UriValue0 = source.Intermediate.Child.UriValue0;
			child.UriValue1 = source.Intermediate.Child.UriValue1;
			child.UriValue2 = source.Intermediate.Child.UriValue2;
			child.UriValue3 = source.Intermediate.Child.UriValue3;
			child.UriValue4 = source.Intermediate.Child.UriValue4;
		}

		private static void SetValuesDirectly(Root source)
		{
			var root = new Root();
			root.Intermediate.Child.GuidValue0 = source.Intermediate.Child.GuidValue0;
			root.Intermediate.Child.GuidValue1 = source.Intermediate.Child.GuidValue1;
			root.Intermediate.Child.GuidValue2 = source.Intermediate.Child.GuidValue2;
			root.Intermediate.Child.GuidValue3 = source.Intermediate.Child.GuidValue3;
			root.Intermediate.Child.GuidValue4 = source.Intermediate.Child.GuidValue4;
			root.Intermediate.Child.IntValue0 = source.Intermediate.Child.IntValue0;
			root.Intermediate.Child.IntValue1 = source.Intermediate.Child.IntValue1;
			root.Intermediate.Child.IntValue2 = source.Intermediate.Child.IntValue2;
			root.Intermediate.Child.IntValue3 = source.Intermediate.Child.IntValue3;
			root.Intermediate.Child.IntValue4 = source.Intermediate.Child.IntValue3;
			root.Intermediate.Child.StringValue0 = source.Intermediate.Child.StringValue0;
			root.Intermediate.Child.StringValue1 = source.Intermediate.Child.StringValue1;
			root.Intermediate.Child.StringValue2 = source.Intermediate.Child.StringValue2;
			root.Intermediate.Child.StringValue3 = source.Intermediate.Child.StringValue3;
			root.Intermediate.Child.StringValue4 = source.Intermediate.Child.StringValue4;
			root.Intermediate.Child.UriValue0 = source.Intermediate.Child.UriValue0;
			root.Intermediate.Child.UriValue1 = source.Intermediate.Child.UriValue1;
			root.Intermediate.Child.UriValue2 = source.Intermediate.Child.UriValue2;
			root.Intermediate.Child.UriValue3 = source.Intermediate.Child.UriValue3;
			root.Intermediate.Child.UriValue4 = source.Intermediate.Child.UriValue4;
		}
	}
}
