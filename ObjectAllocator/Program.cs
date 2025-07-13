using ObjectAllocator;
using System.Security.Cryptography;

Console.WriteLine("ObjectAllocator");
Console.WriteLine();
Console.WriteLine("Press enter to generate a random object, or \"STOP\" to exit.");

var objects = new List<object>();

while (true)
{
	var command = Console.ReadLine();

	if (command == "STOP")
	{
		break;
	}
	else
	{
		var type = RandomNumberGenerator.GetInt32(3);

		if (type == 0)
		{
			objects.Add(new SmallObject());
			Console.WriteLine("Added small object.");
		}
		else if (type == 1)
		{
			objects.Add(new MediumObject());
			Console.WriteLine("Added medium object.");
		}
		else
		{
			objects.Add(new LargeObject());
			Console.WriteLine("Added large object.");
		}

		Console.WriteLine($"Current object count: {objects.Count}");
	}
}