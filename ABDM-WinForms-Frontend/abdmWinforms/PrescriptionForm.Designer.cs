namespace abdmWinforms
{
    partial class PrescriptionForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblPatientAbha = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMedicines = new System.Windows.Forms.DataGridView();
            this.colMedicine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDosage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveAndSend = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlTopHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.MidnightBlue;
            this.pnlTopHeader.Controls.Add(this.lblPatientAbha);
            this.pnlTopHeader.Controls.Add(this.lblPatientName);
            this.pnlTopHeader.Controls.Add(this.label1);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(634, 100);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblPatientAbha
            // 
            this.lblPatientAbha.AutoSize = true;
            this.lblPatientAbha.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPatientAbha.ForeColor = System.Drawing.Color.LightGray;
            this.lblPatientAbha.Location = new System.Drawing.Point(30, 65);
            this.lblPatientAbha.Name = "lblPatientAbha";
            this.lblPatientAbha.Size = new System.Drawing.Size(130, 19);
            this.lblPatientAbha.TabIndex = 2;
            this.lblPatientAbha.Text = "abhaaddress@abdm";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblPatientName.ForeColor = System.Drawing.Color.White;
            this.lblPatientName.Location = new System.Drawing.Point(30, 35);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(145, 30);
            this.lblPatientName.TabIndex = 1;
            this.lblPatientName.Text = "Patient Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "WRITING PRESCRIPTION";
            // 
            // dgvMedicines
            // 
            this.dgvMedicines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicines.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicines.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedicines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMedicines.ColumnHeadersHeight = 35;
            this.dgvMedicines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMedicine,
            this.colDosage,
            this.colDuration});
            this.dgvMedicines.EnableHeadersVisualStyles = false;
            this.dgvMedicines.Location = new System.Drawing.Point(30, 120);
            this.dgvMedicines.Name = "dgvMedicines";
            this.dgvMedicines.RowHeadersVisible = false;
            this.dgvMedicines.Size = new System.Drawing.Size(570, 280);
            this.dgvMedicines.TabIndex = 1;
            // 
            // colMedicine
            // 
            this.colMedicine.HeaderText = "Dawa Name (e.g., Paracetamol)";
            this.colMedicine.Name = "colMedicine";
            // 
            // colDosage
            // 
            this.colDosage.HeaderText = "Dose (e.g., 1-0-1)";
            this.colDosage.Name = "colDosage";
            // 
            // colDuration
            // 
            this.colDuration.HeaderText = "Days (e.g., 5 days)";
            this.colDuration.Name = "colDuration";
            // 
            // btnSaveAndSend
            // 
            this.btnSaveAndSend.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSaveAndSend.FlatAppearance.BorderSize = 0;
            this.btnSaveAndSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAndSend.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSaveAndSend.ForeColor = System.Drawing.Color.White;
            this.btnSaveAndSend.Location = new System.Drawing.Point(330, 420);
            this.btnSaveAndSend.Name = "btnSaveAndSend";
            this.btnSaveAndSend.Size = new System.Drawing.Size(270, 50);
            this.btnSaveAndSend.TabIndex = 2;
            this.btnSaveAndSend.Text = "SAVE && PUSH TO ABDM";
            this.btnSaveAndSend.UseVisualStyleBackColor = false;
            this.btnSaveAndSend.Click += new System.EventHandler(this.btnSaveAndSend_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(30, 420);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(270, 50);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "PRINT PARCHA (RDLC)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // PrescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(634, 500);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSaveAndSend);
            this.Controls.Add(this.dgvMedicines);
            this.Controls.Add(this.pnlTopHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "PrescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Electronic Prescription Hub";
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicines)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPatientAbha;
        private System.Windows.Forms.DataGridView dgvMedicines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMedicine;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDosage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDuration;
        private System.Windows.Forms.Button btnSaveAndSend;
        private System.Windows.Forms.Button btnPrint;
    }
}
