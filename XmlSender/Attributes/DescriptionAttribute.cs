using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Attributes
{
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
	public sealed class DescriptionAttribute : Attribute
	{
		private readonly string[] _descriptions;

		public DescriptionAttribute(string description)
		{
			_descriptions = new[] { description };
		}

		public DescriptionAttribute(params string[] descriptions)
		{
			_descriptions = descriptions;
		}

		public IEnumerable<string> Descriptions
		{
			get { return _descriptions; }
		}
	}
}
