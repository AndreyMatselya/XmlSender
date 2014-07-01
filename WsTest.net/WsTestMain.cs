using System;
using System.Windows.Forms;
using System.IO;
using CommonWsItf;
using SecHeader;
namespace WsTestMain
{
    public partial class TForm1: Form
    {
        private GisunCommonWsImpl FService = null;
        public TForm1()
        {
            InitializeComponent();
        }

        public void FormCreate(System.Object Sender, System.EventArgs _e1)
        {
            edURL.Text = "http://vm6-03:8080/gisun/common/ws";
        }

        public void FormDestroy(Object Sender)
        {
            FService = null;
        }

        private GisunCommonWsImpl GetService()
        {
            GisunCommonWsImpl result;
            if (FService == null)
            {
                FService = CommonWsItf.Units.CommonWsItf.GetGisunCommonWsImpl(false, edURL.Text, HTTPRIO);
                //@ Unsupported property or method(C): 'HTTPWebNode'
                //@ Unsupported property or method(D): 'Proxy'
                HTTPRIO.HTTPWebNode.Proxy = edProxy.Text;
                //@ Unsupported property or method(C): 'Service'
                HTTPRIO.Service = "GisunCommonWs";
                //@ Unsupported property or method(C): 'Port'
                HTTPRIO.Port = "ws";
            }
            result = FService;
            return result;
        }

        public void HTTPRIOAfterExecute(string MethodName, Stream SOAPResponse)
        {
            TJvXMLTree xmlRes;
            //@ Unsupported function or procedure: 'null'
            xmlRes = new TJvXMLTree("", null, null);
            try {
                SOAPResponse.Seek(0, SeekOrigin.Begin);
                //@ Unsupported property or method(A): 'LoadFromStream'
                xmlRes.LoadFromStream(SOAPResponse);
                //@ Unsupported property or method(A): 'ParseXML'
                xmlRes.ParseXML();
                //@ Unsupported property or method(C): 'Text'
                //@ Unsupported property or method(C): 'Text'
                edResponse.Lines.Text = xmlRes.Text;
            } finally {
                //@ Unsupported property or method(A): 'Free'
                xmlRes.Free();
            }
        }

        public void HTTPRIOBeforeExecute(string MethodName, ref string SOAPRequest)
        {
            //@ Unsupported property or method(C): 'Text'
            edRequest.Lines.Text = SOAPRequest;
        }

        public Classifier btnGenIdentifClick_GetClassifier(string code)
        {
            Classifier result;
            result = new Classifier();
            result.code = code;
            return result;
        }

        public void btnGenIdentifClick(System.Object Sender, System.EventArgs _e1)
        {
            GisunCommonWsImpl svc;
            register_request r;
            PersonRequest pd;
            IdentifRequest id;
            MessageCover c;
            RegisterResponse rr;
            string d;
            Guid g;
            value[] l;
            PersonRequest[] lpr;
            IdentifRequest[] lir;
            int i;
            int j;
            TSOAPHeader hdr;
            ISOAPHeaders Headers;
            svc = GetService();
            r = new register_request();
            r.request = new RequestData();
            // Заголовок сообщения
            c = new MessageCover();
            //@ Unsupported function or procedure: 'CReateGUID'
            CReateGUID(g);
            c.message_id = g.ToString();
            c.message_type = btnGenIdentifClick_GetClassifier("0300");
            c.message_type.type_ = 82;
            c.message_time = new TXSDateTime();
            //@ Unsupported property or method(C): 'AsDateTime'
            c.message_time.AsDateTime = DateTime.Now;
            c.message_source = btnGenIdentifClick_GetClassifier("17120");
            c.message_source.type_ = 80;
            r.cover = c;
            // Запрос на получение персональных данных
            lpr = new PersonRequest[1];
            pd = new PersonRequest();
            //@ Unsupported function or procedure: 'CReateGUID'
            CReateGUID(g);
            pd.request_id = g.ToString();
            pd.identif_number = "7454115A001PB8";
            lpr[0] = pd;
            r.request.person_request = lpr;
            // SetLength(lir, 2);
            // // Запрос на генерацию идентификационного номера
            // id := IdentifRequest.Create();
            // CReateGUID(g);
            // id.request_id := GUIDToString(g);
            // id.sex := GetClassifier(edSex1.Text);
            // DateTimeToString(d, 'yyyyMMdd', edBirthDay1.Date);
            // id.birth_day := d;
            // lir[0] := id;
            // // Запрос на генерацию идентификационного номера
            // id := IdentifRequest.Create();
            // CReateGUID(g);
            // id.request_id := GUIDToString(g);
            // id.sex := GetClassifier(edSex2.Text);
            // DateTimeToString(d, 'yyyyMMdd', edBirthDay2.Date);
            // id.birth_day := d;
            // lir[1] := id;
            // r.request.identif_request := lir;
            // Получени идентификаторов
            try {
                hdr = SecHeader.Units.SecHeader.createHeader("dimex", 'q');
                //@ Undeclared identifier(3): 'ISOAPHeaders'
                Headers = (ISOAPHeaders)svc;
                // Headers.OwnsSentHeaders := True;
                //@ Unsupported property or method(A): 'Send'
                Headers.Send(hdr);
                rr = svc.getPersonalData(r);
            // for i := 0 to Length(rr.response.identif_number) - 1 do
            // begin
            // if rr.response.identif_number[i].request_id =
            // r.request.identif_request[0].request_id then
            // edIdentif1.Text := rr.response.identif_number[i].data
            // else if rr.response.identif_number[i].request_id =
            // r.request.identif_request[1].request_id then
            // edIdentif2.Text := rr.response.identif_number[i].data;
            // end;
            // for i := 0 to Length(rr.response.personal_data) - 1 do
            // begin
            // if rr.response.personal_data[i].request_id =
            // r.request.person_request[0].request_id then
            // begin
            // edName.Text := rr.response.personal_data[i].data.name_;
            // if rr.response.personal_data[i].data.citizenship.lexema <> nil then begin
            // l := rr.response.personal_data[i].data.citizenship.lexema;
            // lbCitizen.Clear();
            // for j := 0 to Length(l) - 1 do
            // lbCitizen.Items.Add(Format('%s (%s)', [l[j].Text, l[j].lang]))
            // end;
            // end;
            // end;
            }
            // on e: WsException do
            // ShowMessage(IntToStr(Length(e.error_list)));
            catch(ERemotableException err) {
                //@ Unsupported property or method(C): 'ClassName'
                MessageBox.Show(Convert.ToString(err.ClassName));
            }
        }

    } // end TForm1

}

namespace WsTestMain.Units
{
    public class WsTestMain
    {
        public static TForm1 Form1 = null;
    } // end WsTestMain

}

