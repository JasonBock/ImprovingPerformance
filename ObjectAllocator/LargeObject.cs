namespace ObjectAllocator
{
	public sealed class LargeObject
	{
		private readonly int[] data;

		public LargeObject()
		{
			this.data = new int[10000];
		}
	}
}
