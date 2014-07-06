using System;
using System.ComponentModel;
using System.IO;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XmlSender.Data;
using XmlSender.Data.Entities;
using XmlSender.ServiceReference3;
using XmlSender.Soap;
using XmlSender.Soap.Header;

namespace XmlSender
{
	public partial class Form1 : Form
	{
		private Root file;
		private SoapClient _soapClient;


		public Form1()
		{
			InitializeComponent();
			_soapClient = new SoapClient();
		}

		private BackgroundWorker backgroundWorker;

		private void button1_Click(object sender, EventArgs e)
		{
			backgroundWorker = new BackgroundWorker {WorkerReportsProgress = true};
			backgroundWorker.DoWork += backgroundWorker_DoWork;
			backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
			backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
			backgroundWorker.RunWorkerAsync();
			SwitchControlsAtTimePostData(false);
			//MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
		}

		void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			toolStripProgressBar1.Value = e.ProgressPercentage;
			toolStripStatusLabel1.Text = e.UserState as String;
			//MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString(), "изменение");
		}

		void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
			SwitchControlsAtTimePostData(true);
			MessageBox.Show("Отправка данных завершена", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
			using (_soapClient)
			{
				for (var i = 0; i < file.Items.Count; i++)
				{
					WsReturnCode soapResponse;
					try
					{

						var idr = file.Items[i];
						soapResponse = _soapClient.PostData(idr);
						//MessageBox.Show(Thread.CurrentThread.ManagedThreadId.ToString());
					}
					catch (Exception ex)
					{
						//TODO Подумать что делать при ошибке...
						MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						continue;
					}
					finally
					{
						backgroundWorker.ReportProgress((100 * (i + 1)) / file.Items.Count, string.Format("{0}/{1}", i + 1, file.Items.Count));
					}
					try
					{
						var response = new Response();
						response.XmlId = xmlId;
						response.DateCreated = DateTime.Now;
						response.UserName = User.CurrentUser.UserNameToken.Username;
						response.Errors = Serialize(soapResponse.error_list);
						response.Cover = Serialize(soapResponse.cover);
						XmlSenderContext.Repositories.Responses.Insert(response);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						backgroundWorker.ReportProgress((100 * (i + 1)) / file.Items.Count, string.Format("{0}/{1}", i + 1, file.Items.Count));
					}
				}
			}
		}

		private string Serialize<T>(T obj)
		{
			var serializer = new XmlSerializer(typeof(T));
			var sb = new StringBuilder();
			using (var writer = XmlWriter.Create(sb))
			{
				serializer.Serialize(writer, obj);
			}
			return sb.ToString();
		}

		void serializer_UnknownElement(object sender, XmlElementEventArgs e)
		{
			MessageBox.Show(
				string.Format("Ошибка при чтении документа. Неизвестный элемент: {0}. Строка: {1}", e.Element.Name,
					e.LineNumber), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			file = null;
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
						file = (Root)serializer.Deserialize(myStream);
						this.postButton.Enabled = true;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.postButton.Enabled = false;
				}
			}
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var openFileDialog = ((OpenFileDialog) sender);
			openFileButton.Visible = true;
			selectedFileLabel.Visible = true;
			selectedFilePathTextBox.Visible = true;
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
			MessageBox.Show("История операций не реализована", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}












}
