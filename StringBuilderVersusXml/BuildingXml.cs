using BenchmarkDotNet.Attributes;
using System.Text;
using System.Xml.Linq;

namespace StringBuilderVersusXml
{
	public class BuildingXml
	{
		[Benchmark]
		public string BuildViaStringBuilder()
		{
			var xml = new StringBuilder();
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZOp", "ABC-CityMarket");
			xml.AppendFormat("<{0}>{1}</{0}>", "XYZBatchID", 342);
			xml.AppendFormat("<{0}>{1}</{0}>", "AutoSubmit", true);
			xml.AppendFormat("<{0}>{1}</{0}>", "Delinked", false);
			return xml.ToString();
		}

		[Benchmark]
		public string BuildViaXDocument()
		{
			return new XDocument(
				new XElement("XYZOp", "ABC-CityMarket"),
				new XElement("XYZBatchID", 342),
				new XElement("AutoSubmit", true),
				new XElement("Delinked", false)).ToString();
		}
	}
}
