using Microsoft.Diagnostics.Runtime;
using System;
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
											select new
											{
												Name = addressGroup.Key.Name,
												Size = size,
												Count = addressGroup.Count()
											};
							foreach (var item in stats)
							{
								Console.Out.WriteLine(
									$"{item.Size,12:n0} {item.Count,12:n0} {item.Name}");
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
	}
}
