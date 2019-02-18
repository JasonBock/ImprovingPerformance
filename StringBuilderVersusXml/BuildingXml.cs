using BenchmarkDotNet.Attributes;
using System.Text;
using System.Xml.Linq;

namespace StringBuilderVersusXml
{
	[MemoryDiagnoser]
	[ClrJob, CoreJob]
	public class BuildingXml
	{
		[Benchmark]
		public string BuildViaStringBuilder()
		{
			// Note: the original code did not wrap the document with
			// a root node.
			var xml = new StringBuilder();
			// Yes, this should be a constant :)
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZOp", "ABC-CityMarket");
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZBatchID", 342);
			xml.AppendFormat("<{0}>{1}</{0}>", "AutoSubmit", true);
			xml.AppendFormat("<{0}>{1}</{0}>", "Delinked", false);
			return string.Format("<Root>{0}</Root>", xml.ToString());
		}

		[Benchmark]
		public string BuildViaXDocument()
		{
			return new XDocument(
				new XElement("Root", 
					new XElement("XYZOp", "ABC-CityMarket"),
					new XElement("XYZBatchID", 342),
					new XElement("AutoSubmit", true),
					new XElement("Delinked", false))).ToString();
		}

		[Benchmark]
		public string BuildViaStringBuilderAndXDocumentParsing()
		{
			// Note: the original code did not wrap the document with
			// a root node.
			var xml = new StringBuilder();
			// Yes, this should be a constant :)
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZOp", "ABC-CityMarket");
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZBatchID", 342);
			xml.AppendFormat("<{0}>{1}</{0}>", "AutoSubmit", true);
			xml.AppendFormat("<{0}>{1}</{0}>", "Delinked", false);
			return XDocument.Parse(string.Format("<Root>{0}</Root>", xml.ToString())).ToString();
		}
	}
}