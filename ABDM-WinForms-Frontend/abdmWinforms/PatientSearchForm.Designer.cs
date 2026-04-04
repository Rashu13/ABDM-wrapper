namespace abdmWinforms
{
    partial class PatientSearchForm
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
            this.txtSearchAbha = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowInvite = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnM3Dashboard = new System.Windows.Forms.Button();
            this.btnShowRegistration = new System.Windows.Forms.Button();
            this.btnWritePrescription = new System.Windows.Forms.Button();
            this.btnRequestConsent = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.btnStartLinking = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlResultHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetails.SuspendLayout();
            this.pnlResultHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(100, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABDM Patient Navigator";
            // 
            // txtSearchAbha
            // 
            this.txtSearchAbha.BackColor = System.Drawing.Color.White;
            this.txtSearchAbha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAbha.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtSearchAbha.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearchAbha.Location = new System.Drawing.Point(60, 100);
            this.txtSearchAbha.Name = "txtSearchAbha";
            this.txtSearchAbha.Size = new System.Drawing.Size(320, 33);
            this.txtSearchAbha.TabIndex = 1;
            this.txtSearchAbha.Text = "enter abha address...";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(390, 100);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "SEARCH";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnShowInvite
            // 
            this.btnShowInvite.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnShowInvite.FlatAppearance.BorderSize = 0;
            this.btnShowInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowInvite.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnShowInvite.ForeColor = System.Drawing.Color.White;
            this.btnShowInvite.Location = new System.Drawing.Point(390, 71);
            this.btnShowInvite.Name = "btnShowInvite";
            this.btnShowInvite.Size = new System.Drawing.Size(120, 23);
            this.btnShowInvite.TabIndex = 4;
            this.btnShowInvite.Text = "INVITE VIA SMS";
            this.btnShowInvite.UseVisualStyleBackColor = false;
            this.btnShowInvite.Click += new System.EventHandler(this.btnShowInvite_Click);
            // 
            // btnViewLogs
            // 
            this.btnViewLogs.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnViewLogs.FlatAppearance.BorderSize = 0;
            this.btnViewLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewLogs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewLogs.ForeColor = System.Drawing.Color.White;
            this.btnViewLogs.Location = new System.Drawing.Point(60, 445);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(450, 40);
            this.btnViewLogs.TabIndex = 6;
            this.btnViewLogs.Text = "VIEW ACTIVITY LOGS / FULL LIST";
            this.btnViewLogs.UseVisualStyleBackColor = false;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // btnM3Dashboard
            // 
            this.btnM3Dashboard.BackColor = System.Drawing.Color.OrangeRed;
            this.btnM3Dashboard.FlatAppearance.BorderSize = 0;
            this.btnM3Dashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnM3Dashboard.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnM3Dashboard.ForeColor = System.Drawing.Color.White;
            this.btnM3Dashboard.Location = new System.Drawing.Point(60, 71);
            this.btnM3Dashboard.Name = "btnM3Dashboard";
            this.btnM3Dashboard.Size = new System.Drawing.Size(120, 23);
            this.btnM3Dashboard.TabIndex = 7;
            this.btnM3Dashboard.Text = "M3 MONITOR";
            this.btnM3Dashboard.UseVisualStyleBackColor = false;
            this.btnM3Dashboard.Click += new System.EventHandler(this.btnM3Dashboard_Click);
            // 
            // btnShowRegistration
            // 
            this.btnShowRegistration.BackColor = System.Drawing.Color.DimGray;
            this.btnShowRegistration.FlatAppearance.BorderSize = 0;
            this.btnShowRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRegistration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowRegistration.ForeColor = System.Drawing.Color.White;
            this.btnShowRegistration.Location = new System.Drawing.Point(60, 140);
            this.btnShowRegistration.Name = "btnShowRegistration";
            this.btnShowRegistration.Size = new System.Drawing.Size(450, 35);
            this.btnShowRegistration.TabIndex = 9;
            this.btnShowRegistration.Text = "➕  REGISTER NEW PATIENT (If Not Found)";
            this.btnShowRegistration.UseVisualStyleBackColor = false;
            this.btnShowRegistration.Click += new System.EventHandler(this.btnShowRegistration_Click);
            // 
            // pnlDetails
            // 
            this.pnlDetails.BackColor = System.Drawing.Color.White;
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.btnWritePrescription);
            this.pnlDetails.Controls.Add(this.btnRequestConsent);
            this.pnlDetails.Controls.Add(this.btnViewHistory);
            this.pnlDetails.Controls.Add(this.btnStartLinking);
            this.pnlDetails.Controls.Add(this.lblStatus);
            this.pnlDetails.Controls.Add(this.lblDob);
            this.pnlDetails.Controls.Add(this.lblGender);
            this.pnlDetails.Controls.Add(this.lblName);
            this.pnlDetails.Controls.Add(this.pnlResultHeader);
            this.pnlDetails.Location = new System.Drawing.Point(60, 185);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(450, 400);
            this.pnlDetails.TabIndex = 3;
            this.pnlDetails.Visible = false;
            // 
            // btnStartLinking
            // 
            this.btnStartLinking.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStartLinking.FlatAppearance.BorderSize = 0;
            this.btnStartLinking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartLinking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnStartLinking.ForeColor = System.Drawing.Color.White;
            this.btnStartLinking.Location = new System.Drawing.Point(30, 210);
            this.btnStartLinking.Name = "btnStartLinking";
            this.btnStartLinking.Size = new System.Drawing.Size(390, 45);
            this.btnStartLinking.TabIndex = 5;
            this.btnStartLinking.Text = "START OTP LINKING (M2)";
            this.btnStartLinking.UseVisualStyleBackColor = false;
            this.btnStartLinking.Click += new System.EventHandler(this.btnStartLinking_Click);
            // 
            // btnWritePrescription
            // 
            this.btnWritePrescription.BackColor = System.Drawing.Color.SeaGreen;
            this.btnWritePrescription.FlatAppearance.BorderSize = 0;
            this.btnWritePrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWritePrescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWritePrescription.ForeColor = System.Drawing.Color.White;
            this.btnWritePrescription.Location = new System.Drawing.Point(30, 260);
            this.btnWritePrescription.Name = "btnWritePrescription";
            this.btnWritePrescription.Size = new System.Drawing.Size(390, 45);
            this.btnWritePrescription.TabIndex = 6;
            this.btnWritePrescription.Text = "WRITE PRESCRIPTION (M3)";
            this.btnWritePrescription.UseVisualStyleBackColor = false;
            this.btnWritePrescription.Visible = false;
            this.btnWritePrescription.Click += new System.EventHandler(this.btnWritePrescription_Click);
            // 
            // btnRequestConsent
            // 
            this.btnRequestConsent.BackColor = System.Drawing.Color.SlateGray;
            this.btnRequestConsent.FlatAppearance.BorderSize = 0;
            this.btnRequestConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRequestConsent.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRequestConsent.ForeColor = System.Drawing.Color.White;
            this.btnRequestConsent.Location = new System.Drawing.Point(30, 310);
            this.btnRequestConsent.Name = "btnRequestConsent";
            this.btnRequestConsent.Size = new System.Drawing.Size(190, 45);
            this.btnRequestConsent.TabIndex = 7;
            this.btnRequestConsent.Text = "REQUEST ACCESS";
            this.btnRequestConsent.UseVisualStyleBackColor = false;
            this.btnRequestConsent.Visible = false;
            this.btnRequestConsent.Click += new System.EventHandler(this.btnRequestAccess_Click);
            // 
            // btnViewHistory
            // 
            this.btnViewHistory.BackColor = System.Drawing.Color.DarkOrchid;
            this.btnViewHistory.FlatAppearance.BorderSize = 0;
            this.btnViewHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewHistory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewHistory.Location = new System.Drawing.Point(230, 310);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(190, 45);
            this.btnViewHistory.TabIndex = 8;
            this.btnViewHistory.Text = "VIEW FOLDER";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Visible = false;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(30, 160);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 19);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Not Linked";
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDob.ForeColor = System.Drawing.Color.DimGray;
            this.lblDob.Location = new System.Drawing.Point(30, 130);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(128, 19);
            this.lblDob.TabIndex = 3;
            this.lblDob.Text = "DOB: 1990-01-01";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.ForeColor = System.Drawing.Color.DimGray;
            this.lblGender.Location = new System.Drawing.Point(30, 100);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(81, 19);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender: M";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(30, 60);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(155, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "RAVI KUMAR JP";
            // 
            // pnlResultHeader
            // 
            this.pnlResultHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlResultHeader.Controls.Add(this.label2);
            this.pnlResultHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResultHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlResultHeader.Name = "pnlResultHeader";
            this.pnlResultHeader.Size = new System.Drawing.Size(448, 40);
            this.pnlResultHeader.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "PATIENT PROFILE";
            // 
            // PatientSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(580, 680);
            this.Controls.Add(this.btnShowRegistration);
            this.Controls.Add(this.btnM3Dashboard);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.btnShowInvite);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchAbha);
            this.Controls.Add(this.label1);
            this.Name = "PatientSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABDM Dashboard";
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.pnlResultHeader.ResumeLayout(false);
            this.pnlResultHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchAbha;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Panel pnlResultHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDob;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnStartLinking;
        private System.Windows.Forms.Button btnShowInvite;
        private System.Windows.Forms.Button btnViewLogs;
        private System.Windows.Forms.Button btnM3Dashboard;
        private System.Windows.Forms.Button btnWritePrescription;
        private System.Windows.Forms.Button btnShowRegistration;
        private System.Windows.Forms.Button btnRequestConsent;
        private System.Windows.Forms.Button btnViewHistory;
    }
}
