using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using XmlSender.Common;
using XmlSender.Data;
using XmlSender.Soap;

namespace XmlSender
{
	public partial class MoreInformationForm : Form
	{
		public MoreInformationForm()
		{
			InitializeComponent();
		}

		private readonly Guid _xmlId;

		private readonly IList<DetailsRowGrid> _details; 

		public MoreInformationForm(Guid id):this()
		{
			_xmlId = id;
			_details = new List<DetailsRowGrid>();
		}

		private void MoreInformationForm_Load(object sender, EventArgs e)
		{
			var details = XmlSenderContext.Repositories.Responses.All.Include("Xml").Where(x => x.Xml.Id == _xmlId).OrderByDescending(x=>x.DateCreated);
			//var serializer = new XmlSerializer(typeof (WsError[]));
			foreach (var row in details)
			{
				_details.Add(new DetailsRowGrid(row));
			}
			this.dataGridView1.DataSource = _details;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var saveFileDialog1 = new SaveFileDialog
			{
				Filter = @"xml files (*.xml)|*.xml",
				RestoreDirectory = true
			};
			if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
			var xDoc = new XmlDocument();
			var srtXml = XmlHelper.Serialize(_details.ToList());
			xDoc.LoadXml(srtXml);
			xDoc.Save(saveFileDialog1.FileName);
		}
	}
}
