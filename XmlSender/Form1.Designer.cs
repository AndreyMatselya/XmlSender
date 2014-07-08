namespace XmlSender
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.postButton = new System.Windows.Forms.Button();
			this.openFileButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.историяОперацийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.протоколToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectedFilePathTextBox = new System.Windows.Forms.TextBox();
			this.selectedFileLabel = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// postButton
			// 
			this.postButton.Enabled = false;
			this.postButton.Location = new System.Drawing.Point(613, 240);
			this.postButton.Name = "postButton";
			this.postButton.Size = new System.Drawing.Size(143, 23);
			this.postButton.TabIndex = 0;
			this.postButton.Text = "Отправить";
			this.postButton.UseVisualStyleBackColor = true;
			this.postButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileButton
			// 
			this.openFileButton.Location = new System.Drawing.Point(569, 51);
			this.openFileButton.Name = "openFileButton";
			this.openFileButton.Size = new System.Drawing.Size(37, 23);
			this.openFileButton.TabIndex = 3;
			this.openFileButton.Text = "...";
			this.openFileButton.UseVisualStyleBackColor = true;
			this.openFileButton.Visible = false;
			this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.историяОперацийToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(768, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.fileToolStripMenuItem.Text = "Файл";
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.openToolStripMenuItem.Text = "Открыть";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
			// 
			// историяОперацийToolStripMenuItem
			// 
			this.историяОперацийToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.протоколToolStripMenuItem});
			this.историяОперацийToolStripMenuItem.Name = "историяОперацийToolStripMenuItem";
			this.историяОперацийToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
			this.историяОперацийToolStripMenuItem.Text = "История операций";
			// 
			// протоколToolStripMenuItem
			// 
			this.протоколToolStripMenuItem.Name = "протоколToolStripMenuItem";
			this.протоколToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
			this.протоколToolStripMenuItem.Text = "Протокол";
			this.протоколToolStripMenuItem.Click += new System.EventHandler(this.протоколToolStripMenuItem_Click);
			// 
			// selectedFilePathTextBox
			// 
			this.selectedFilePathTextBox.Enabled = false;
			this.selectedFilePathTextBox.Location = new System.Drawing.Point(143, 53);
			this.selectedFilePathTextBox.Name = "selectedFilePathTextBox";
			this.selectedFilePathTextBox.Size = new System.Drawing.Size(420, 20);
			this.selectedFilePathTextBox.TabIndex = 2;
			this.selectedFilePathTextBox.Visible = false;
			// 
			// selectedFileLabel
			// 
			this.selectedFileLabel.AutoSize = true;
			this.selectedFileLabel.Location = new System.Drawing.Point(140, 24);
			this.selectedFileLabel.Name = "selectedFileLabel";
			this.selectedFileLabel.Size = new System.Drawing.Size(110, 13);
			this.selectedFileLabel.TabIndex = 4;
			this.selectedFileLabel.Text = "Файл для отправки:";
			this.selectedFileLabel.Visible = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 275);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(768, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 5;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(600, 16);
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.SendDate,
            this.UserName,
            this.Description});
			this.dataGridView1.Location = new System.Drawing.Point(12, 24);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(744, 210);
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.Visible = false;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			// 
			// Id
			// 
			this.Id.DataPropertyName = "Id";
			this.Id.HeaderText = "Id";
			this.Id.Name = "Id";
			this.Id.ReadOnly = true;
			this.Id.Width = 50;
			// 
			// SendDate
			// 
			this.SendDate.DataPropertyName = "SendDate";
			this.SendDate.HeaderText = "Дата отправки";
			this.SendDate.Name = "SendDate";
			this.SendDate.ReadOnly = true;
			// 
			// UserName
			// 
			this.UserName.DataPropertyName = "UserName";
			this.UserName.HeaderText = "Пользователь";
			this.UserName.Name = "UserName";
			this.UserName.ReadOnly = true;
			// 
			// Description
			// 
			this.Description.DataPropertyName = "Description";
			this.Description.HeaderText = "Описание";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			this.Description.Width = 434;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 297);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.selectedFileLabel);
			this.Controls.Add(this.openFileButton);
			this.Controls.Add(this.selectedFilePathTextBox);
			this.Controls.Add(this.postButton);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.dataGridView1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "АРМ Белгосстраха для обмена данными с ГИС \"Регистр населения\"";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button postButton;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem историяОперацийToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem протоколToolStripMenuItem;
		private System.Windows.Forms.TextBox selectedFilePathTextBox;
		private System.Windows.Forms.Button openFileButton;
		private System.Windows.Forms.Label selectedFileLabel;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Id;
		private System.Windows.Forms.DataGridViewTextBoxColumn SendDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;

	}
}

