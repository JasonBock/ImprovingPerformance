namespace PropertyAssignment;

	public sealed class Root
	{
		public Root()
		{
			this.Intermediate = new Intermediate();
		}

		public Intermediate Intermediate { get; set; }
	}
