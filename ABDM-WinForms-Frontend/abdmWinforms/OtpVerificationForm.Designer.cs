namespace abdmWinforms
{
    partial class OtpVerificationForm
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
            this.pnlOtpCard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOtp = new System.Windows.Forms.TextBox();
            this.btnConfirmLink = new System.Windows.Forms.Button();
            this.pnlOtpCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlOtpCard
            // 
            this.pnlOtpCard.BackColor = System.Drawing.Color.White;
            this.pnlOtpCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOtpCard.Controls.Add(this.label1);
            this.pnlOtpCard.Controls.Add(this.label2);
            this.pnlOtpCard.Controls.Add(this.txtOtp);
            this.pnlOtpCard.Controls.Add(this.btnConfirmLink);
            this.pnlOtpCard.Location = new System.Drawing.Point(40, 30);
            this.pnlOtpCard.Name = "pnlOtpCard";
            this.pnlOtpCard.Size = new System.Drawing.Size(350, 250);
            this.pnlOtpCard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(100, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Confirm OTP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter 6-Digit OTP";
            // 
            // txtOtp
            // 
            this.txtOtp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtOtp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtp.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.txtOtp.Location = new System.Drawing.Point(30, 100);
            this.txtOtp.MaxLength = 6;
            this.txtOtp.Name = "txtOtp";
            this.txtOtp.Size = new System.Drawing.Size(290, 36);
            this.txtOtp.TabIndex = 2;
            this.txtOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnConfirmLink
            // 
            this.btnConfirmLink.BackColor = System.Drawing.Color.SeaGreen;
            this.btnConfirmLink.FlatAppearance.BorderSize = 0;
            this.btnConfirmLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmLink.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmLink.ForeColor = System.Drawing.Color.White;
            this.btnConfirmLink.Location = new System.Drawing.Point(30, 170);
            this.btnConfirmLink.Name = "btnConfirmLink";
            this.btnConfirmLink.Size = new System.Drawing.Size(290, 45);
            this.btnConfirmLink.TabIndex = 3;
            this.btnConfirmLink.Text = "LINK ACCOUNT";
            this.btnConfirmLink.UseVisualStyleBackColor = false;
            this.btnConfirmLink.Click += new System.EventHandler(this.btnConfirmLink_Click);
            // 
            // OtpVerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(430, 310);
            this.Controls.Add(this.pnlOtpCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OtpVerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Verify ABDM Token";
            this.pnlOtpCard.ResumeLayout(false);
            this.pnlOtpCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlOtpCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOtp;
        private System.Windows.Forms.Button btnConfirmLink;
    }
}
