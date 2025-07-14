using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;

namespace UsingUnsafeAs;

[MemoryDiagnoser]
[DisassemblyDiagnoser]
public class CastingObjects
{
	private readonly object data = new TargetType();

	[Benchmark]
	public TargetType CastUsingCSharp() => (TargetType)this.data;

	// https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.unsafe.as
	[Benchmark]
	public TargetType CastUsingUnsafeAs() => Unsafe.As<TargetType>(this.data);

	[Benchmark]
	public TargetType CastUsingFastCastAs() => FastCast.As<TargetType>(this.data);
}