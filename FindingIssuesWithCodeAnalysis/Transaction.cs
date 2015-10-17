using System;

namespace FindingIssuesWithCodeAnalysis
{
	public sealed class Transaction
		: IDisposable
	{
		public void Dispose() { }
		public void Commit() { }
		public void Rollback() { }
	}
}
