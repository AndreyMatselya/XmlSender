using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security.Tokens;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using XmlSender.ServiceReference1;
using XmlSender.ServiceReference3;
using Message = System.ServiceModel.Channels.Message;

namespace XmlSender
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//var list = new List<insurance_data_request>();
			//list.Add(new insurance_data_request()
			//{
			//	cover = new ServiceReference3.MessageCover() { message_source = new ServiceReference3.Classifier() }
			//});
			//var ser = new XmlSerializer(typeof(List<insurance_data_request>));
			//using (var writer = XmlWriter.Create("filex.xml"))
			//{
			//	ser.Serialize(writer,list);
			//}
		}

		private List<insurance_data_request> file;

		private void button1_Click(object sender, EventArgs e)
		{


			var client = new ServiceReference3.InsuranceWSClient("InsuranceWS");
			MessageHeader.CreateHeader("dfg", "sdfg", new { dsfgs = "dfg" });

			//using (new OperationContextScope(client.InnerChannel))
			//{

			//	// We will use a custom class called UserInfo to be passed in as a MessageHeader





			//	// Add a SOAP Header to an outgoing request

			//	var aMessageHeader = MessageHeader.CreateHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", header);

			//	OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);



			//}
			var response = client.postInsuranceData(new insurance_data_request()
			{
				cover = new ServiceReference3.MessageCover()
				{
					message_id = Guid.NewGuid().ToString(),
					message_time = DateTime.Now
				}
			});
		}


		private void fileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Stream myStream = null;


			var openFileDialog1 = new OpenFileDialog();

			//openFileDialog1.InitialDirectory = "c:\\";
			openFileDialog1.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog1.FilterIndex = 1;
			openFileDialog1.RestoreDirectory = true;

			//if (openFileDialog1.ShowDialog() == DialogResult.OK)
			//{
			//	try
			//	{
			//		if ((myStream = openFileDialog1.OpenFile()) != null)
			//		{
			//			using (myStream)
			//			{
			//				var serializer = new XmlSerializer(typeof(List<insurance_data_request>), new XmlRootAttribute("root"));
			//				serializer.UnknownElement += serializer_UnknownElement;
			//				file = (List<insurance_data_request>)serializer.Deserialize(myStream);
			//			}
			//		}
			//	}
			//	catch (Exception ex)
			//	{
			//		MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
			//	}
			//}

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((myStream = openFileDialog1.OpenFile()) != null)
					{
						using (myStream)
						{
							var serializer = new XmlSerializer(typeof(Root));
							serializer.UnknownElement += serializer_UnknownElement;
							var file1 = (Root)serializer.Deserialize(myStream);
							using (var writer = XmlWriter.Create("root1.xml"))
							{
								serializer.Serialize(writer, file1);
							}
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
				}
			}
		}

		void serializer_UnknownElement(object sender, XmlElementEventArgs e)
		{
			var t = e.Element;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			//var root = new Root();
			//root.Items = new List<InsuranceDataRequest>();
			//root.Items.Add(new InsuranceDataRequest() { Identif = "123123", LastName = "Андрей" });
			//root.Items.Add(new InsuranceDataRequest() { Identif = "423423424", LastName = "Валера" });
			//var ser = new XmlSerializer(typeof(Root));
			//using (var writer = XmlWriter.Create("root.xml"))
			//{
			//	ser.Serialize(writer, root);
			//}
		}
	}



	public class UsernameToken : MessageHeader
	{
		public string Username
		{
			get
			{
				return FUsername;
			}
			set
			{
				FUsername = value;
			}
		}
		public string Password
		{
			get
			{
				return FPassword;
			}
			set
			{
				FPassword = value;
			}
		}
		private string FUsername = String.Empty;
		private string FPassword = String.Empty;

		public override bool MustUnderstand
		{
			get { return true; }
		}

		public override string Name
		{
			get { return "Security"; }
		}

		public override string Namespace
		{
			get { return "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"; }
		}

		protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
		{
			writer.WriteStartElement("UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
			writer.WriteAttributeString("Id", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd", "UsernameToken-1");

			writer.WriteElementString("Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", this.Username);
			writer.WriteStartElement("Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
			writer.WriteAttributeString("Type", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText");
			writer.WriteValue(this.Password);
			writer.WriteEndElement();
			writer.WriteEndElement();
		}
	}

	public class CustomMessageInspector : IClientMessageInspector
	{
		public object BeforeSendRequest(ref Message request, IClientChannel channel)
		{
			var header = new UsernameToken()
			{
				Username = "dimex",
				Password = "q"
			};
			
			MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
			request = buffer.CreateMessage();
			request.Headers.Add(header);
			return null;
		}

		public void AfterReceiveReply(ref Message reply, object correlationState)
		{
			//throw new NotImplementedException();
		}

	}

	[AttributeUsage(AttributeTargets.Class)]
	public class CustomBehavior : Attribute, IEndpointBehavior
	{
		#region IEndpointBehavior Members

		public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
		{
			CustomMessageInspector inspector = new CustomMessageInspector();
			clientRuntime.MessageInspectors.Add(inspector);
		}

		public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
		{
			//ChannelDispatcher channelDispatcher = endpointDispatcher.ChannelDispatcher;
			//if (channelDispatcher != null)
			//{
			//	foreach (EndpointDispatcher ed in channelDispatcher.Endpoints)
			//	{
			//		CustomMessageInspector inspector = new CustomMessageInspector();
			//		ed.DispatchRuntime.MessageInspectors.Add(inspector);
			//	}
			//}
		}

		public void Validate(ServiceEndpoint endpoint)
		{
		}

		#endregion
	}

	public class CustomBehaviorExtensionElement : BehaviorExtensionElement
	{
		protected override object CreateBehavior()
		{
			return new CustomBehavior();
		}

		public override Type BehaviorType
		{
			get
			{
				return typeof(CustomBehavior);
			}
		}
	} 


}
