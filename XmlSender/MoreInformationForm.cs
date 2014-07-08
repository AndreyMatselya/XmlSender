using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using XmlSender.Common;
using XmlSender.Data;
using XmlSender.ServiceReference3;

namespace XmlSender
{
	public partial class MoreInformationForm : Form
	{
		public MoreInformationForm()
		{
			InitializeComponent();
		}

		private Guid _xmlId;

		private ICollection<DetailsRowGrid> _details; 

		public MoreInformationForm(Guid id):this()
		{
			_xmlId = id;
			_details = new Collection<DetailsRowGrid>();
		}

		private void MoreInformationForm_Load(object sender, EventArgs e)
		{
			var details = XmlSenderContext.Repositories.Responses.All.Where(x => x.Xml.Id == _xmlId).OrderByDescending(x=>x.DateCreated);
			//var serializer = new XmlSerializer(typeof (WsError[]));
			foreach (var detail in details)
			{
				var row = new DetailsRowGrid();
				row.XmlId = _xmlId;
				row.DateCreated = detail.DateCreated;
				row.Identif = detail.Identif;
				row.InsuranceAwardingDate = detail.InsuranceAwardingDate;
				row.InsuranceSuspensionDate = detail.InsuranceSuspensionDate;
				row.Success = detail.ErrorsCount == 0 ? "Да" : "Нет";
				row.Errors = detail.ErrorsText;
				_details.Add(row);
			}
			this.dataGridView1.DataSource = _details;
		}
	}
}
