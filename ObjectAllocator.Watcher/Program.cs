using Microsoft.Diagnostics.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ObjectAllocator.Watcher
{
	class Program
	{
		static void Main()
		{
			Console.Out.WriteLine("Press enter to run statistics, or \"STOP\" to exit.");

			while (true)
			{
				var command = Console.In.ReadLine();

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

						using (var dataTarget = DataTarget.AttachToProcess(
							processId, (uint)TimeSpan.FromSeconds(5d).Milliseconds, AttachFlag.NonInvasive))
						{
							var version = dataTarget.ClrVersions[0];
							var runtime = version.CreateRuntime();
							var heap = runtime.GetHeap();

							var stats = from addresses in heap.EnumerateObjectAddresses()
											let type = heap.GetObjectType(addresses)
											group addresses by type into addressGroup
											let size = addressGroup.Sum(_ => (uint)addressGroup.Key.GetSize(_))
											orderby size descending
											select new Stats(addressGroup.Key.Name, size, addressGroup.Count());

							var top10 = 0;
							var targetStats = new List<Stats>();

							Console.Out.WriteLine("Top 10 objects");
							foreach (var stat in stats)
							{
								if (top10 < 10)
								{
									Console.Out.WriteLine(
										$"{stat.Size,12:n0} {stat.Count,12:n0} {stat.Name}");
									top10++;
								}

								if (stat.Name.StartsWith("ObjectAllocator"))
								{
									targetStats.Add(stat);
								}
							}

							Console.Out.WriteLine("------------------------");
							Console.Out.WriteLine("ObjectAllocator objects");

							foreach (var stat in targetStats)
							{
								Console.Out.WriteLine(
									$"{stat.Size,12:n0} {stat.Count,12:n0} {stat.Name}");
							}
						}
					}
					else
					{
						Console.Out.WriteLine("Couldn't find a running instance of ObjectAllocator.");
					}
				}
			}
		}

		private sealed class Stats
		{
			public string Name { get; }
			public long Size { get; }
			public int Count { get; }

			public Stats(string name, long size, int count)
			{
				this.Name = name;
				this.Size = size;
				this.Count = count;
			}
		}
	}
}
