using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UsingAttributes
{
	public class FindingAttributes
	{
		[Benchmark]
		public IEnumerable<Type> FindAttributeViaGetCustomAttributeData()
		{
			return typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes(false).Any(a => a is CustomAttribute));
		}

		[Benchmark]
		public IEnumerable<Type> FindAttributeViaGetCustomAttributes()
		{
			return typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributesData().Any(a => a.AttributeType == typeof(CustomAttribute)));
		}

		[Benchmark]
		public IEnumerable<Type> FindAttributeViaGenericGetCustomAttributes()
		{
			return typeof(Program).Assembly.GetTypes().Where(
				_ => _.GetCustomAttributes<CustomAttribute>().Any());
		}
	}
}
