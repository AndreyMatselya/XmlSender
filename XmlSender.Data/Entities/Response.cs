using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Data.Entities
{
	[Table("Response")]
    public class Response
    {
		public long Id { get; set; }

		public string Cover { get; set; }

		public string Errors { get; set; }

		public DateTime DateCreated { get; set; }

		public string Identif { get; set; }

		public Xml Xml { get; set; }

		public DateTime InsuranceAwardingDate { get; set; }

		public string InsuranceSuspensionDate { get; set; }

		public int ErrorsCount { get; set; }

		public string ErrorsText { get; set; }
    }
}
