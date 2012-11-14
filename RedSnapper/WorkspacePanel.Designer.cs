namespace RedSnapper
{
    partial class WorkspacePanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkspacePanel));
            this.systray = new System.Windows.Forms.NotifyIcon(this.components);
            this.menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.showHelp = new System.Windows.Forms.Button();
            this.toggleEditMode = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.toggleRevealMode = new System.Windows.Forms.Button();
            this.quickHelpText = new System.Windows.Forms.Label();
            this.pointerPic = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pointerPic)).BeginInit();
            this.SuspendLayout();
            // 
            // systray
            // 
            this.systray.BalloonTipText = "Click to see workspace manager";
            this.systray.BalloonTipTitle = "RedSnapper";
            this.systray.Visible = true;
            this.systray.DoubleClick += new System.EventHandler(this.systray_DoubleClick);
            this.systray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.systray_MouseDoubleClick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPanel,
            this.toolStripMenuItem2,
            this.exitMenu});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(197, 54);
            // 
            // showPanel
            // 
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(196, 22);
            this.showPanel.Text = "Show Workspace Panel";
            this.showPanel.Click += new System.EventHandler(this.showPanel_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(196, 22);
            this.exitMenu.Text = "Exit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(379, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 28);
            this.label3.TabIndex = 19;
            this.label3.Text = "Help";
            // 
            // showHelp
            // 
            this.showHelp.Location = new System.Drawing.Point(472, 46);
            this.showHelp.Name = "showHelp";
            this.showHelp.Size = new System.Drawing.Size(82, 51);
            this.showHelp.TabIndex = 18;
            this.showHelp.Text = "Watch on Youtube";
            this.showHelp.UseVisualStyleBackColor = true;
            this.showHelp.Click += new System.EventHandler(this.showHelp_Click);
            // 
            // toggleEditMode
            // 
            this.toggleEditMode.Location = new System.Drawing.Point(284, 45);
            this.toggleEditMode.Name = "toggleEditMode";
            this.toggleEditMode.Size = new System.Drawing.Size(82, 51);
            this.toggleEditMode.TabIndex = 17;
            this.toggleEditMode.Text = "Edit Zones";
            this.toggleEditMode.UseVisualStyleBackColor = true;
            this.toggleEditMode.Click += new System.EventHandler(this.toggleEditMode_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(20, 45);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(82, 51);
            this.createButton.TabIndex = 13;
            this.createButton.Text = "Create Zone";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.create_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(108, 45);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(82, 51);
            this.openButton.TabIndex = 10;
            this.openButton.Text = "Open Workspace";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "Actions";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(196, 45);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(82, 51);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save Workspace";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toggleRevealMode
            // 
            this.toggleRevealMode.Location = new System.Drawing.Point(384, 45);
            this.toggleRevealMode.Name = "toggleRevealMode";
            this.toggleRevealMode.Size = new System.Drawing.Size(82, 51);
            this.toggleRevealMode.TabIndex = 14;
            this.toggleRevealMode.Text = "Reveal Zones";
            this.toggleRevealMode.UseVisualStyleBackColor = true;
            this.toggleRevealMode.Click += new System.EventHandler(this.reveal_Click);
            // 
            // quickHelpText
            // 
            this.quickHelpText.BackColor = System.Drawing.Color.LightGray;
            this.quickHelpText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.quickHelpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quickHelpText.Location = new System.Drawing.Point(22, 117);
            this.quickHelpText.Name = "quickHelpText";
            this.quickHelpText.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.quickHelpText.Size = new System.Drawing.Size(532, 42);
            this.quickHelpText.TabIndex = 20;
            // 
            // pointerPic
            // 
            this.pointerPic.BackColor = System.Drawing.SystemColors.Control;
            this.pointerPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pointerPic.Image = ((System.Drawing.Image)(resources.GetObject("pointerPic.Image")));
            this.pointerPic.Location = new System.Drawing.Point(44, 100);
            this.pointerPic.Name = "pointerPic";
            this.pointerPic.Size = new System.Drawing.Size(24, 24);
            this.pointerPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pointerPic.TabIndex = 21;
            this.pointerPic.TabStop = false;
            // 
            // WorkspacePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(572, 168);
            this.Controls.Add(this.pointerPic);
            this.Controls.Add(this.quickHelpText);
            this.Controls.Add(this.showHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.toggleEditMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.toggleRevealMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "WorkspacePanel";
            this.Text = "Red Snapper - Workspaces";
            this.menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pointerPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon systray;
        private System.Windows.Forms.ContextMenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem showPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button showHelp;
        private System.Windows.Forms.Button toggleEditMode;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button toggleRevealMode;
        private System.Windows.Forms.Label quickHelpText;
        private System.Windows.Forms.PictureBox pointerPic;
    }
}