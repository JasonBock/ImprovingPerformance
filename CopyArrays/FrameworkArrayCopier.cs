using System;

namespace CopyArrays
{
	public sealed class FrameworkArrayCopier<T>
		: ArrayCopier<T>
	{
		public override void Copy(T[] source)
		{
			this.Content = new T[source.Length];
			Array.Copy(source, this.Content, source.Length);
		}
	}
}
