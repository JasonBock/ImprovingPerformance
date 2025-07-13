using Microsoft.Diagnostics.Runtime;
using System.Diagnostics;

Console.WriteLine("ObjectAllocator.Watcher");
Console.WriteLine();
Console.WriteLine("Press enter to run statistics, or \"STOP\" to exit.");

while (true)
{
	var command = Console.ReadLine();

	if (command == "STOP")
	{
		break;
	}
	else
	{
		var processes = Process.GetProcessesByName("ObjectAllocator");

		if (processes.Length > 0)
		{
			var processId = processes[0].Id;

			using var dataTarget = DataTarget.AttachToProcess(processId, false);
			var version = dataTarget.ClrVersions[0];
			var runtime = version.CreateRuntime();
			var heap = runtime.Heap;

			var stats = from addresses in heap.EnumerateObjects()
							let type = heap.GetObjectType(addresses)
							group addresses by type into addressGroup
							let size = addressGroup.Sum(_ => (uint)addressGroup.Key.StaticSize)
							orderby size descending
							select new Stats(addressGroup.Key.Name ?? "Unknown", size, addressGroup.Count());

			var top10 = 0;
			var targetStats = new List<Stats>();

			Console.WriteLine("Top 10 objects");
			foreach (var stat in stats)
			{
				if (top10 < 10)
				{
					Console.WriteLine($"{stat.Size,12:n0} {stat.Count,12:n0} {stat.Name}");
					top10++;
				}

				if (stat.Name.StartsWith("ObjectAllocator", StringComparison.OrdinalIgnoreCase))
				{
					targetStats.Add(stat);
				}
			}

			Console.WriteLine("------------------------");
			Console.WriteLine("ObjectAllocator objects");

			foreach (var stat in targetStats)
			{
				Console.WriteLine(
					$"{stat.Size,12:n0} {stat.Count,12:n0} {stat.Name}");
			}
		}
		else
		{
			Console.WriteLine("Couldn't find a running instance of ObjectAllocator.");
		}
	}
}

internal sealed record Stats(string Name, long Size, int Count);