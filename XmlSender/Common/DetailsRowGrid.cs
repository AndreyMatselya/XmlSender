using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Common
{
	public class DetailsRowGrid
	{
		public Guid XmlId { get; set; }

		public DateTime DateCreated { get; set; }

		public string Identif{ get; set; }

		public DateTime InsuranceAwardingDate { get; set; }

		public string InsuranceSuspensionDate { get; set; }

		public string Success{ get; set; }

		public string Errors{ get; set; }
	}
}
