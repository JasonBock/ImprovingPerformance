using System;

namespace FindingIssuesWithCodeAnalysis
{
	// Correct
	[AttributeUsage(AttributeTargets.All)]
	public sealed class SealedAttribute
		: Attribute
	{ }

	// Incorrect
	//[AttributeUsage(AttributeTargets.All)]
	//public class UnsealedAttribute
	//	: Attribute
	//{ }
}
