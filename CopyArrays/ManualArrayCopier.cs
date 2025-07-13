namespace CopyArrays;

internal static class ManualArrayCopier<T>
{
	// For all that is good in the world, DON'T repeat this! :)
	internal static T[] Copy(T[] source)
	{
		var result = Array.Empty<T>();

		foreach (var item in source)
		{
			var holder = new T[result.Length + 1];
			result.CopyTo(holder, 0);
			holder[result.Length] = item;
			result = holder;
		}

		return result;
	}
}