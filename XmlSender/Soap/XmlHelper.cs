using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XmlSender.ServiceReference3;

namespace XmlSender.Soap
{
	public static class XmlHelper
	{
		public  static void CheckIRD(insurance_data_request idr, int counter)
		{
			if (idr.cover == null)
			{
				throw new Exception(string.Format("Пустой элемент /insurance_data_request/cover. ({0} элемент <insurance_data_request/>)", counter));
			}
			if (idr.insurance_info == null)
			{
				throw new Exception(string.Format("Пустой элемент /insurance_data_request/insurance_info. (message_id={0})", idr.cover.message_id));
			}
			if (idr.insurance_info.insurance_data == null)
			{
				throw new Exception(string.Format("Пустой элемент /insurance_data_request/insurance_info/insurance_data. (message_id={0})", idr.cover.message_id));
			}
			if (idr.insurance_info.insurance_document == null)
			{
				throw new Exception(string.Format("Пустой элемент /insurance_data_request/insurance_info/insurance_document. (message_id={0})", idr.cover.message_id));
			}
			if (idr.insurance_info.person_data == null)
			{
				throw new Exception(string.Format("Пустой элемент /insurance_data_request/insurance_info/person_data. (message_id={0})", idr.cover.message_id));
			}
		}

		public  static string Serialize<T>(T obj)
		{
			var serializer = new XmlSerializer(typeof(T));
			var sb = new StringBuilder();
			using (var writer = XmlWriter.Create(sb))
			{
				serializer.Serialize(writer, obj);
			}
			return sb.ToString();
		}
	}
}
