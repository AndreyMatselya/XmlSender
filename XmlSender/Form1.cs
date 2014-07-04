using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using XmlSender.ServiceReference3;
using XmlSender.Soap;

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

		private void button1_Click(object sender, EventArgs e)
		{
			_soapClient.PostData(file.Items);
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

		private void selectFileButton_Click(object sender, EventArgs e)
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
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
		}

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
			var openFileDialog = ((OpenFileDialog) sender);
			selectFileButton.Visible = true;
			selectedFileLabel.Visible = true;
			selectedFilePathTextBox.Visible = true;
			selectedFilePathTextBox.Text = openFileDialog.FileName;

		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			var authForm = new AuthenticationForm();
			this.ActivateMdiChild(authForm);
			authForm.ShowDialog();
		}

		public void Authenticate()
		{
			_soapClient.Authenticate();
		}

	}












}
