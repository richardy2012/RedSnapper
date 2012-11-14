namespace RedSnapper
{
    partial class HookManagerTest
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
            this.scanFreq = new System.Windows.Forms.Label();
            this.mouseInterval = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.debugText = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.mouseInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // scanFreq
            // 
            this.scanFreq.Location = new System.Drawing.Point(110, 9);
            this.scanFreq.Name = "scanFreq";
            this.scanFreq.Size = new System.Drawing.Size(48, 13);
            this.scanFreq.TabIndex = 1;
            this.scanFreq.Text = "5ms";
            this.scanFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mouseInterval
            // 
            this.mouseInterval.Location = new System.Drawing.Point(19, 189);
            this.mouseInterval.Name = "mouseInterval";
            this.mouseInterval.Size = new System.Drawing.Size(253, 45);
            this.mouseInterval.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Scan Frequency:";
            // 
            // debugText
            // 
            this.debugText.AcceptsReturn = true;
            this.debugText.Location = new System.Drawing.Point(19, 31);
            this.debugText.Multiline = true;
            this.debugText.Name = "debugText";
            this.debugText.Size = new System.Drawing.Size(253, 152);
            this.debugText.TabIndex = 3;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 240);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(253, 160);
            this.listBox1.TabIndex = 4;
            // 
            // HookManagerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 410);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.debugText);
            this.Controls.Add(this.mouseInterval);
            this.Controls.Add(this.scanFreq);
            this.Controls.Add(this.label1);
            this.Name = "HookManagerTest";
            this.Text = "HookManagerTest";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.mouseInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scanFreq;
        private System.Windows.Forms.TrackBar mouseInterval;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox debugText;
        private System.Windows.Forms.ListBox listBox1;
    }
}