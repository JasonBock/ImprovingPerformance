using CopyArrays;
using System.Security.Cryptography;

const int SleepTime = 500;

var bufferSize = new int[] { 5, 50, 500, 5_000, 50_000, 500_000 };

for (var i = 0; i < bufferSize.Length; i++)
{
	Console.WriteLine($"Buffer size: {bufferSize[i]}");
	Console.WriteLine();

	var buffer = RandomNumberGenerator.GetBytes(bufferSize[i]);

	Console.WriteLine("RuntimeArrayCopier - before Copy()");
	RuntimeArrayCopier<byte>.Copy(buffer);
	Console.WriteLine("RuntimeArrayCopier - after Copy()");
	Console.WriteLine();
	Thread.Sleep(SleepTime);

	Console.WriteLine("ManualArrayCopier - before Copy()");
	ManualArrayCopier<byte>.Copy(buffer);
	Console.WriteLine("ManualArrayCopier - after Copy()");
	Console.WriteLine();
	Thread.Sleep(SleepTime);
}