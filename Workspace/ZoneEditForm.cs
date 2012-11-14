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
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace RedSnapper
{
    public partial class ZoneEditForm : Form
    {
        List<Point> positions = new List<Point>();
        Timer tracker = new Timer();
        bool hasMoved = false;
        Point lastFormLocation = Point.Empty;
        int matchCount = 0;

        Point lastClick;

        public ZoneEditForm()
        {
            InitializeComponent();

            MaximizeBox = false;
            ShowInTaskbar = true;
            //MinimizeBox = false;
            //ControlBox = false;
            //TopMost = true;
            Text = string.Empty;

            tracker.Interval = 1;
            tracker.Tick += new EventHandler(tracker_Tick);
            //tracker.Start();

            Win32.SetParent(this.Handle, SystemWindow.DesktopWindow.HWnd);

            #region events
            this.Move += new EventHandler(Form_Move);
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.MouseMove += new MouseEventHandler(Form_MouseMove);
            #endregion
        }

        void tracker_Tick(object sender, EventArgs e)
        {
            if (!shouldTrack.Checked)
            {
                matchCount = 0;
                hasMoved = false;
                return;
            }

            if (!hasMoved)
            {
                return;
            }

            //if the location hasnt changed
            if (matchCount >= 100)
            {
                positions.RemoveRange(positions.Count - 100, 99);
                shouldTrack.Checked = false;
                return;
            }

            if (lastFormLocation == this.Location)
            {
                matchCount++; ;
                this.Text = matchCount.ToString();
            }

            lastFormLocation = this.Location;

            positions.Add(this.Location);
        }

        void Form_Move(object sender, EventArgs e)
        {
            //dont start tracking until the form is moved
            hasMoved = true;
            //this.Text = "has moved";

            windowLeftLabel.Text = string.Format("{0}", this.Left);
            windowTopLabel.Text = string.Format("{0}", this.Top);
            windowWidthLabel.Text = string.Format("{0}", this.Width);
            windowHeightLabel.Text = string.Format("{0}", this.Height);
        }

        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Visible = false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //TODO: there's probably a better way to signal a delete but whatever.
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Visible = false;
        }

        private void replay_Click(object sender, EventArgs e)
        {
            shouldTrack.Checked = false;
            Point prevP = new Point(0, 0);
            this.movementData.Items.Clear();
            //MessageBox.Show(positions.Count.ToString());

            List<Point> newPositions = new List<Point>();

            positions.ForEach(
                (Point p) =>
                {
                    newPositions.Add(p);

                    int prevX = p.X - prevP.X;
                    int prevY = p.Y - prevP.Y;

                    for (int i = 0; i < prevX; i++)
                    {
                        newPositions.Add(new Point(p.X + i, p.Y));
                        //TODO: to normalize Y, i have to change the storage mechanism into a different sort of array
                    }

                    prevP = p;
                });

            positions = newPositions;

            this.movementData.BeginUpdate();
            positions.ForEach(
                (Point p) =>
                {
                    int prevX = p.X - prevP.X;
                    int prevY = p.Y - prevP.Y;

                    //string msg = string.Format("x:{0}\ty:{1}", p.X, p.Y);
                    ListViewItem item = new ListViewItem(new string[] 
                    {
                        p.X.ToString(), 
                        p.Y.ToString(),
                        prevX.ToString(),
                        prevY.ToString()
                    });

                    this.movementData.Items.Add(item);

                    this.Location = p;
                    Application.DoEvents();
                    //System.Threading.Thread.Sleep(20);
                    prevP = p;
                });

            this.movementData.EndUpdate();
        }

        private void ZoneEditForm_Load(object sender, EventArgs e)
        {

        }
    }
}