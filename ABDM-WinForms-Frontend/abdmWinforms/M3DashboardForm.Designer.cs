namespace abdmWinforms
{
    partial class M3DashboardForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlLogHeader = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lstActivities = new System.Windows.Forms.ListBox();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConsentCount = new System.Windows.Forms.Label();
            this.tmrLiveFeed = new System.Windows.Forms.Timer(this.components);
            this.pnlLogHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(30, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "ABDM M3 Dashboard";
            // 
            // pnlLogHeader
            // 
            this.pnlLogHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlLogHeader.Controls.Add(this.label2);
            this.pnlLogHeader.Location = new System.Drawing.Point(400, 80);
            this.pnlLogHeader.Name = "pnlLogHeader";
            this.pnlLogHeader.Size = new System.Drawing.Size(430, 40);
            this.pnlLogHeader.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(10, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "LIVE GATEWAY MONITOR";
            // 
            // lstActivities
            // 
            this.lstActivities.BackColor = System.Drawing.Color.Black;
            this.lstActivities.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstActivities.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstActivities.ForeColor = System.Drawing.Color.LimeGreen;
            this.lstActivities.FormattingEnabled = true;
            this.lstActivities.ItemHeight = 15;
            this.lstActivities.Location = new System.Drawing.Point(400, 120);
            this.lstActivities.Name = "lstActivities";
            this.lstActivities.Size = new System.Drawing.Size(430, 405);
            this.lstActivities.TabIndex = 2;
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.White;
            this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStats.Controls.Add(this.lblConsentCount);
            this.pnlStats.Controls.Add(this.label3);
            this.pnlStats.Location = new System.Drawing.Point(30, 80);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(340, 445);
            this.pnlStats.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "ACTIVE STATUS";
            // 
            // lblConsentCount
            // 
            this.lblConsentCount.AutoSize = true;
            this.lblConsentCount.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblConsentCount.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblConsentCount.Location = new System.Drawing.Point(20, 60);
            this.lblConsentCount.Name = "lblConsentCount";
            this.lblConsentCount.Size = new System.Drawing.Size(155, 19);
            this.lblConsentCount.TabIndex = 1;
            this.lblConsentCount.Text = "- Consents Granted: 0";
            // 
            // tmrLiveFeed
            // 
            this.tmrLiveFeed.Enabled = true;
            this.tmrLiveFeed.Interval = 5000;
            this.tmrLiveFeed.Tick += new System.EventHandler(this.tmrLiveFeed_Tick);
            // 
            // M3DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.lstActivities);
            this.Controls.Add(this.pnlLogHeader);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "M3DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABDM M3 Sandbox Control Center";
            this.pnlLogHeader.ResumeLayout(false);
            this.pnlLogHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlLogHeader;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstActivities;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConsentCount;
        private System.Windows.Forms.Timer tmrLiveFeed;
    }
}
