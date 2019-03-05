namespace RefReturns
{
	// The real List<T> can be found here:
	// https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,cf7f4095e4de7646
	// This is GROSSLY simplified :).
	public sealed class SlowList<T>
	{
		private readonly T[] data;

		public SlowList(uint capacity) =>
			this.data = new T[capacity];

		public T this[int index]
		{
			get => this.data[index];
			set => this.data[index] = value;
		}
	}
}
