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
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// postButton
			// 
			this.postButton.Enabled = false;
			this.postButton.Location = new System.Drawing.Point(611, 186);
			this.postButton.Name = "postButton";
			this.postButton.Size = new System.Drawing.Size(143, 23);
			this.postButton.TabIndex = 0;
			this.postButton.Text = "Отправить";
			this.postButton.UseVisualStyleBackColor = true;
			this.postButton.Click += new System.EventHandler(this.button1_Click);
			// 
			// openFileButton
			// 
			this.openFileButton.Location = new System.Drawing.Point(536, 91);
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
			this.menuStrip1.Size = new System.Drawing.Size(763, 24);
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
			this.selectedFilePathTextBox.Location = new System.Drawing.Point(110, 93);
			this.selectedFilePathTextBox.Name = "selectedFilePathTextBox";
			this.selectedFilePathTextBox.Size = new System.Drawing.Size(420, 20);
			this.selectedFilePathTextBox.TabIndex = 2;
			this.selectedFilePathTextBox.Visible = false;
			// 
			// selectedFileLabel
			// 
			this.selectedFileLabel.AutoSize = true;
			this.selectedFileLabel.Location = new System.Drawing.Point(107, 64);
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
			this.statusStrip1.Location = new System.Drawing.Point(0, 215);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(763, 22);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 237);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.selectedFileLabel);
			this.Controls.Add(this.openFileButton);
			this.Controls.Add(this.selectedFilePathTextBox);
			this.Controls.Add(this.postButton);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "АРМ Белгосстраха для обмена данными с ГИС \"Регистр населения\"";
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
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

	}
}

