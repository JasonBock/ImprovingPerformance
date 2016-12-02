using System.Collections.ObjectModel;

namespace FindingIssuesWithCodeAnalysis
{
	public sealed class UsesTransaction
	{
		public void SaveItems(ReadOnlyCollection<string> items)
		{
			foreach (var item in items)
			{
				// Incorrect code:
				var transaction = new Transaction();
				try
				{
					// Do expensive work with item...
					transaction.Commit();
				}
				catch
				{
					transaction.Rollback();
					throw;
				}

				// Correct code:
				//using (var transaction = new Transaction())
				//{
				//	try
				//	{
				//		// Do expensive work with item...
				//		transaction.Commit();
				//	}
				//	catch
				//	{
				//		transaction.Rollback();
				//		throw;
				//	}
				//}
			}
		}
	}
}
