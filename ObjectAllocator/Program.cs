using Spackle;
using System;
using System.Collections.Generic;

namespace ObjectAllocator
{
	class Program
	{
		static void Main()
		{
			Console.Out.WriteLine("Press enter to generate a random object, or \"STOP\" to exit.");

			var objects = new List<object>();
			var random = new SecureRandom();

			while(true)
			{
				var command = Console.In.ReadLine();

				if(command == "STOP")
				{
					break;
				}
				else
				{
					var type = random.Next(3);

					if(type == 0)
					{
						objects.Add(new SmallObject());
					}
					else if(type == 1)
					{
						objects.Add(new MediumObject());
					}
					else
					{
						objects.Add(new LargeObject());
					}

					Console.Out.WriteLine($"Current object count: {objects.Count}");
				}
			}
		}
	}
}
