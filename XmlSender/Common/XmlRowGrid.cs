using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Common
{
	public class XmlRowGrid
	{
		public Guid Id { get; set; }

		public DateTime SendDate { get; set; }

		public string UserName { get; set; }

		public string Description { get; set; }
	}
}
