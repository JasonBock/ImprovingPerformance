﻿namespace FindingIssuesWithCodeAnalysis;

internal static class LiteralViolations
{
	// Correct
	//const int IsConstant = 3;

	// Incorrect
	//static readonly int ShouldBeConstant = 3;
}
