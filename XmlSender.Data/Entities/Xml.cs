using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Data.Entities
{
	[Table("Xml")]
	public class Xml
	{
		[Key]
		public Guid Id { get; set; }

		public DateTime SendDate{ get; set; }

		public string UserName{ get; set; }

		public string XmlBody{ get; set; }

		public string Description{ get; set; }

		public ICollection<Response> Responses { get; set; }
	}
}
