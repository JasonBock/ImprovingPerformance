using BenchmarkDotNet.Attributes;
using System.Reflection;

namespace UsingAttributes;

[MemoryDiagnoser]
public class FindingAttributes
{
	private static readonly Type[] types = typeof(Program).Assembly.GetTypes();

	[Benchmark]
	public int FindAttributeViaGetCustomAttributeData() =>
		FindingAttributes.types.Count(_ => _.GetCustomAttributes(false).Any(a => a is CustomAttribute));

	[Benchmark]
	public int FindAttributeViaGetCustomAttributes() =>
		FindingAttributes.types.Count(_ => _.GetCustomAttributesData().Any(a => a.AttributeType == typeof(CustomAttribute)));

	[Benchmark]
	public int FindAttributeViaGenericGetCustomAttributes() =>
		FindingAttributes.types.Count(_ => _.GetCustomAttributes<CustomAttribute>().Any());
}