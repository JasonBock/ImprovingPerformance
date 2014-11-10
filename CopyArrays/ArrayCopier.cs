using System.Collections.Generic;

namespace CopyArrays
{
	public abstract class ArrayCopier<T>
	{
		public abstract void Copy(T[] source);
		public T[] Content { get; protected set; }
	}
}
