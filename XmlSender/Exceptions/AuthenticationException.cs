using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSender.Exceptions
{
	[Serializable]
	public class AuthenticationException : ApplicationException
	{
		public AuthenticationException()
			: base("Неверные имя пользователя/пароль.") { }

		public AuthenticationException(string message)
			: base(message) { }
	}
}
