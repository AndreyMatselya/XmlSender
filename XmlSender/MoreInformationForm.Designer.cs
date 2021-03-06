﻿namespace XmlSender
{
	partial class MoreInformationForm
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
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.XmlId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ParentMessageId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Success = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ErrorsText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SuccessID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Identif = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XmlId,
            this.DateCreated,
            this.ParentMessageId,
            this.Success,
            this.ErrorsText,
            this.SuccessID,
            this.Identif,
            this.Errors});
			this.dataGridView1.Location = new System.Drawing.Point(12, 36);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGridView1.Size = new System.Drawing.Size(1054, 669);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
			// 
			// XmlId
			// 
			this.XmlId.DataPropertyName = "XmlId";
			this.XmlId.HeaderText = "Id";
			this.XmlId.Name = "XmlId";
			this.XmlId.Width = 50;
			// 
			// DateCreated
			// 
			this.DateCreated.DataPropertyName = "DateCreated";
			this.DateCreated.HeaderText = "Дата отправки";
			this.DateCreated.Name = "DateCreated";
			this.DateCreated.Width = 70;
			// 
			// ParentMessageId
			// 
			this.ParentMessageId.DataPropertyName = "ParentMessageId";
			this.ParentMessageId.HeaderText = "ParentMessageId";
			this.ParentMessageId.Name = "ParentMessageId";
			// 
			// Success
			// 
			this.Success.DataPropertyName = "Success";
			this.Success.HeaderText = "Успешно";
			this.Success.Name = "Success";
			this.Success.Width = 60;
			// 
			// ErrorsText
			// 
			this.ErrorsText.DataPropertyName = "ErrorsText";
			this.ErrorsText.HeaderText = "Ошибки";
			this.ErrorsText.Name = "ErrorsText";
			this.ErrorsText.Width = 730;
			// 
			// SuccessID
			// 
			this.SuccessID.DataPropertyName = "SuccessID";
			this.SuccessID.HeaderText = "Успешно";
			this.SuccessID.Name = "SuccessID";
			this.SuccessID.Visible = false;
			// 
			// Identif
			// 
			this.Identif.DataPropertyName = "Identif";
			this.Identif.HeaderText = "Идентиф";
			this.Identif.Name = "Identif";
			this.Identif.Visible = false;
			// 
			// Errors
			// 
			this.Errors.DataPropertyName = "Errors";
			this.Errors.HeaderText = "ОшибкиXml";
			this.Errors.Name = "Errors";
			this.Errors.Visible = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(153, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Сохранить в XML";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MoreInformationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1078, 717);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.dataGridView1);
			this.MaximizeBox = false;
			this.Name = "MoreInformationForm";
			this.Text = "Подробная информация";
			this.Load += new System.EventHandler(this.MoreInformationForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridViewTextBoxColumn XmlId;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
		private System.Windows.Forms.DataGridViewTextBoxColumn ParentMessageId;
		private System.Windows.Forms.DataGridViewTextBoxColumn Success;
		private System.Windows.Forms.DataGridViewTextBoxColumn ErrorsText;
		private System.Windows.Forms.DataGridViewTextBoxColumn SuccessID;
		private System.Windows.Forms.DataGridViewTextBoxColumn Identif;
		private System.Windows.Forms.DataGridViewTextBoxColumn Errors;
	}
}