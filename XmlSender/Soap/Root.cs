using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XmlSender.ServiceReference3;

namespace XmlSender.Soap
{
	[XmlRoot(ElementName = "root")]
	public class Root
	{
		[XmlElement("insurance_data_request", typeof(insurance_data_request), Namespace = "http://gisun.agatsystem.by/insurance/types/")]
		public List<insurance_data_request> Items { get; set; }
	}
}
