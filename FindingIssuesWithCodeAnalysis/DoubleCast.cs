namespace FindingIssuesWithCodeAnalysis
{
	public static class DoubleCast
	{
		public static string CastItTwice(object x)
		{
			// Incorrect code:
			if (x is string)
			{
				return x as string;
			}
			else
			{
				return string.Empty;
			}

			// Correct code:
			//return x as string ?? string.Empty;
		}
	}
}
