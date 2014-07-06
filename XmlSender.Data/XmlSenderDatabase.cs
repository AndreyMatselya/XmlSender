using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlSender.Data.Entities;

namespace XmlSender.Data
{
	public class XmlSenderDatabase:DbContext
	{
		public XmlSenderDatabase()
            : base("DefaultConnection")
        {
        }

		//public DbSet<UserProfile> UserProfiles1 { get; set; }

	    public DbSet<Response> Responses { get; set; }
	}
}
