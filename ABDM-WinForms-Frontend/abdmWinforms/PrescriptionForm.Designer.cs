namespace abdmWinforms
{
    partial class PrescriptionForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblAbha;
        private System.Windows.Forms.Label lblPatient;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.Button btnPushToAbdm;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbHiType;
        private System.Windows.Forms.Label labelHiType;
        private System.Windows.Forms.ComboBox cmbCareContext;
        private System.Windows.Forms.Label labelCareContext;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblHospitalName;
        private System.Windows.Forms.Label lblHospitalAddress;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Panel pnlPatientInfo;
        private System.Windows.Forms.Label lblRx;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnExportPdf;
        private System.Windows.Forms.Label lblGenderAge;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblSignature;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblHospitalAddress = new System.Windows.Forms.Label();
            this.lblHospitalName = new System.Windows.Forms.Label();
            this.pnlPatientInfo = new System.Windows.Forms.Panel();
            this.lblGenderAge = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblAbha = new System.Windows.Forms.Label();
            this.lblRx = new System.Windows.Forms.Label();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.colMedicine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPushToAbdm = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbHiType = new System.Windows.Forms.ComboBox();
            this.labelHiType = new System.Windows.Forms.Label();
            this.cmbCareContext = new System.Windows.Forms.ComboBox();
            this.labelCareContext = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblSignature = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlPatientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.pnlHeader.Controls.Add(this.lblDoctorName);
            this.pnlHeader.Controls.Add(this.lblHospitalAddress);
            this.pnlHeader.Controls.Add(this.lblHospitalName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(650, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoctorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblDoctorName.Location = new System.Drawing.Point(450, 20);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(148, 21);
            this.lblDoctorName.TabIndex = 2;
            this.lblDoctorName.Text = "Dr. Abhay Midha";
            this.lblDoctorName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblHospitalAddress
            // 
            this.lblHospitalAddress.AutoSize = true;
            this.lblHospitalAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHospitalAddress.ForeColor = System.Drawing.Color.Gray;
            this.lblHospitalAddress.Location = new System.Drawing.Point(15, 60);
            this.lblHospitalAddress.Name = "lblHospitalAddress";
            this.lblHospitalAddress.Size = new System.Drawing.Size(250, 15);
            this.lblHospitalAddress.TabIndex = 1;
            this.lblHospitalAddress.Text = "Near Civil Lines, Gurgaon, Haryana - 122001";
            // 
            // lblHospitalName
            // 
            this.lblHospitalName.AutoSize = true;
            this.lblHospitalName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblHospitalName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblHospitalName.Location = new System.Drawing.Point(12, 12);
            this.lblHospitalName.Name = "lblHospitalName";
            this.lblHospitalName.Size = new System.Drawing.Size(245, 37);
            this.lblHospitalName.TabIndex = 0;
            this.lblHospitalName.Text = "MIDHA HOSPITAL";
            // 
            // pnlPatientInfo
            // 
            this.pnlPatientInfo.BackColor = System.Drawing.Color.White;
            this.pnlPatientInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPatientInfo.Controls.Add(this.lblGenderAge);
            this.pnlPatientInfo.Controls.Add(this.lblDate);
            this.pnlPatientInfo.Controls.Add(this.lblPatient);
            this.pnlPatientInfo.Controls.Add(this.lblAbha);
            this.pnlPatientInfo.Location = new System.Drawing.Point(15, 115);
            this.pnlPatientInfo.Name = "pnlPatientInfo";
            this.pnlPatientInfo.Size = new System.Drawing.Size(620, 80);
            this.pnlPatientInfo.TabIndex = 1;
            // 
            // lblGenderAge
            // 
            this.lblGenderAge.AutoSize = true;
            this.lblGenderAge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGenderAge.Location = new System.Drawing.Point(10, 52);
            this.lblGenderAge.Name = "lblGenderAge";
            this.lblGenderAge.Size = new System.Drawing.Size(120, 15);
            this.lblGenderAge.TabIndex = 3;
            this.lblGenderAge.Text = "Gender: M | Age: 30";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(480, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(110, 15);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date: 2026-04-08";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPatient.Location = new System.Drawing.Point(10, 10);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(120, 20);
            this.lblPatient.TabIndex = 0;
            this.lblPatient.Text = "Patient: Patient Name";
            // 
            // lblAbha
            // 
            this.lblAbha.AutoSize = true;
            this.lblAbha.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAbha.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblAbha.Location = new System.Drawing.Point(10, 32);
            this.lblAbha.Name = "lblAbha";
            this.lblAbha.Size = new System.Drawing.Size(115, 15);
            this.lblAbha.TabIndex = 1;
            this.lblAbha.Text = "ABHA: user@sbx";
            // 
            // lblRx
            // 
            this.lblRx.AutoSize = true;
            this.lblRx.Font = new System.Drawing.Font("Times New Roman", 32F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblRx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRx.Location = new System.Drawing.Point(15, 205);
            this.lblRx.Name = "lblRx";
            this.lblRx.Size = new System.Drawing.Size(84, 49);
            this.lblRx.TabIndex = 2;
            this.lblRx.Text = "𝓡𝔁";
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMedicines.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicines.ColumnHeadersHeight = 30;
            this.dgvMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedicine,
            this.colDosage,
            this.colDuration});
            this.dgvMedicines.EnableHeadersVisualStyles = false;
            this.dgvMedicines.GridColor = System.Drawing.Color.LightGray;
            this.dgvMedicines.Location = new System.Drawing.Point(15, 260);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.Size = new System.Drawing.Size(620, 300);
            this.dgvMedicines.TabIndex = 3;
            // 
            // colMedicine
            // 
            this.colMedicine.HeaderText = "Medicine Name";
            this.colMedicine.Name = "colMedicine";
            this.colMedicine.Width = 350;
            // 
            // colDosage
            // 
            this.colDosage.HeaderText = "Dosage";
            this.colDosage.Name = "colDosage";
            this.colDosage.Width = 120;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.Width = 130;
            // 
            // btnPushToAbdm
            // 
            this.btnPushToAbdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPushToAbdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPushToAbdm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPushToAbdm.ForeColor = System.Drawing.Color.White;
            this.btnPushToAbdm.Location = new System.Drawing.Point(340, 700);
            this.btnPushToAbdm.Name = "btnPushToAbdm";
            this.btnPushToAbdm.Size = new System.Drawing.Size(295, 45);
            this.btnPushToAbdm.TabIndex = 4;
            this.btnPushToAbdm.Text = "PUSH FHIR BUNDLE";
            this.btnPushToAbdm.UseVisualStyleBackColor = false;
            this.btnPushToAbdm.Click += new System.EventHandler(this.btnPushToAbdm_Click);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(15, 700);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(295, 45);
            this.btnExportPdf.TabIndex = 5;
            this.btnExportPdf.Text = "SAVE AS PDF / PRINT";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(15, 755);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 15);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status: ...";
            // 
            // cmbHiType
            // 
            this.cmbHiType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHiType.FormattingEnabled = true;
            this.cmbHiType.Items.AddRange(new object[] {
            "Prescription",
            "DiagnosticReport",
            "OPConsultation",
            "DischargeSummary"});
            this.cmbHiType.Location = new System.Drawing.Point(130, 640);
            this.cmbHiType.Name = "cmbHiType";
            this.cmbHiType.Size = new System.Drawing.Size(200, 23);
            this.cmbHiType.TabIndex = 10;
            // 
            // labelHiType
            // 
            this.labelHiType.AutoSize = true;
            this.labelHiType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelHiType.Location = new System.Drawing.Point(15, 643);
            this.labelHiType.Name = "labelHiType";
            this.labelHiType.Size = new System.Drawing.Size(104, 15);
            this.labelHiType.TabIndex = 11;
            this.labelHiType.Text = "Information Type:";
            // 
            // cmbCareContext
            // 
            this.cmbCareContext.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCareContext.FormattingEnabled = true;
            this.cmbCareContext.Location = new System.Drawing.Point(130, 600);
            this.cmbCareContext.Name = "cmbCareContext";
            this.cmbCareContext.Size = new System.Drawing.Size(505, 23);
            this.cmbCareContext.TabIndex = 12;
            // 
            // labelCareContext
            // 
            this.labelCareContext.AutoSize = true;
            this.labelCareContext.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelCareContext.Location = new System.Drawing.Point(15, 603);
            this.labelCareContext.Name = "labelCareContext";
            this.labelCareContext.Size = new System.Drawing.Size(100, 15);
            this.labelCareContext.TabIndex = 13;
            this.labelCareContext.Text = "Select Visit ID:";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblSignature);
            this.pnlFooter.Location = new System.Drawing.Point(400, 560);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(235, 30);
            this.pnlFooter.TabIndex = 14;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSignature.Location = new System.Drawing.Point(5, 5);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(100, 13);
            this.lblSignature.TabIndex = 0;
            this.lblSignature.Text = "Doctor's Signature";
            // 
            // PrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 800);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.labelCareContext);
            this.Controls.Add(this.cmbCareContext);
            this.Controls.Add(this.labelHiType);
            this.Controls.Add(this.cmbHiType);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.btnPushToAbdm);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.lblRx);
            this.Controls.Add(this.pnlPatientInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MIDHA HOSPITAL - Prescription Management";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlPatientInfo.ResumeLayout(false);
            this.pnlPatientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
