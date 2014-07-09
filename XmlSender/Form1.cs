using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Windows.Forms;
using System.Xml.Serialization;
using XmlSender.Common;
using XmlSender.Data;
using XmlSender.Data.Entities;
using XmlSender.Soap;

namespace XmlSender
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			_soapClient = new SoapClient();
		}

		private Root _file;
		//private string _xmlFile;
		private readonly SoapClient _soapClient;
		private BackgroundWorker _backgroundWorker;

		private void button1_Click(object sender, EventArgs e)
		{
			_backgroundWorker = new BackgroundWorker {WorkerReportsProgress = true};
			_backgroundWorker.DoWork += backgroundWorker_DoWork;
			_backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
			_backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
			_backgroundWorker.RunWorkerAsync();
			SwitchControlsAtTimePostData(false);
			//MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
		}

		void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar1.Value = e.ProgressPercentage;
			toolStripStatusLabel1.Text = e.UserState as String;
		}

		void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				MessageBox.Show("Отправка данных завершена", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			SwitchControlsAtTimePostData(true);
		}

		void SwitchControlsAtTimePostData(bool flag)
		{
			this.postButton.Enabled = flag;
			this.openToolStripMenuItem.Enabled = flag;
			this.openFileButton.Enabled = flag;
		}

		private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var xmlId = Guid.NewGuid();
			string xmlContent;
			using (var objReader = new StreamReader(this.selectedFilePathTextBox.Text))
			{
				xmlContent = objReader.ReadToEnd();
			}
			var xmlEntity = XmlSenderContext.Repositories.Xmls.Insert(new Xml()
			{
				SendDate = DateTime.Now,
				Id = xmlId,
				UserName = User.CurrentUser.UserNameToken.Username,
				XmlBody = xmlContent
			});
			using (_soapClient)
			{
				var withoutErrorsCount = 0;
				for (var i = 0; i < _file.Items.Count; i++)
				{
					var idr = _file.Items[i];
					try
					{
						XmlHelper.CheckIRD(idr, i + 1);
						var soapResponse = _soapClient.PostData(idr);
						var response = new Response
						{
							DateCreated = DateTime.Now,
							Errors = soapResponse.error_list == null ? null : XmlHelper.Serialize(soapResponse.error_list),
							Cover = XmlHelper.Serialize(soapResponse.cover),
							ErrorsCount = soapResponse.error_list == null ? 0 : soapResponse.error_list.Count(),
							ParentMessageId = idr.cover.parent_message_id,
							ErrorsText = soapResponse.error_list == null ? string.Empty : soapResponse.error_list.Aggregate(string.Empty, (current, error) => current + string.Format("{0} - {1}. ", error.error_code.code, error.description))
						};
						if (soapResponse.error_list == null || !soapResponse.error_list.Any())
						{
							withoutErrorsCount++;
						}
						xmlEntity.Description = string.Format("Всего в документе: {0}. Отправлено: {1}. Загружено: {2}", _file.Items.Count,
							i + 1, withoutErrorsCount);
						XmlSenderContext.Repositories.Xmls.AddResponse(xmlEntity, response);
					}
					finally
					{
						_backgroundWorker.ReportProgress((100*(i + 1))/_file.Items.Count,
							string.Format("{0}/{1}", i + 1, _file.Items.Count));
					}
				}
			}
		}

		void serializer_UnknownElement(object sender, XmlElementEventArgs e)
		{
			MessageBox.Show(
				string.Format("Ошибка при чтении документа. Неизвестный элемент: {0}. Строка: {1}", e.Element.Name,
					e.LineNumber), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			_file = null;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowOpenFileDialog();
		}

		private void openFileButton_Click(object sender, EventArgs e)
		{
			ShowOpenFileDialog();
		}

		private void ShowOpenFileDialog()
		{
			openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.FileOk += openFileDialog1_FileOk;
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					var myStream = openFileDialog1.OpenFile();

					using (myStream)
					{
						var serializer = new XmlSerializer(typeof(Root));
						serializer.UnknownElement += serializer_UnknownElement;
						_file = (Root)serializer.Deserialize(myStream);
						this.postButton.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message + " " + (ex.InnerException != null ? ex.InnerException.Message : string.Empty), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.postButton.Enabled = false;
				}
			}
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var openFileDialog = ((OpenFileDialog) sender);
			SwitchVisibleOpenFileControls(true);
			this.dataGridView1.Visible = false;
			selectedFilePathTextBox.Text = openFileDialog.FileName;

		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			var authForm = new AuthenticationForm();
			authForm.ShowDialog();
		}

		public void Authenticate()
		{
			try
			{
				using (_soapClient)
				{
					_soapClient.Authenticate();
				}
				var form2 = (AuthenticationForm)Application.OpenForms["AuthenticationForm"];
				form2.Close();
			}
			catch (AuthenticationException ex)
			{
				MessageBox.Show(ex.Message, "Ошибка аутентификации!", MessageBoxButtons.OK, MessageBoxIcon.Error);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void протоколToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.postButton.Enabled = false;
			_backgroundWorker = new BackgroundWorker ();
			_backgroundWorker.DoWork += backgroundWorker_GetXmlData;
			_backgroundWorker.RunWorkerCompleted += backgroundWorker_GetXmlDataCompleted;
			_backgroundWorker.RunWorkerAsync();
			SwitchVisibleOpenFileControls(false);
			this.dataGridView1.Visible = true;
		}

		private void backgroundWorker_GetXmlDataCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.dataGridView1.DataSource = _xmlDataSource;
		}

		private IEnumerable<XmlRowGrid> _xmlDataSource;

		private void backgroundWorker_GetXmlData(object sender, DoWorkEventArgs e)
		{
			_xmlDataSource = XmlSenderContext.Repositories.Xmls.All.OrderByDescending(x => x.SendDate).Select(x => new XmlRowGrid
			{
				Id = x.Id,
				Description = x.Description,
				SendDate = x.SendDate,
				UserName = x.UserName
			}).ToList();
		}

		private void SwitchVisibleOpenFileControls(bool flag)
		{
			this.selectedFilePathTextBox.Visible = flag;
			this.openFileButton.Visible = flag;
			this.selectedFileLabel.Visible = flag;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			var id = (Guid) this.dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
			var moreInfForm = new MoreInformationForm(id);
			moreInfForm.ShowDialog();
		}
	}
}
