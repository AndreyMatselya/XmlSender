using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using XmlSender.Soap.Header;

namespace XmlSender.Soap
{
	public class User
	{
		public bool IsAuthenticated { get; set; }

		public UsernameToken UserNameToken
		{
			get { return UsernameToken.Current; }
		}

		private static User _currentUser;

		public static User CurrentUser
		{
			get { return _currentUser ?? (_currentUser = new User()); }
		}
	}
}
