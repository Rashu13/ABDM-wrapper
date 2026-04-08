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
            this.components = new System.ComponentModel.Container();
            this.txtSearchAbha = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnShowInvite = new System.Windows.Forms.Button();
            this.btnViewLogs = new System.Windows.Forms.Button();
            this.btnShowRegistration = new System.Windows.Forms.Button();
            this.btnWritePrescription = new System.Windows.Forms.Button();
            this.btnRequestConsent = new System.Windows.Forms.Button();
            this.btnDirectConsent = new System.Windows.Forms.Button();
            this.btnViewHistory = new System.Windows.Forms.Button();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.btnStartLinking = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDob = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlResultHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrLiveFeed = new System.Windows.Forms.Timer(this.components);
            this.lstLiveActivities = new System.Windows.Forms.ListBox();
            this.pnlDetails.SuspendLayout();
            this.pnlResultHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchAbha
            // 
            this.txtSearchAbha.BackColor = System.Drawing.Color.White;
            this.txtSearchAbha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchAbha.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.txtSearchAbha.ForeColor = System.Drawing.Color.DimGray;
            this.txtSearchAbha.Location = new System.Drawing.Point(78, 50);
            this.txtSearchAbha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSearchAbha.Name = "txtSearchAbha";
            this.txtSearchAbha.Size = new System.Drawing.Size(426, 39);
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
            this.btnSearch.Location = new System.Drawing.Point(518, 50);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 41);
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
            this.btnShowInvite.Location = new System.Drawing.Point(518, 14);
            this.btnShowInvite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowInvite.Name = "btnShowInvite";
            this.btnShowInvite.Size = new System.Drawing.Size(160, 28);
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
            this.btnViewLogs.Location = new System.Drawing.Point(77, 497);
            this.btnViewLogs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewLogs.Name = "btnViewLogs";
            this.btnViewLogs.Size = new System.Drawing.Size(600, 49);
            this.btnViewLogs.TabIndex = 6;
            this.btnViewLogs.Text = "VIEW ACTIVITY LOGS / FULL LIST";
            this.btnViewLogs.UseVisualStyleBackColor = false;
            this.btnViewLogs.Click += new System.EventHandler(this.btnViewLogs_Click);
            // 
            // btnShowRegistration
            // 
            this.btnShowRegistration.BackColor = System.Drawing.Color.DimGray;
            this.btnShowRegistration.FlatAppearance.BorderSize = 0;
            this.btnShowRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowRegistration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowRegistration.ForeColor = System.Drawing.Color.White;
            this.btnShowRegistration.Location = new System.Drawing.Point(78, 99);
            this.btnShowRegistration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowRegistration.Name = "btnShowRegistration";
            this.btnShowRegistration.Size = new System.Drawing.Size(600, 43);
            this.btnShowRegistration.TabIndex = 9;
            this.btnShowRegistration.Text = "➕  REGISTER NEW PATIENT (If Not Found)";
            this.btnShowRegistration.UseVisualStyleBackColor = false;
            this.btnShowRegistration.Click += new System.EventHandler(this.btnShowRegistration_Click);
            // 
            // btnWritePrescription
            // 
            this.btnWritePrescription.BackColor = System.Drawing.Color.SeaGreen;
            this.btnWritePrescription.FlatAppearance.BorderSize = 0;
            this.btnWritePrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWritePrescription.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnWritePrescription.ForeColor = System.Drawing.Color.White;
            this.btnWritePrescription.Location = new System.Drawing.Point(302, 202);
            this.btnWritePrescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWritePrescription.Name = "btnWritePrescription";
            this.btnWritePrescription.Size = new System.Drawing.Size(263, 55);
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
            this.btnRequestConsent.Location = new System.Drawing.Point(40, 265);
            this.btnRequestConsent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRequestConsent.Name = "btnRequestConsent";
            this.btnRequestConsent.Size = new System.Drawing.Size(253, 55);
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
            this.btnViewHistory.Location = new System.Drawing.Point(312, 265);
            this.btnViewHistory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewHistory.Name = "btnViewHistory";
            this.btnViewHistory.Size = new System.Drawing.Size(253, 55);
            this.btnViewHistory.TabIndex = 8;
            this.btnViewHistory.Text = "VIEW FOLDER";
            this.btnViewHistory.UseVisualStyleBackColor = false;
            this.btnViewHistory.Visible = false;
            this.btnViewHistory.Click += new System.EventHandler(this.btnViewHistory_Click);
            // 
            // btnDirectConsent
            // 
            this.btnDirectConsent.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDirectConsent.FlatAppearance.BorderSize = 0;
            this.btnDirectConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDirectConsent.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDirectConsent.ForeColor = System.Drawing.Color.White;
            this.btnDirectConsent.Location = new System.Drawing.Point(685, 50);
            this.btnDirectConsent.Name = "btnDirectConsent";
            this.btnDirectConsent.Size = new System.Drawing.Size(200, 41);
            this.btnDirectConsent.TabIndex = 10;
            this.btnDirectConsent.Text = "DIRECT CONSENT";
            this.btnDirectConsent.UseVisualStyleBackColor = false;
            this.btnDirectConsent.Click += new System.EventHandler(this.btnDirectConsent_Click);
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
            this.pnlDetails.Location = new System.Drawing.Point(78, 155);
            this.pnlDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(599, 334);
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
            this.btnStartLinking.Location = new System.Drawing.Point(41, 202);
            this.btnStartLinking.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartLinking.Name = "btnStartLinking";
            this.btnStartLinking.Size = new System.Drawing.Size(253, 55);
            this.btnStartLinking.TabIndex = 5;
            this.btnStartLinking.Text = "START OTP LINKING (M2)";
            this.btnStartLinking.UseVisualStyleBackColor = false;
            this.btnStartLinking.Click += new System.EventHandler(this.btnStartLinking_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblStatus.Location = new System.Drawing.Point(35, 176);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: Not Linked";
            // 
            // lblDob
            // 
            this.lblDob.AutoSize = true;
            this.lblDob.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDob.ForeColor = System.Drawing.Color.DimGray;
            this.lblDob.Location = new System.Drawing.Point(35, 139);
            this.lblDob.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDob.Name = "lblDob";
            this.lblDob.Size = new System.Drawing.Size(140, 23);
            this.lblDob.TabIndex = 3;
            this.lblDob.Text = "DOB: 1990-01-01";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblGender.ForeColor = System.Drawing.Color.DimGray;
            this.lblGender.Location = new System.Drawing.Point(35, 102);
            this.lblGender.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(90, 23);
            this.lblGender.TabIndex = 2;
            this.lblGender.Text = "Gender: M";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(35, 53);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(199, 32);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "RAVI KUMAR JP";
            // 
            // pnlResultHeader
            // 
            this.pnlResultHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlResultHeader.Controls.Add(this.label2);
            this.pnlResultHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResultHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlResultHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlResultHeader.Name = "pnlResultHeader";
            this.pnlResultHeader.Size = new System.Drawing.Size(707, 49);
            this.pnlResultHeader.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "PATIENT PROFILE";
            // 
            // tmrLiveFeed
            // 
            this.tmrLiveFeed.Enabled = true;
            this.tmrLiveFeed.Interval = 5000;
            this.tmrLiveFeed.Tick += new System.EventHandler(this.tmrLiveFeed_Tick);
            // 
            // lstLiveActivities
            // 
            this.lstLiveActivities.BackColor = System.Drawing.Color.Black;
            this.lstLiveActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLiveActivities.Font = new System.Drawing.Font("Consolas", 9F);
            this.lstLiveActivities.ForeColor = System.Drawing.Color.PaleGreen;
            this.lstLiveActivities.FormattingEnabled = true;
            this.lstLiveActivities.HorizontalScrollbar = true;
            this.lstLiveActivities.ItemHeight = 18;
            this.lstLiveActivities.Location = new System.Drawing.Point(-3, 554);
            this.lstLiveActivities.Margin = new System.Windows.Forms.Padding(4);
            this.lstLiveActivities.MultiColumn = true;
            this.lstLiveActivities.Name = "lstLiveActivities";
            this.lstLiveActivities.ScrollAlwaysVisible = true;
            this.lstLiveActivities.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstLiveActivities.Size = new System.Drawing.Size(1302, 252);
            this.lstLiveActivities.TabIndex = 1;
            // 
            // PatientSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1312, 789);
            this.Controls.Add(this.lstLiveActivities);
            this.Controls.Add(this.btnShowRegistration);
            this.Controls.Add(this.btnViewLogs);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.btnShowInvite);
            this.Controls.Add(this.btnDirectConsent);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearchAbha);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.Button btnDirectConsent;
        private System.Windows.Forms.Button btnViewHistory;
        private System.Windows.Forms.Timer tmrLiveFeed;
        private System.Windows.Forms.ListBox lstLiveActivities;
    }
}
