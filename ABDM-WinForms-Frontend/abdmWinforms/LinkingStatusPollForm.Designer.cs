namespace abdmWinforms
{
    partial class LinkingStatusPollForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCurrentStep;
        private System.Windows.Forms.Label lblRequestId;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox picLoading;

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
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCurrentStep = new System.Windows.Forms.Label();
            this.lblRequestId = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(431, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Awaiting Approval from ABHA";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.ForeColor = System.Drawing.Color.LightGray;
            this.lblStatus.Location = new System.Drawing.Point(35, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(400, 23);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Please check your ABHA / PHR app for notification.";
            // 
            // lblCurrentStep
            // 
            this.lblCurrentStep.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStep.ForeColor = System.Drawing.Color.SkyBlue;
            this.lblCurrentStep.Location = new System.Drawing.Point(35, 160);
            this.lblCurrentStep.Name = "lblCurrentStep";
            this.lblCurrentStep.Size = new System.Drawing.Size(450, 35);
            this.lblCurrentStep.TabIndex = 2;
            this.lblCurrentStep.Text = "INITIALIZING...";
            this.lblCurrentStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRequestId
            // 
            this.lblRequestId.AutoSize = true;
            this.lblRequestId.Font = new System.Drawing.Font("Consolas", 8F);
            this.lblRequestId.ForeColor = System.Drawing.Color.Gray;
            this.lblRequestId.Location = new System.Drawing.Point(37, 240);
            this.lblRequestId.Name = "lblRequestId";
            this.lblRequestId.Size = new System.Drawing.Size(64, 17);
            this.lblRequestId.TabIndex = 3;
            this.lblRequestId.Text = "Req ID: ";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(40, 130);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 15);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(180, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // LinkingStatusPollForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(520, 350);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblRequestId);
            this.Controls.Add(this.lblCurrentStep);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LinkingStatusPollForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Approving Link";
            this.Load += new System.EventHandler(this.LinkingStatusPollForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
