namespace UsingAttributes;

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
	public sealed class CustomAttribute
		: Attribute
	{
		public CustomAttribute(string data, int value)
		{
			this.Data = data;
			this.Value = value;
		}

		public string Data { get; }
		public int Value { get; }
	}
