namespace PropertyAssignment;

	public sealed class Intermediate
	{
		public Intermediate()
		{
			this.Child = new Child();
		}

		public Child Child { get; set; }
	}
