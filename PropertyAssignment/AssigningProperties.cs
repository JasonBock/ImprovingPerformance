using BenchmarkDotNet.Attributes;
using System.Security.Cryptography;

namespace PropertyAssignment;

[MemoryDiagnoser]
public class AssigningProperties
{
	private Root? root;

	[GlobalSetup]
	public void Setup()
	{
		var root = new Root();

		root.Intermediate.Child.GuidValue0 = Guid.NewGuid();
		root.Intermediate.Child.GuidValue1 = Guid.NewGuid();
		root.Intermediate.Child.GuidValue2 = Guid.NewGuid();
		root.Intermediate.Child.GuidValue3 = Guid.NewGuid();
		root.Intermediate.Child.GuidValue4 = Guid.NewGuid();
		root.Intermediate.Child.IntValue0 = RandomNumberGenerator.GetInt32(int.MaxValue);
		root.Intermediate.Child.IntValue1 = RandomNumberGenerator.GetInt32(int.MaxValue);
		root.Intermediate.Child.IntValue2 = RandomNumberGenerator.GetInt32(int.MaxValue);
		root.Intermediate.Child.IntValue3 = RandomNumberGenerator.GetInt32(int.MaxValue);
		root.Intermediate.Child.IntValue4 = RandomNumberGenerator.GetInt32(int.MaxValue);
		root.Intermediate.Child.StringValue0 = Guid.NewGuid().ToString();
		root.Intermediate.Child.StringValue1 = Guid.NewGuid().ToString();
		root.Intermediate.Child.StringValue2 = Guid.NewGuid().ToString();
		root.Intermediate.Child.StringValue3 = Guid.NewGuid().ToString();
		root.Intermediate.Child.StringValue4 = Guid.NewGuid().ToString();
		root.Intermediate.Child.UriValue0 = new Uri("https://localhost.com");
		root.Intermediate.Child.UriValue1 = new Uri("https://localhost.com");
		root.Intermediate.Child.UriValue2 = new Uri("https://localhost.com");
		root.Intermediate.Child.UriValue3 = new Uri("https://localhost.com");
		root.Intermediate.Child.UriValue4 = new Uri("https://localhost.com");
		this.root = root;
	}

	[Benchmark]
	public Root SetValuesDirectlyViaTemporaryObject()
	{
		var source = this.root!;
		var root = new Root();
		var child = root.Intermediate.Child;
		var sourceChild = source.Intermediate.Child;
		child.GuidValue0 = sourceChild.GuidValue0;
		child.GuidValue1 = sourceChild.GuidValue1;
		child.GuidValue2 = sourceChild.GuidValue2;
		child.GuidValue3 = sourceChild.GuidValue3;
		child.GuidValue4 = sourceChild.GuidValue4;
		child.IntValue0 = sourceChild.IntValue0;
		child.IntValue1 = sourceChild.IntValue1;
		child.IntValue2 = sourceChild.IntValue2;
		child.IntValue3 = sourceChild.IntValue3;
		child.IntValue4 = sourceChild.IntValue4;
		child.StringValue0 = sourceChild.StringValue0;
		child.StringValue1 = sourceChild.StringValue1;
		child.StringValue2 = sourceChild.StringValue2;
		child.StringValue3 = sourceChild.StringValue3;
		child.StringValue4 = sourceChild.StringValue4;
		child.UriValue0 = sourceChild.UriValue0;
		child.UriValue1 = sourceChild.UriValue1;
		child.UriValue2 = sourceChild.UriValue2;
		child.UriValue3 = sourceChild.UriValue3;
		child.UriValue4 = sourceChild.UriValue4;

		return root;
	}

	[Benchmark]
	public Root SetValuesDirectly()
	{
		var source = this.root!;
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
		root.Intermediate.Child.IntValue4 = source.Intermediate.Child.IntValue4;
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

		return root;
	}
}