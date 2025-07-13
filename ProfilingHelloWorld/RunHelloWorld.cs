using BenchmarkDotNet.Attributes;
using System.Diagnostics;

namespace ProfilingHelloWorld;

[Config(typeof(AntiVirusFriendlyConfiguration))]
[MemoryDiagnoser]
public class RunHelloWorld
{
	private readonly ProcessStartInfo startInfo = new(Shared.HelloWorldFile)
	{
		Arguments = "a b c",
		CreateNoWindow = true,
		UseShellExecute = true,
		WindowStyle = ProcessWindowStyle.Hidden
	};

	[Benchmark]
	public int Execute()
	{
		var process = Process.Start(this.startInfo)!;
		process.WaitForExit();
		return process.ExitCode;
	}
}
