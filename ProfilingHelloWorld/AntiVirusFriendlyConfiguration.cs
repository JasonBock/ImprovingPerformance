using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

namespace ProfilingHelloWorld;

public sealed class AntiVirusFriendlyConfiguration 
	: ManualConfig
{
	public AntiVirusFriendlyConfiguration() => 
		this.AddJob(Job.MediumRun.WithToolchain(InProcessNoEmitToolchain.Instance));
}