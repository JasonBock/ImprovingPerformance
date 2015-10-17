using System;
using System.Diagnostics;
using System.Reflection;
using Spackle.Extensions;

namespace UsingAttributes
{
	// Lifted from:
	// https://gist.github.com/mattwarren/69070616cf0efbb68a79#file-benchmarking-cs-L344
	public static class ProgramState
	{
		public static void CheckProgramState()
		{
			var debugAttribute = Assembly.GetExecutingAssembly().GetCustomAttribute<DebuggableAttribute>();

			if (debugAttribute != null && debugAttribute.IsJITOptimizerDisabled)
			{
				ProgramState.Log(ConsoleColor.Red, 
					$"JIT Optimizer DISABLED\n\tIsJITOptimizerDisabled: {debugAttribute.IsJITOptimizerDisabled}, IsJITTrackingEnabled: {debugAttribute.IsJITTrackingEnabled}");
			}
			else if (debugAttribute != null && !debugAttribute.IsJITOptimizerDisabled)
			{
				ProgramState.Log(ConsoleColor.Green,
					$"JIT Optimizer ENABLED\n\tIsJITOptimizerDisabled: {debugAttribute.IsJITOptimizerDisabled}, IsJITTrackingEnabled: {debugAttribute.IsJITTrackingEnabled}");
			}
			else 
			{
				ProgramState.Log(ConsoleColor.White, "JIT Optimizer UNKNOWN");
			}

#if DEBUG
			ProgramState.Log(ConsoleColor.Red, "Running a DEBUG Build");
#else
			ProgramState.Log(ConsoleColor.Green, "Running a RELEASE build");
#endif

			ProgramState.Log(ConsoleColor.Green, $"Application is {(Environment.Is64BitProcess ? "64" : "32")}-bit");

			if(Debugger.IsAttached)
			{
				ProgramState.Log(ConsoleColor.Red, "Debugger is attached");
			}
			else
			{
				ProgramState.Log(ConsoleColor.Green, "Debugger is not attached");
			}

			Console.WriteLine();
		}

		private static void Log(ConsoleColor colour, string text)
		{
			using(colour.Bind(() => Console.ForegroundColor))
			{
				Console.Out.WriteLine(text);
			}
		}
	}
}
