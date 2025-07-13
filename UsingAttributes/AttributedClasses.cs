namespace UsingAttributes;

	[Custom("a", 1)]
	public sealed class HasAttribute1 { }

	public sealed class DoesNotHaveAttribute1 { }

	[Custom("b", 2)]
	public sealed class HasAttribute2 { }

	public sealed class DoesNotHaveAttribute2 { }

	[Custom("c", 3)]
	public sealed class HasAttribute3 { }

	public sealed class DoesNotHaveAttribute3 { }

	[Custom("d", 4)]
	public sealed class HasAttribute4 { }

	public sealed class DoesNotHaveAttribute4 { }
