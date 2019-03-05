namespace RefReturns
{
	// The real List<T> can be found here:
	// https://referencesource.microsoft.com/#mscorlib/system/collections/generic/list.cs,cf7f4095e4de7646
	// This is GROSSLY simplified :).
	public sealed class FastList<T>
	{
		private readonly T[] data;

		public FastList(uint capacity) =>
			this.data = new T[capacity];

		public ref T this[int index] => ref this.data[index];
	}
}
