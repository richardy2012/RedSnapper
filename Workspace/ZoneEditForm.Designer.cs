namespace RedSnapper
{
    partial class ZoneEditForm
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
            this.statsPanel = new System.Windows.Forms.Panel();
            this.windowHeightLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.windowWidthLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.windowTopLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.windowLeftLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.shouldTrack = new System.Windows.Forms.CheckBox();
            this.replay = new System.Windows.Forms.Button();
            this.movementData = new System.Windows.Forms.ListView();
            this.xcol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ycol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jumpXCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.jumpYCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statsPanel
            // 
            this.statsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.statsPanel.Controls.Add(this.windowHeightLabel);
            this.statsPanel.Controls.Add(this.label8);
            this.statsPanel.Controls.Add(this.windowWidthLabel);
            this.statsPanel.Controls.Add(this.label6);
            this.statsPanel.Controls.Add(this.windowTopLabel);
            this.statsPanel.Controls.Add(this.label4);
            this.statsPanel.Controls.Add(this.windowLeftLabel);
            this.statsPanel.Controls.Add(this.label1);
            this.statsPanel.Location = new System.Drawing.Point(306, 12);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(95, 59);
            this.statsPanel.TabIndex = 0;
            // 
            // windowHeightLabel
            // 
            this.windowHeightLabel.AutoSize = true;
            this.windowHeightLabel.Location = new System.Drawing.Point(44, 39);
            this.windowHeightLabel.Name = "windowHeightLabel";
            this.windowHeightLabel.Size = new System.Drawing.Size(13, 13);
            this.windowHeightLabel.TabIndex = 7;
            this.windowHeightLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Height";
            // 
            // windowWidthLabel
            // 
            this.windowWidthLabel.AutoSize = true;
            this.windowWidthLabel.Location = new System.Drawing.Point(44, 26);
            this.windowWidthLabel.Name = "windowWidthLabel";
            this.windowWidthLabel.Size = new System.Drawing.Size(13, 13);
            this.windowWidthLabel.TabIndex = 5;
            this.windowWidthLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Width";
            // 
            // windowTopLabel
            // 
            this.windowTopLabel.AutoSize = true;
            this.windowTopLabel.Location = new System.Drawing.Point(44, 13);
            this.windowTopLabel.Name = "windowTopLabel";
            this.windowTopLabel.Size = new System.Drawing.Size(13, 13);
            this.windowTopLabel.TabIndex = 3;
            this.windowTopLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Top";
            // 
            // windowLeftLabel
            // 
            this.windowLeftLabel.AutoSize = true;
            this.windowLeftLabel.Location = new System.Drawing.Point(44, 0);
            this.windowLeftLabel.Name = "windowLeftLabel";
            this.windowLeftLabel.Size = new System.Drawing.Size(13, 13);
            this.windowLeftLabel.TabIndex = 1;
            this.windowLeftLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Left";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(164, 426);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(326, 426);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(245, 426);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // shouldTrack
            // 
            this.shouldTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shouldTrack.AutoSize = true;
            this.shouldTrack.Location = new System.Drawing.Point(245, 397);
            this.shouldTrack.Name = "shouldTrack";
            this.shouldTrack.Size = new System.Drawing.Size(54, 17);
            this.shouldTrack.TabIndex = 3;
            this.shouldTrack.Text = "Track";
            this.shouldTrack.UseVisualStyleBackColor = true;
            this.shouldTrack.Visible = false;
            // 
            // replay
            // 
            this.replay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.replay.Location = new System.Drawing.Point(326, 397);
            this.replay.Name = "replay";
            this.replay.Size = new System.Drawing.Size(75, 23);
            this.replay.TabIndex = 4;
            this.replay.Text = "replay";
            this.replay.UseVisualStyleBackColor = true;
            this.replay.Visible = false;
            this.replay.Click += new System.EventHandler(this.replay_Click);
            // 
            // movementData
            // 
            this.movementData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.movementData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.xcol,
            this.ycol,
            this.jumpXCol,
            this.jumpYCol});
            this.movementData.Location = new System.Drawing.Point(12, 12);
            this.movementData.Name = "movementData";
            this.movementData.Size = new System.Drawing.Size(191, 402);
            this.movementData.TabIndex = 5;
            this.movementData.UseCompatibleStateImageBehavior = false;
            this.movementData.View = System.Windows.Forms.View.Details;
            this.movementData.Visible = false;
            // 
            // xcol
            // 
            this.xcol.Text = "x";
            this.xcol.Width = 30;
            // 
            // ycol
            // 
            this.ycol.Text = "y";
            this.ycol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ycol.Width = 30;
            // 
            // jumpXCol
            // 
            this.jumpXCol.Text = "jumpX";
            this.jumpXCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jumpXCol.Width = 48;
            // 
            // jumpYCol
            // 
            this.jumpYCol.Text = "jump Y";
            this.jumpYCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.jumpYCol.Width = 48;
            // 
            // ZoneEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 461);
            this.Controls.Add(this.movementData);
            this.Controls.Add(this.replay);
            this.Controls.Add(this.shouldTrack);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.statsPanel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "ZoneEditForm";
            this.Opacity = 0.82D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.ZoneEditForm_Load);
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label windowHeightLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label windowWidthLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label windowTopLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label windowLeftLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.CheckBox shouldTrack;
        private System.Windows.Forms.Button replay;
        private System.Windows.Forms.ListView movementData;
        private System.Windows.Forms.ColumnHeader xcol;
        private System.Windows.Forms.ColumnHeader ycol;
        private System.Windows.Forms.ColumnHeader jumpXCol;
        private System.Windows.Forms.ColumnHeader jumpYCol;

    }
}