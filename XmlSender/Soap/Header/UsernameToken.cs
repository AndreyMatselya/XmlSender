using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlSender.Soap.Header
{
	public class UsernameToken : MessageHeader
	{
		public string Username { get; set; }
		public string Password { get; set; }

		private UsernameToken()
		{ }

		private static UsernameToken _current;

		public static UsernameToken Current
		{
			get { return _current ?? (_current = new UsernameToken()); }
		}

		public override bool MustUnderstand
		{
			get { return true; }
		}

		public override string Name
		{
			get { return "Security"; }
		}

		public override string Namespace
		{
			get { return Constants.WssecuritySecextNamespace; }
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement("UsernameToken", Constants.WssecuritySecextNamespace);
			writer.WriteAttributeString("Id", Constants.WssecurityUtilityNamespace, "UsernameToken-1");
			writer.WriteElementString("Username", Constants.WssecuritySecextNamespace, this.Username);
			writer.WriteStartElement("Password", Constants.WssecuritySecextNamespace);
			writer.WriteAttributeString("Type", Constants.UserNameTokenProfileType);
			writer.WriteValue(this.Password);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}
}
