using System;
using System.Linq;
using XmlSender.Attributes;

namespace XmlSender.Extensions
{
	public static class EnumExtensions
	{
		public static string GetDescription(this Enum enumMember, int index = 0)
		{
			if (enumMember == null)
				return null;

			if (enumMember.GetType().GetField(enumMember.ToString()).IsDefined(typeof(DescriptionAttribute), false))
			{
				return
					(enumMember.GetType().GetField(enumMember.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false)[0]
					 as DescriptionAttribute).Descriptions.Skip(index).FirstOrDefault() ?? enumMember.ToString();
			}

			return enumMember.ToString();
		}
	}
}
