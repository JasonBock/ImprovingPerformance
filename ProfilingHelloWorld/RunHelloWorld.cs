using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace ProfilingHelloWorld
{
	[MemoryDiagnoser]
	public class RunHelloWorld
	{
		private readonly ProcessStartInfo startInfo = new ProcessStartInfo(Program.HelloWorldFile)
		{
			Arguments = "a b c",
			CreateNoWindow = true,
			WindowStyle = ProcessWindowStyle.Hidden
		};

		[Benchmark]
		public int Execute()
		{
			var process = Process.Start(this.startInfo);
			process.WaitForExit();
			return process.ExitCode;
		}
	}
}
