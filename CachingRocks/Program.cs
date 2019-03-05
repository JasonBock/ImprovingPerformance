using Rocks;
using Rocks.Options;
using System;

namespace CachingRocks
{
	class Program
	{
		private const int iterations = 1000000;

		static void Main() =>
			Program.CreateMocks(CachingOptions.GenerateNewVersion);

		private static void CreateMocks(CachingOptions caching)
		{
			for(var i = 0; i < Program.iterations; i++)
			{
				var rock = Rock.Create<IService>(
					options: new RockOptions(caching: caching));
				rock.Handle(_ => _.Use());
				var chunk = rock.Make();
				chunk.Use();
				rock.Verify();

				if(i % 1000 == 0) { Console.Out.WriteLine(i); }
			}
		}
	}
}
