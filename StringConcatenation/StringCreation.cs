#if NET9_0_OR_GREATER
using System.Security.Cryptography;
#endif

namespace StringConcatenation;

internal static class StringCreation
{
	internal static string Create(int length)
	{
		var data = new char[length];

		for (var i = 0; i < length; i++)
		{
#if NET9_0_OR_GREATER
			data[i] = (char)RandomNumberGenerator.GetInt32(32, 127);
#else
			data[i] = (char)new Random().Next(32, 127);
#endif
		}

		return new string(data);
	}
}