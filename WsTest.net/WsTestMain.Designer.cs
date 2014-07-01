namespace WsTestMain
{
  partial class TForm1
    {
        public System.Windows.Forms.Label lblURL;
        public System.Windows.Forms.Label lblProxy;
        public System.Windows.Forms.Label lblSex1;
        public System.Windows.Forms.Label lblBirthday1;
        public System.Windows.Forms.Label lblSex2;
        public System.Windows.Forms.Label lblBirthday2;
        public System.Windows.Forms.TextBox edURL;
        public System.Windows.Forms.TextBox edProxy;
        public System.Windows.Forms.TabControl pcXML;
        public System.Windows.Forms.TabPage tsRequest;
        public System.Windows.Forms.TextBox edRequest;
        public System.Windows.Forms.TabPage tsResponse;
        public System.Windows.Forms.TextBox edResponse;
        public System.Windows.Forms.TextBox edSex1;
        public TJvDatePickerEdit edBirthday1;
        public System.Windows.Forms.TextBox edSex2;
        public TJvDatePickerEdit edBirthday2;
        public System.Windows.Forms.Button btnCall;
        public THTTPRIO HTTPRIO;
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ToolTip toolTip1 = null;

        // Clean up any resources being used.
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

#region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(this.GetType());
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblURL = new System.Windows.Forms.Label();
            this.lblProxy = new System.Windows.Forms.Label();
            this.lblSex1 = new System.Windows.Forms.Label();
            this.lblBirthday1 = new System.Windows.Forms.Label();
            this.lblSex2 = new System.Windows.Forms.Label();
            this.lblBirthday2 = new System.Windows.Forms.Label();
            this.edURL = new System.Windows.Forms.TextBox();
            this.edProxy = new System.Windows.Forms.TextBox();
            this.pcXML = new System.Windows.Forms.TabControl();
            this.tsRequest = new System.Windows.Forms.TabPage();
            this.edRequest = new System.Windows.Forms.TextBox();
            this.tsResponse = new System.Windows.Forms.TabPage();
            this.edResponse = new System.Windows.Forms.TextBox();
            this.edSex1 = new System.Windows.Forms.TextBox();
            this.edBirthday1 = new TJvDatePickerEdit();
            this.edSex2 = new System.Windows.Forms.TextBox();
            this.edBirthday2 = new TJvDatePickerEdit();
            this.btnCall = new System.Windows.Forms.Button();
            this.HTTPRIO = new THTTPRIO();
            this.SuspendLayout();
            this.Location  = new System.Drawing.Point(0, 0);
            this.ClientSize  = new System.Drawing.Size(731, 563);
            this.Font  = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point ,((byte)(1)));
            this.Load += new System.EventHandler(this.FormCreate);
            this.AutoScroll = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblURL.Size  = new System.Drawing.Size(19, 13);
            this.lblURL.Location  = new System.Drawing.Point(24, 11);
            this.lblURL.Text = "URL";
            this.lblURL.Enabled = true;
            this.lblURL.Name = "lblURL";
            this.lblProxy.Size  = new System.Drawing.Size(28, 13);
            this.lblProxy.Location  = new System.Drawing.Point(24, 48);
            this.lblProxy.Text = "Proxy";
            this.lblProxy.Enabled = true;
            this.lblProxy.Name = "lblProxy";
            this.lblSex1.Size  = new System.Drawing.Size(18, 13);
            this.lblSex1.Location  = new System.Drawing.Point(248, 11);
            this.lblSex1.Text = "Sex";
            this.lblSex1.Enabled = true;
            this.lblSex1.Name = "lblSex1";
            this.lblBirthday1.Size  = new System.Drawing.Size(40, 13);
            this.lblBirthday1.Location  = new System.Drawing.Point(328, 11);
            this.lblBirthday1.Text = "Birthday";
            this.lblBirthday1.Enabled = true;
            this.lblBirthday1.Name = "lblBirthday1";
            this.lblSex2.Size  = new System.Drawing.Size(18, 13);
            this.lblSex2.Location  = new System.Drawing.Point(248, 48);
            this.lblSex2.Text = "Sex";
            this.lblSex2.Enabled = true;
            this.lblSex2.Name = "lblSex2";
            this.lblBirthday2.Size  = new System.Drawing.Size(40, 13);
            this.lblBirthday2.Location  = new System.Drawing.Point(328, 48);
            this.lblBirthday2.Text = "Birthday";
            this.lblBirthday2.Enabled = true;
            this.lblBirthday2.Name = "lblBirthday2";
            this.edURL.Size  = new System.Drawing.Size(170, 21);
            this.edURL.Location  = new System.Drawing.Point(72, 8);
            this.edURL.TabIndex = 0;
            this.edURL.Text = "edURL";
            this.edURL.Enabled = true;
            this.edURL.Name = "edURL";
            this.edProxy.Size  = new System.Drawing.Size(170, 21);
            this.edProxy.Location  = new System.Drawing.Point(72, 45);
            this.edProxy.TabIndex = 1;
            this.edProxy.Enabled = true;
            this.edProxy.Name = "edProxy";
            this.pcXML.Size  = new System.Drawing.Size(715, 483);
            this.pcXML.Location  = new System.Drawing.Point(8, 72);
            this.pcXML.SuspendLayout();
            this.pcXML.SelectedTab = tsRequest;
            this.pcXML.TabIndex = 2;
            this.pcXML.Enabled = true;
            this.pcXML.Name = "pcXML";
            this.tsRequest.Size  = new System.Drawing.Size(0, 0);
            this.tsRequest.Location  = new System.Drawing.Point(0, 0);
            this.tsRequest.SuspendLayout();
            this.tsRequest.Text = "Request";
            this.tsRequest.Enabled = true;
            this.tsRequest.Name = "tsRequest";
            this.edRequest.Size  = new System.Drawing.Size(707, 455);
            this.edRequest.Location  = new System.Drawing.Point(0, 0);
            this.edRequest.Lines =  new string[] { 
                "edRequest",
                };
            this.edRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edRequest.Multiline = true;
            this.edRequest.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.edRequest.TabIndex = 0;
            this.edRequest.Name = "edRequest";
            this.edRequest.Enabled = true;
            this.tsResponse.Size  = new System.Drawing.Size(0, 0);
            this.tsResponse.Location  = new System.Drawing.Point(0, 0);
            this.tsResponse.SuspendLayout();
            this.tsResponse.Text = "Response";
            this.tsResponse.ImageIndex = 1;
            this.tsResponse.Name = "tsResponse";
            this.tsResponse.Enabled = true;
            this.edResponse.Size  = new System.Drawing.Size(707, 455);
            this.edResponse.Location  = new System.Drawing.Point(0, 0);
            this.edResponse.Lines =  new string[] { 
                "edResponse",
                };
            this.edResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edResponse.Multiline = true;
            this.edResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.edResponse.TabIndex = 0;
            this.edResponse.Name = "edResponse";
            this.edResponse.Enabled = true;
            this.edSex1.Size  = new System.Drawing.Size(25, 21);
            this.edSex1.Location  = new System.Drawing.Point(272, 8);
            this.edSex1.TabIndex = 3;
            this.edSex1.Text = "M";
            this.edSex1.Enabled = true;
            this.edSex1.Name = "edSex1";
            this.edSex2.Size  = new System.Drawing.Size(23, 21);
            this.edSex2.Location  = new System.Drawing.Point(272, 45);
            this.edSex2.TabIndex = 5;
            this.edSex2.Text = "M";
            this.edSex2.Enabled = true;
            this.edSex2.Name = "edSex2";
            this.btnCall.Size  = new System.Drawing.Size(75, 25);
            this.btnCall.Location  = new System.Drawing.Point(528, 8);
            this.btnCall.Text = "Call Service";
            this.btnCall.Click += new System.EventHandler(this.btnGenIdentifClick);
            this.btnCall.TabIndex = 7;
            this.btnCall.Name = "btnCall";
            this.btnCall.Enabled = true;
            this.btnCall.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tsRequest.Controls.Add(edRequest);
            this.tsRequest.ResumeLayout(false);
            this.tsResponse.Controls.Add(edResponse);
            this.tsResponse.ResumeLayout(false);
            this.pcXML.Controls.Add(tsRequest);
            this.pcXML.Controls.Add(tsResponse);
            this.pcXML.ResumeLayout(false);
            this.Controls.Add(lblURL);
            this.Controls.Add(lblProxy);
            this.Controls.Add(lblSex1);
            this.Controls.Add(lblBirthday1);
            this.Controls.Add(lblSex2);
            this.Controls.Add(lblBirthday2);
            this.Controls.Add(edURL);
            this.Controls.Add(edProxy);
            this.Controls.Add(pcXML);
            this.Controls.Add(edSex1);
            this.Controls.Add(edSex2);
            this.Controls.Add(btnCall);
            this.ResumeLayout(false);
        }
#endregion

    }
}
