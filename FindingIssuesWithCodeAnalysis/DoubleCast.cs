namespace FindingIssuesWithCodeAnalysis
{
	public static class DoubleCast
	{
		public static void CastItTwice(object x)
		{
			if(x is string)
			{
				var y = x as string;
			}
		}
	}
}
