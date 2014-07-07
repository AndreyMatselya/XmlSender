using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlSender.Data.Repositories;

namespace XmlSender.Data
{
	public class XmlSenderContext:IXmlSenderContext
	{
		readonly XmlSenderDatabase _database;
		IResponseRepository _responses;

		public XmlSenderContext()
		{
			_database = new XmlSenderDatabase();
		}

		public IResponseRepository Responses
		{
			get { return _responses ?? (_responses = new ResponseRepository(_database)); }
		}

		private static XmlSenderContext _repositories;

		public static XmlSenderContext Repositories
		{
			get { return _repositories ?? (_repositories = new XmlSenderContext()); }
		}
	}
}
