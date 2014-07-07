using XmlSender.Data.Repositories;

namespace XmlSender.Data
{
	public interface IXmlSenderContext
	{
		IResponseRepository Responses { get; }

		IXmlRepository Xmls { get; }
	}
}
