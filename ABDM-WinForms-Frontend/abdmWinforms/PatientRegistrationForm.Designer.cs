namespace abdmWinforms
{
    partial class PatientRegistrationForm
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblSubHeader = new System.Windows.Forms.Label();
            this.pnlHeaderDivider = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbhaAddress = new System.Windows.Forms.TextBox();
            this.labelAbhaNumber = new System.Windows.Forms.Label();
            this.txtAbhaNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.labelMobile = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.btnGenerateToken = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.lblSubHeader);
            this.pnlCard.Controls.Add(this.pnlHeaderDivider);
            this.pnlCard.Controls.Add(this.label1);
            this.pnlCard.Controls.Add(this.label2);
            this.pnlCard.Controls.Add(this.txtAbhaAddress);
            this.pnlCard.Controls.Add(this.labelAbhaNumber);
            this.pnlCard.Controls.Add(this.txtAbhaNumber);
            this.pnlCard.Controls.Add(this.label3);
            this.pnlCard.Controls.Add(this.txtName);
            this.pnlCard.Controls.Add(this.label4);
            this.pnlCard.Controls.Add(this.cmbGender);
            this.pnlCard.Controls.Add(this.label5);
            this.pnlCard.Controls.Add(this.dtpDob);
            this.pnlCard.Controls.Add(this.labelMobile);
            this.pnlCard.Controls.Add(this.txtMobile);
            this.pnlCard.Controls.Add(this.btnGenerateToken);
            this.pnlCard.Location = new System.Drawing.Point(60, 40);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(500, 715);
            this.pnlCard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.label1.Location = new System.Drawing.Point(125, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Demographic Auth";
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.Gray;
            this.lblSubHeader.Location = new System.Drawing.Point(145, 52);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(210, 15);
            this.lblSubHeader.TabIndex = 14;
            this.lblSubHeader.Text = "Verify health identity with M3 Gateway";
            // 
            // pnlHeaderDivider
            // 
            this.pnlHeaderDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.pnlHeaderDivider.Location = new System.Drawing.Point(40, 75);
            this.pnlHeaderDivider.Name = "pnlHeaderDivider";
            this.pnlHeaderDivider.Size = new System.Drawing.Size(420, 2);
            this.pnlHeaderDivider.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(40, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "ABHA Address *";
            // 
            // txtAbhaAddress
            // 
            this.txtAbhaAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtAbhaAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAbhaAddress.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAbhaAddress.Location = new System.Drawing.Point(40, 115);
            this.txtAbhaAddress.Name = "txtAbhaAddress";
            this.txtAbhaAddress.Size = new System.Drawing.Size(420, 27);
            this.txtAbhaAddress.TabIndex = 2;
            this.txtAbhaAddress.Text = "7015750927@sbx";
            // 
            // labelAbhaNumber
            // 
            this.labelAbhaNumber.AutoSize = true;
            this.labelAbhaNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelAbhaNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAbhaNumber.Location = new System.Drawing.Point(40, 160);
            this.labelAbhaNumber.Name = "labelAbhaNumber";
            this.labelAbhaNumber.Size = new System.Drawing.Size(95, 15);
            this.labelAbhaNumber.TabIndex = 12;
            this.labelAbhaNumber.Text = "ABHA Number *";
            // 
            // txtAbhaNumber
            // 
            this.txtAbhaNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtAbhaNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAbhaNumber.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtAbhaNumber.Location = new System.Drawing.Point(40, 180);
            this.txtAbhaNumber.Name = "txtAbhaNumber";
            this.txtAbhaNumber.Size = new System.Drawing.Size(420, 27);
            this.txtAbhaNumber.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(40, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name *";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Location = new System.Drawing.Point(40, 245);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(420, 27);
            this.txtName.TabIndex = 4;
            this.txtName.Text = "Ravi Kumar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(40, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Gender *";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cmbGender.Location = new System.Drawing.Point(40, 310);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(420, 28);
            this.cmbGender.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(40, 355);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Date of Birth *";
            // 
            // dtpDob
            // 
            this.dtpDob.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(40, 375);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(420, 27);
            this.dtpDob.TabIndex = 8;
            this.dtpDob.Value = new System.DateTime(1994, 3, 27, 0, 0, 0, 0);
            // 
            // labelMobile
            // 
            this.labelMobile.AutoSize = true;
            this.labelMobile.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.labelMobile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelMobile.Location = new System.Drawing.Point(40, 420);
            this.labelMobile.Name = "labelMobile";
            this.labelMobile.Size = new System.Drawing.Size(99, 15);
            this.labelMobile.TabIndex = 10;
            this.labelMobile.Text = "Mobile Number *";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtMobile.Location = new System.Drawing.Point(40, 440);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(420, 27);
            this.txtMobile.TabIndex = 11;
            this.txtMobile.Text = "9416056193";
            // 
            // btnGenerateToken
            // 
            this.btnGenerateToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnGenerateToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateToken.FlatAppearance.BorderSize = 0;
            this.btnGenerateToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateToken.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerateToken.ForeColor = System.Drawing.Color.White;
            this.btnGenerateToken.Location = new System.Drawing.Point(40, 500);
            this.btnGenerateToken.Name = "btnGenerateToken";
            this.btnGenerateToken.Size = new System.Drawing.Size(420, 50);
            this.btnGenerateToken.TabIndex = 9;
            this.btnGenerateToken.Text = "GENERATE TOKEN";
            this.btnGenerateToken.UseVisualStyleBackColor = false;
            this.btnGenerateToken.Click += new System.EventHandler(this.btnGenerateToken_Click);
            // 
            // PatientRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(600, 780);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PatientRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABDM Demographic Authentication";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbhaAddress;
        private System.Windows.Forms.Label labelAbhaNumber;
        private System.Windows.Forms.TextBox txtAbhaNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.Label labelMobile;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Button btnGenerateToken;
        private System.Windows.Forms.Label lblSubHeader;
        private System.Windows.Forms.Panel pnlHeaderDivider;

        #endregion
    }
}

