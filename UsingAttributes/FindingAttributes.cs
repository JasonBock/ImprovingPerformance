using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace UsingAttributes
{
	public class FindingAttributes
	{
		[Benchmark]
		public void FindAttributeViaGetCustomAttributeData()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes(false).Any(a => a is CustomAttribute));
		}

		[Benchmark]
		public void FindAttributeViaGetCustomAttributes()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributesData().Any(a => a.AttributeType == typeof(CustomAttribute)));
		}

		[Benchmark]
		public void FindAttributeViaGenericGetCustomAttributes()
		{
			typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes<CustomAttribute>().Any());
		}
	}
}
