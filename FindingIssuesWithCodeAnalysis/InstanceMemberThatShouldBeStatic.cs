namespace FindingIssuesWithCodeAnalysis
{
	public sealed class InstanceMemberThatShouldBeStatic
	{
		// Correct
		public static int GetStaticValue() => 42;

		// Incorrect
		//public int GetInstanceValue() => 42;
	}
}
