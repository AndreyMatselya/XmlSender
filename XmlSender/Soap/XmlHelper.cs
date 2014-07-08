using System;
using XmlSender.ServiceReference3;

namespace XmlSender.Soap
{
	public static class XmlHelper
	{
		public  static void CheckIRD(insurance_data_request idr)
		{
			if (idr.cover == null)
			{
				throw new Exception("Пустой элемент /insurance_data_request/cover.");
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
	}
}
