using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlSender.Soap.Header;

namespace XmlSender
{
	public partial class AuthenticationForm : Form
	{
		public AuthenticationForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			UsernameToken.Current.Username = loginTextBox.Text;
			UsernameToken.Current.Password = passwordTextBox.Text;
			var form1 = (Form1)Application.OpenForms["Form1"];
			form1.Authenticate();
		}
	}
}
