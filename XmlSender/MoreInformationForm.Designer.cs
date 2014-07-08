namespace XmlSender
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
			this.Identif = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.InsuranceAwardingDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.InsuranceSuspensionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Success = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Errors = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XmlId,
            this.DateCreated,
            this.Identif,
            this.InsuranceAwardingDate,
            this.InsuranceSuspensionDate,
            this.Success,
            this.Errors});
			this.dataGridView1.Location = new System.Drawing.Point(12, 36);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(1054, 669);
			this.dataGridView1.TabIndex = 0;
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
			// Identif
			// 
			this.Identif.DataPropertyName = "Identif";
			this.Identif.HeaderText = "Идентификатор";
			this.Identif.Name = "Identif";
			// 
			// InsuranceAwardingDate
			// 
			this.InsuranceAwardingDate.DataPropertyName = "InsuranceAwardingDate";
			this.InsuranceAwardingDate.HeaderText = "Дата назначения страховой выплаты";
			this.InsuranceAwardingDate.Name = "InsuranceAwardingDate";
			this.InsuranceAwardingDate.Width = 70;
			// 
			// InsuranceSuspensionDate
			// 
			this.InsuranceSuspensionDate.DataPropertyName = "InsuranceSuspensionDate";
			this.InsuranceSuspensionDate.HeaderText = "Дата прекращения страховой выплаты";
			this.InsuranceSuspensionDate.Name = "InsuranceSuspensionDate";
			this.InsuranceSuspensionDate.Width = 80;
			// 
			// Success
			// 
			this.Success.DataPropertyName = "Success";
			this.Success.HeaderText = "Успешно";
			this.Success.Name = "Success";
			this.Success.Width = 60;
			// 
			// Errors
			// 
			this.Errors.DataPropertyName = "Errors";
			this.Errors.HeaderText = "Ошибки";
			this.Errors.Name = "Errors";
			this.Errors.Width = 560;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 7);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(153, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Сохранить в XML";
			this.button1.UseVisualStyleBackColor = true;
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
		private System.Windows.Forms.DataGridViewTextBoxColumn XmlId;
		private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
		private System.Windows.Forms.DataGridViewTextBoxColumn Identif;
		private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceAwardingDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceSuspensionDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn Success;
		private System.Windows.Forms.DataGridViewTextBoxColumn Errors;
		private System.Windows.Forms.Button button1;
	}
}