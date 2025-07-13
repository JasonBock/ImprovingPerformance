namespace CopyArrays;

internal static class RuntimeArrayCopier<T>
{
	internal static T[] Copy(T[] source)
	{
		var result = new T[source.Length];
		Array.Copy(source, result, source.Length);
		return result;
	}
}