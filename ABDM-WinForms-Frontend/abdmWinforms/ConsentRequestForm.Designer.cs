namespace abdmWinforms
{
    partial class ConsentRequestForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblPatientAbha = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.chkPrescription = new System.Windows.Forms.CheckBox();
            this.chkDiagnostic = new System.Windows.Forms.CheckBox();
            this.chkOPD = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSendRequest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Request Consent";
            // 
            // lblPatientAbha
            // 
            this.lblPatientAbha.AutoSize = true;
            this.lblPatientAbha.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientAbha.Location = new System.Drawing.Point(32, 60);
            this.lblPatientAbha.Name = "lblPatientAbha";
            this.lblPatientAbha.Size = new System.Drawing.Size(130, 20);
            this.lblPatientAbha.TabIndex = 1;
            this.lblPatientAbha.Text = "abhaaddress@abdm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(33, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data From (Start):";
            // 
            // dtFrom
            // 
            this.dtFrom.Location = new System.Drawing.Point(36, 130);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(180, 20);
            this.dtFrom.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(235, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Data To (End):";
            // 
            // dtTo
            // 
            this.dtTo.Location = new System.Drawing.Point(238, 130);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(180, 20);
            this.dtTo.TabIndex = 5;
            // 
            // chkPrescription
            // 
            this.chkPrescription.AutoSize = true;
            this.chkPrescription.Checked = true;
            this.chkPrescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrescription.Location = new System.Drawing.Point(36, 205);
            this.chkPrescription.Name = "chkPrescription";
            this.chkPrescription.Size = new System.Drawing.Size(81, 17);
            this.chkPrescription.TabIndex = 6;
            this.chkPrescription.Text = "Prescription";
            this.chkPrescription.UseVisualStyleBackColor = true;
            // 
            // chkDiagnostic
            // 
            this.chkDiagnostic.AutoSize = true;
            this.chkDiagnostic.Location = new System.Drawing.Point(36, 230);
            this.chkDiagnostic.Name = "chkDiagnostic";
            this.chkDiagnostic.Size = new System.Drawing.Size(111, 17);
            this.chkDiagnostic.TabIndex = 7;
            this.chkDiagnostic.Text = "Diagnostic Report";
            this.chkDiagnostic.UseVisualStyleBackColor = true;
            // 
            // chkOPD
            // 
            this.chkOPD.AutoSize = true;
            this.chkOPD.Location = new System.Drawing.Point(36, 255);
            this.chkOPD.Name = "chkOPD";
            this.chkOPD.Size = new System.Drawing.Size(109, 17);
            this.chkOPD.TabIndex = 8;
            this.chkOPD.Text = "OPD Consultation";
            this.chkOPD.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(33, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Information Types:";
            // 
            // btnSendRequest
            // 
            this.btnSendRequest.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSendRequest.FlatAppearance.BorderSize = 0;
            this.btnSendRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendRequest.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSendRequest.ForeColor = System.Drawing.Color.White;
            this.btnSendRequest.Location = new System.Drawing.Point(30, 310);
            this.btnSendRequest.Name = "btnSendRequest";
            this.btnSendRequest.Size = new System.Drawing.Size(390, 50);
            this.btnSendRequest.TabIndex = 10;
            this.btnSendRequest.Text = "SEND CONSENT REQUEST";
            this.btnSendRequest.UseVisualStyleBackColor = false;
            this.btnSendRequest.Click += new System.EventHandler(this.btnSendRequest_Click);
            // 
            // ConsentRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(460, 400);
            this.Controls.Add(this.btnSendRequest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkOPD);
            this.Controls.Add(this.chkDiagnostic);
            this.Controls.Add(this.chkPrescription);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPatientAbha);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ConsentRequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Initiate ABDM Consent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPatientAbha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.CheckBox chkPrescription;
        private System.Windows.Forms.CheckBox chkDiagnostic;
        private System.Windows.Forms.CheckBox chkOPD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSendRequest;
    }
}
