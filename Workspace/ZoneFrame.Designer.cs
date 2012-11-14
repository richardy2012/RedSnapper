namespace RedSnapper
{
    partial class ZoneFrame
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
            this.transparentPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // transparentPanel
            // 
            this.transparentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.transparentPanel.BackColor = System.Drawing.Color.Red;
            this.transparentPanel.Location = new System.Drawing.Point(3, 3);
            this.transparentPanel.Name = "transparentPanel";
            this.transparentPanel.Size = new System.Drawing.Size(277, 256);
            this.transparentPanel.TabIndex = 0;
            // 
            // ZoneFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.transparentPanel);
            this.Name = "ZoneFrame";
            this.Text = "ZoneFrame";
            this.TransparencyKey = System.Drawing.Color.Red;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel transparentPanel;

    }
}