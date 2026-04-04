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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAbha = new System.Windows.Forms.Label();
            this.lblPatient = new System.Windows.Forms.Label();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.colMedicine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnPushToAbdm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABDM Prescription";
            // 
            // lblAbha
            // 
            this.lblAbha.AutoSize = true;
            this.lblAbha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.lblAbha.Location = new System.Drawing.Point(15, 45);
            this.lblAbha.Name = "lblAbha";
            this.lblAbha.Size = new System.Drawing.Size(100, 19);
            this.lblAbha.TabIndex = 1;
            this.lblAbha.Text = "ABHA: ...";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPatient.Location = new System.Drawing.Point(15, 68);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.Size = new System.Drawing.Size(65, 19);
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Patient: ...";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(15, 87);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status: ...";
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AllowUserToOrderColumns = true;
            this.dgvMedicines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedicine,
            this.colDosage,
            this.colDuration});
            this.dgvMedicines.Location = new System.Drawing.Point(15, 100);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.Size = new System.Drawing.Size(550, 200);
            this.dgvMedicines.TabIndex = 3;
            // 
            // colMedicine
            // 
            this.colMedicine.HeaderText = "Medicine Name";
            this.colMedicine.Name = "colMedicine";
            this.colMedicine.Width = 250;
            // 
            // colDosage
            // 
            this.colDosage.HeaderText = "Dosage (1-0-1)";
            this.colDosage.Name = "colDosage";
            this.colDosage.Width = 120;
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Duration";
            this.colDuration.Name = "colDuration";
            this.colDuration.Width = 100;
            // 
            // btnPushToAbdm
            // 
            this.btnPushToAbdm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnPushToAbdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPushToAbdm.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPushToAbdm.ForeColor = System.Drawing.Color.White;
            this.btnPushToAbdm.Location = new System.Drawing.Point(15, 315);
            this.btnPushToAbdm.Name = "btnPushToAbdm";
            this.btnPushToAbdm.Size = new System.Drawing.Size(550, 45);
            this.btnPushToAbdm.TabIndex = 4;
            this.btnPushToAbdm.Text = "PUSH TO ABDM";
            this.btnPushToAbdm.UseVisualStyleBackColor = false;
            this.btnPushToAbdm.Click += new System.EventHandler(this.btnPushToAbdm_Click);
            // 
            // PrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(584, 380);
            this.Controls.Add(this.btnPushToAbdm);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblPatient);
            this.Controls.Add(this.lblAbha);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Midha Hospital - Manage Prescription";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
