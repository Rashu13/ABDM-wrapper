namespace abdmWinforms
{
    partial class SmsInviteForm
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSendInvite = new System.Windows.Forms.Button();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.label1);
            this.pnlCard.Controls.Add(this.label2);
            this.pnlCard.Controls.Add(this.txtMobile);
            this.pnlCard.Controls.Add(this.label3);
            this.pnlCard.Controls.Add(this.txtName);
            this.pnlCard.Controls.Add(this.btnSendInvite);
            this.pnlCard.Location = new System.Drawing.Point(40, 30);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(350, 320);
            this.pnlCard.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SeaGreen;
            this.label1.Location = new System.Drawing.Point(60, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invite via ABDM SMS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(30, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter Mobile Number";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMobile.Location = new System.Drawing.Point(30, 100);
            this.txtMobile.MaxLength = 10;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(290, 29);
            this.txtMobile.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(30, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Patient Name (Opt)";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtName.Location = new System.Drawing.Point(30, 170);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(290, 29);
            this.txtName.TabIndex = 4;
            // 
            // btnSendInvite
            // 
            this.btnSendInvite.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSendInvite.FlatAppearance.BorderSize = 0;
            this.btnSendInvite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendInvite.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendInvite.ForeColor = System.Drawing.Color.White;
            this.btnSendInvite.Location = new System.Drawing.Point(30, 240);
            this.btnSendInvite.Name = "btnSendInvite";
            this.btnSendInvite.Size = new System.Drawing.Size(290, 45);
            this.btnSendInvite.TabIndex = 5;
            this.btnSendInvite.Text = "SEND JOINING LINK";
            this.btnSendInvite.UseVisualStyleBackColor = false;
            this.btnSendInvite.Click += new System.EventHandler(this.btnSendInvite_Click);
            // 
            // SmsInviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(430, 380);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SmsInviteForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ABDM SMS Invitations";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSendInvite;
    }
}
