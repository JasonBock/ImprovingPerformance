namespace FindingIssuesWithCodeAnalysis;

public sealed class InstanceMemberThatShouldBeStatic
{
	// Correct
	public static int RetrieveValue() => 42;

	// Incorrect
	//public int RetrieveValue() => 42;
}