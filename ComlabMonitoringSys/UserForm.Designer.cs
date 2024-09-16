namespace ComlabMonitoringSys
{
    partial class UserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RealTImeTimer = new System.Windows.Forms.Timer(this.components);
            this.PCNameLabel = new System.Windows.Forms.Label();
            this.UserLabel = new System.Windows.Forms.Label();
            this.TimeInLabel = new System.Windows.Forms.Label();
            this.RealTime = new System.Windows.Forms.Label();
            this.RealTimerLabel2 = new System.Windows.Forms.Label();
            this.TimeInLabel2 = new System.Windows.Forms.Label();
            this.PCNameLabel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(538, 90);
            this.label1.TabIndex = 0;
            this.label1.Text = "NBSPI Computer Lab Management \r\nand Monitoring System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(347, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Empowering Laboratories with Efficient \nManagement and Real-time Monitoring";
            // 
            // RealTImeTimer
            // 
            this.RealTImeTimer.Tick += new System.EventHandler(this.RealTImeTimer_Tick);
            // 
            // PCNameLabel
            // 
            this.PCNameLabel.AutoSize = true;
            this.PCNameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCNameLabel.Location = new System.Drawing.Point(26, 215);
            this.PCNameLabel.Name = "PCNameLabel";
            this.PCNameLabel.Size = new System.Drawing.Size(132, 32);
            this.PCNameLabel.TabIndex = 5;
            this.PCNameLabel.Text = "PC Name :";
            // 
            // UserLabel
            // 
            this.UserLabel.AutoSize = true;
            this.UserLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserLabel.Location = new System.Drawing.Point(26, 265);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(112, 32);
            this.UserLabel.TabIndex = 6;
            this.UserLabel.Text = "User ID :";
            // 
            // TimeInLabel
            // 
            this.TimeInLabel.AutoSize = true;
            this.TimeInLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeInLabel.Location = new System.Drawing.Point(26, 317);
            this.TimeInLabel.Name = "TimeInLabel";
            this.TimeInLabel.Size = new System.Drawing.Size(114, 32);
            this.TimeInLabel.TabIndex = 7;
            this.TimeInLabel.Text = "Time In :";
            // 
            // RealTime
            // 
            this.RealTime.AutoSize = true;
            this.RealTime.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealTime.Location = new System.Drawing.Point(26, 366);
            this.RealTime.Name = "RealTime";
            this.RealTime.Size = new System.Drawing.Size(139, 32);
            this.RealTime.TabIndex = 8;
            this.RealTime.Text = "Real Time :";
            // 
            // RealTimerLabel2
            // 
            this.RealTimerLabel2.AutoSize = true;
            this.RealTimerLabel2.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RealTimerLabel2.Location = new System.Drawing.Point(155, 366);
            this.RealTimerLabel2.Name = "RealTimerLabel2";
            this.RealTimerLabel2.Size = new System.Drawing.Size(373, 32);
            this.RealTimerLabel2.TabIndex = 10;
            this.RealTimerLabel2.Text = "dddd, dd MMMM yyyy HH:mm:ss";
            // 
            // TimeInLabel2
            // 
            this.TimeInLabel2.AutoSize = true;
            this.TimeInLabel2.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeInLabel2.Location = new System.Drawing.Point(155, 317);
            this.TimeInLabel2.Name = "TimeInLabel2";
            this.TimeInLabel2.Size = new System.Drawing.Size(373, 32);
            this.TimeInLabel2.TabIndex = 11;
            this.TimeInLabel2.Text = "dddd, dd MMMM yyyy HH:mm:ss";
            // 
            // PCNameLabel2
            // 
            this.PCNameLabel2.AutoSize = true;
            this.PCNameLabel2.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCNameLabel2.Location = new System.Drawing.Point(153, 215);
            this.PCNameLabel2.Name = "PCNameLabel2";
            this.PCNameLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PCNameLabel2.Size = new System.Drawing.Size(175, 32);
            this.PCNameLabel2.TabIndex = 12;
            this.PCNameLabel2.Text = "ComLab 1 PC-5";
            this.PCNameLabel2.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Variable Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 265);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(129, 32);
            this.label4.TabIndex = 13;
            this.label4.Text = "C20210080";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ComlabMonitoringSys.Properties.Resources.exclamation_circle;
            this.pictureBox1.Location = new System.Drawing.Point(32, 465);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 40);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 538);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PCNameLabel2);
            this.Controls.Add(this.TimeInLabel2);
            this.Controls.Add(this.RealTimerLabel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.RealTime);
            this.Controls.Add(this.TimeInLabel);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.PCNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer RealTImeTimer;
        private System.Windows.Forms.Label PCNameLabel;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Label TimeInLabel;
        private System.Windows.Forms.Label RealTime;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label RealTimerLabel2;
        private System.Windows.Forms.Label TimeInLabel2;
        private System.Windows.Forms.Label PCNameLabel2;
        private System.Windows.Forms.Label label4;
    }
}