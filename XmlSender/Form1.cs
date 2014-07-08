using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XmlSender.Data;
using XmlSender.Data.Entities;
using XmlSender.ServiceReference3;
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
					WsReturnCode soapResponse;
					var idr = _file.Items[i];
					try
					{
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
						_backgroundWorker.ReportProgress((100 * (i + 1)) / _file.Items.Count, string.Format("{0}/{1}", i + 1, _file.Items.Count));
					}
					try
					{
						var response = new Response
						{
							DateCreated = DateTime.Now,
							Errors = Serialize(soapResponse.error_list),
							Cover = Serialize(soapResponse.cover),
							Identif = idr.insurance_info.person_data.identif,
							ErrorsCount = soapResponse.error_list.Count(),
							InsuranceAwardingDate = idr.insurance_info.insurance_data.insurance_awarding_date,
							InsuranceSuspensionDate = idr.insurance_info.insurance_data.insurance_suspension_date
						};
						if (!soapResponse.error_list.Any())
						{
							withoutErrorsCount++;
						}
						xmlEntity.Description = string.Format("Всего в документе:{0}. Отправлено:{1}. Загружено:{2}", _file.Items.Count, i + 1, withoutErrorsCount);
						XmlSenderContext.Repositories.Xmls.AddResponse(xmlEntity, response);//.Insert(response);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					finally
					{
						_backgroundWorker.ReportProgress((100 * (i + 1)) / _file.Items.Count, string.Format("{0}/{1}", i + 1, _file.Items.Count));
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

		private void Form1_Load(object sender, EventArgs e)
		{
			//var col1 = new DataGridViewTextBoxColumn {DataPropertyName = "Id", HeaderText = "Id", Name = "Id"};
			//dataGridView1.Columns.Add(col1);
			//var col2 = new DataGridViewTextBoxColumn { DataPropertyName = "SendDate", HeaderText = "Дата отправки", Name = "SendDate" };
			//dataGridView1.Columns.Add(col2);
			//var col3 = new DataGridViewTextBoxColumn { DataPropertyName = "UserName", HeaderText = "пользователь", Name = "UserName" };
			//dataGridView1.Columns.Add(col3);
			//var col4 = new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = "апыа", Name = "Description" };
			//dataGridView1.Columns.Add(col4);
			dataGridView1.DataSource = XmlSenderContext.Repositories.Xmls.All.Select(x => new XmlRowGrid
			{
				Id = x.Id,
				Description = x.Description,
				SendDate = x.SendDate,
				UserName = x.UserName
			}).ToList();
			//this.dataGridView1.DataSource = new List<string[]>() { , new[] { "123123", "12313", "12312" } };
		}

		public class XmlRowGrid
		{
			public Guid Id { get; set; }

			public DateTime SendDate { get; set; }

			public string UserName { get; set; }

			public string Description { get; set; }
		}
	}












}
