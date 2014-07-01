using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XmlSender.ServiceReference1;

namespace XmlSender
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var client = new ServiceReference1.GisunCommonWsImplClient();
			//client.getPersonIdentif();
			ServiceReference1.RequestData.Create
		}
	}
}
