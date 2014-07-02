using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlSender.ServiceReference3;

namespace XmlSender
{
	public class InsuranceDataRequest
	{
		[XmlElement(Namespace = "http://gisun.agatsystem.by/common/types/", ElementName = "identif")]
		public string Identif { get; set; }

		[XmlElement(Namespace = "http://gisun.agatsystem.by/common/types/", ElementName = "last_name")]
		public string LastName { get; set; }
	}

	[XmlRoot(ElementName = "root")]
	public class Root
	{
		[XmlElement("insurance_data_request", typeof(insurance_data_request), Namespace = "http://gisun.agatsystem.by/insurance/types/")]
		public List<insurance_data_request> Items { get; set; }
	}
}
