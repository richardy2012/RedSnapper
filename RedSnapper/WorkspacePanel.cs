/*
 * RedSnapper - A windows workspace utility to enable efficient usage of 
 * large resolutions by enabling you to snap windows into preset zones.
 * Copyright (C) 2012 Todd Mitchell https://github.com/toddmitchell/RedSnapper

 * This file is part of RedSnapper.

 * RedSnapper is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation using version 3 of the License.

 * RedSnapper is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with RedSnapper.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedSnapper;
using ManagedWinapi.Windows;
using System.IO;

namespace RedSnapper
{
    public partial class WorkspacePanel : Form
    {
        private Workspace workspace;

        private bool editMode;
        private bool revealMode;

        private const string FILE_EXTENSION = "snap";
        private const string FILE = @"redsnapper.snap";

        public WorkspacePanel()
        {
            InitializeComponent();

            InitalizeHelp();

            workspace = new Workspace(
                new RuntimeContext(
                    new List<IntPtr> { this.Handle })
                );
            
            systray.ContextMenuStrip = menu;

            //TODO: detect screen resolution changes in hopes of handling dock/undock events
            //TOOD: give the user a way to distinguish between layouts that are for different monitor configs
                //IE: multi monitor with huge amounts of desktop space or a laptop screen
                //    could potentially support auto scaling?

            
            //TODO: show help on first run.
            this.Hide(); 
            systray.Visible = true;
            systray.Icon = this.Icon;
        }

        private void InitalizeHelp()
        {

            this.createButton.Tag = "Creates a new zone in which you can drop windows.";
            this.openButton.Tag = "Open a previously saved workspace";
            this.saveButton.Tag = "Save the current workspace.  If you haven't yet saved it, you will be asked for a filename.";
            this.toggleEditMode.Tag = "Edit all zones at once.";
            this.toggleRevealMode.Tag = "Reveal all zones in their current position.";
            this.showHelp.Tag = "Watch a quick how-to video on youtube";

            this.createButton.MouseEnter += ShowHelp;
            this.openButton.MouseEnter += ShowHelp;
            this.saveButton.MouseEnter += ShowHelp;
            this.toggleEditMode.MouseEnter += ShowHelp;
            this.toggleRevealMode.MouseEnter += ShowHelp;
            this.showHelp.MouseEnter += ShowHelp;
            
            ShowHelp(this.createButton, null); 
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            Control c = (Control)sender;
            var targetCenter = c.Left + (c.Width/2);
            pointerPic.Left = targetCenter - (pointerPic.Width / 2);

            quickHelpText.Text = Convert.ToString(c.Tag);
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void createZone_Click(object sender, EventArgs e)
        {
            workspace.Create();
        }

        private void reveal_Click(object sender, EventArgs e)
        {
            try
            {

                revealMode = !revealMode;

                toggleRevealMode.Text = revealMode ? "Hide Zones" : "Reveal Zones";
                workspace.ToggleRevealZones(revealMode);
            }
            catch (CannotPerformActionInEditModeException)
            {
                string msg = string.Format("Please save all windows before reaving windows.");
                MessageBox.Show(msg,"RedSnapper - Reveal",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toggleEditMode_Click(object sender, EventArgs e)
        {
            editMode = !editMode;

            if (editMode)
            {
                if (revealMode) //TODO: should probably centralize this
                {
                    reveal_Click(sender, e);
                }

                toggleRevealMode.Enabled = false;

                ((Button)sender).Text = "Save Zones";
                workspace.EditAllZones();
            }
            else
            {
                ((Button)sender).Text = "Edit Zones";

                toggleRevealMode.Enabled = true;
                workspace.SaveAllZones();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
            }
            catch (Exception ex)
            {
                string msg = string.Format("An error occurred while attempting to open your file. Message: \n {0}", ex.Message);
                MessageBox.Show(this, msg, "RedSnapper", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_Click(object sender, EventArgs e)
        {
            var z = workspace.Create();
            if (revealMode)
            {
                z.ShowOutline();
            }
        }

        private void editAllMenuItem_Click(object sender, EventArgs e)
        {
            workspace.EditAllZones();
        }

        private void showPanel_Click(object sender, EventArgs e)
        {
            //TODO: set position
            this.WindowState = FormWindowState.Normal; 
            this.Show();
            this.BringToFront();
            
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            if (ShouldClose())
            {
                Application.Exit();
            }
        }

        private void systray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            showPanel_Click(sender, e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (! ShouldClose())
            {
                this.Hide();
                e.Cancel = true;
            }

            base.OnClosing(e);
        }

        private void showHelp_Click(object sender, EventArgs e)
        {
            //SystemWindow.DesktopWindow.Highlight();
        }

        private void systray_DoubleClick(object sender, EventArgs e)
        {
            showPanel_Click(sender, e);
        }

        #region overrides
        
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        #endregion

        #region private methods
        private void OpenFile()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.CheckFileExists = true;
            dlg.DefaultExt = FILE_EXTENSION;
            dlg.Title = "Open RedSnapper File";

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workspace.Open(dlg.FileName);
                workspace.ToggleRevealZones(revealMode);
            }
        }

        private void SaveFile()
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Title = "Save RedSnapper File";
            dlg.DefaultExt = FILE_EXTENSION;

            if (string.IsNullOrWhiteSpace(workspace.Path))
            {
                dlg.FileName = "MyLayout";
            }
            else
            {
                dlg.FileName = workspace.Path;
            }

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!Path.HasExtension(dlg.FileName))
                {
                    dlg.FileName = Path.ChangeExtension(dlg.FileName, FILE_EXTENSION);
                }

                workspace.Save(dlg.FileName);
            }
        }

        private bool ShouldClose()
        {
            if (workspace.ZoneInEditMode)
            {
                systray.ShowBalloonTip(2000, "Exit?", "You've got one or more zones in edit mode.  Please commit their changes before exiting.", ToolTipIcon.Warning);
                return false;
            }

            return true;
        }
        
        #endregion


    }
}

