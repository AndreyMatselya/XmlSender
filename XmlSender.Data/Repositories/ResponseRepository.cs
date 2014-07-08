using System.Linq;
using XmlSender.Data.Entities;

namespace XmlSender.Data.Repositories
{
	public class ResponseRepository : IResponseRepository
	{
		private readonly XmlSenderDatabase _context;

		public ResponseRepository(XmlSenderDatabase db)
		{
			_context = db;
		}

		public void Insert(Response response)
		{
			_context.Responses.Add(response);
			_context.SaveChanges();
		}

		public IQueryable<Response> All
		{
			get { return _context.Responses; }
		}
	}

	public interface IResponseRepository
	{
		void Insert(Response response);

		IQueryable<Response> All { get; }
	}
}
