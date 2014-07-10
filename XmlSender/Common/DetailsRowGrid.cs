using System;
using System.IO;
using System.Xml.Serialization;
using XmlSender.Data.Entities;
using WsError = XmlSender.ServiceReference1.WsError;

namespace XmlSender.Common
{
	public class DetailsRowGrid
	{
		public Guid XmlId { get; set; }

		public DateTime DateCreated { get; set; }

		public string ParentMessageId { get; set; }

		public string Success{ get; set; }

		public byte SuccessId { get; set; }

		[XmlIgnore]
		public string ErrorsText { get; set; }

		[XmlArray("Errors")]
		[XmlArrayItem("Error")]
		public WsError[] Errors { get; set; }

		public DetailsRowGrid() { }

		public DetailsRowGrid(Response response)
		{
			XmlId = response.Xml.Id;
			DateCreated = response.DateCreated;
			ParentMessageId = response.ParentMessageId;
			Success = response.ErrorsCount == 0 ? "Да" : "Нет";
			ErrorsText = response.ErrorsText;
			SuccessId = response.ErrorsCount == 0 ? (byte) 0 : (byte) 1;
			if (string.IsNullOrEmpty(response.ErrorsXml)) return;
			var serializer = new XmlSerializer(typeof(WsError[]));
			using (var stringReader = new StringReader(response.ErrorsXml))
			{
				Errors = (WsError[])serializer.Deserialize(stringReader);
			}
		}
	}
}
