using System;

namespace ObjectAllocator
{
	public sealed class MediumObject
	{
		public MediumObject()
		{
			this.Data = Guid.NewGuid().ToString("N");
		}

		public string Data { get; }
	}
}
