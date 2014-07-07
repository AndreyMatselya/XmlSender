using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlSender.Data.Entities;

namespace XmlSender.Data.Repositories
{
	public class XmlRepository : IXmlRepository
	{
		private readonly XmlSenderDatabase _context;

		public Xml Insert(Xml xml)
		{
			_context.Xmls.Add(xml);
			_context.SaveChanges();
			return xml;
		}

		public IQueryable<Xml> All
		{
			get { return _context.Xmls.Include("Responses"); }
			
		}

		public void AddResponse(Xml xml, Response response)
		{
			if (xml.Responses == null)
			{
				xml.Responses = new Collection<Response>();
			}
			xml.Responses.Add(response);
			_context.SaveChanges();
			//return xml;
		}

		public XmlRepository(XmlSenderDatabase db)
		{
			_context = db;
		}
	}

	public interface IXmlRepository
	{
		Xml Insert(Xml xml);
		IQueryable<Xml> All { get; }
		void AddResponse(Xml xml, Response response);
	}
}
