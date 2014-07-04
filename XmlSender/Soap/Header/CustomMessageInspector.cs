using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace XmlSender.Soap.Header
{
	public class CustomMessageInspector : IClientMessageInspector
	{
		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			var buffer = request.CreateBufferedCopy(Int32.MaxValue);
			request = buffer.CreateMessage();
			request.Headers.Add(UsernameToken.Current);
			return null;
		}

		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
		}

	}
}
