using System;

namespace CopyArrays
{
	public sealed class ManualArrayCopier<T>
		: ArrayCopier<T>
	{
		// For all that is good in the world, DON'T repeat this! :)
		public override void Copy(T[] source)
		{
			this.Content = new T[0];

			foreach(var item in source)
			{
				var holder = new T[this.Content.Length + 1];
				this.Content.CopyTo(holder, 0);
				holder[this.Content.Length] = item;
				this.Content = holder;
			}
		}
	}
}
