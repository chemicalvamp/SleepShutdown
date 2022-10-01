namespace SleepShutdown
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.formUpdate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.directoryLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shutdownLabel = new System.Windows.Forms.Label();
            this.activityTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // formUpdate
            // 
            this.formUpdate.Enabled = true;
            this.formUpdate.Interval = 500;
            this.formUpdate.Tick += new System.EventHandler(this.formUpdate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monitoring:";
            // 
            // directoryLabel
            // 
            this.directoryLabel.AutoSize = true;
            this.directoryLabel.Location = new System.Drawing.Point(77, 9);
            this.directoryLabel.Name = "directoryLabel";
            this.directoryLabel.Size = new System.Drawing.Size(0, 13);
            this.directoryLabel.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Last Activity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Shutdown in:";
            // 
            // shutdownLabel
            // 
            this.shutdownLabel.AutoSize = true;
            this.shutdownLabel.Location = new System.Drawing.Point(100, 59);
            this.shutdownLabel.Name = "shutdownLabel";
            this.shutdownLabel.Size = new System.Drawing.Size(49, 13);
            this.shutdownLabel.TabIndex = 4;
            this.shutdownLabel.Text = "99:99:99";
            // 
            // activityTime
            // 
            this.activityTime.AutoSize = true;
            this.activityTime.Location = new System.Drawing.Point(100, 46);
            this.activityTime.Name = "activityTime";
            this.activityTime.Size = new System.Drawing.Size(68, 13);
            this.activityTime.TabIndex = 5;
            this.activityTime.Text = "99:99:99 PM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 80);
            this.Controls.Add(this.activityTime);
            this.Controls.Add(this.shutdownLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.directoryLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "SleepShutdown";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer formUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label directoryLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label shutdownLabel;
        private System.Windows.Forms.Label activityTime;
    }
}

