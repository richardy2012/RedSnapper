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

namespace RedSnapper
{
    public partial class HookManagerTest : Form
    {
        Timer t;
        Timer toplevelWindowTimer;
        Workspace ws;

        public HookManagerTest()
        {
            InitializeComponent();
            ws = new Workspace(
                new RuntimeContext(
                    new List<IntPtr> { this.Handle })
                );

            mouseInterval.Maximum = 1000;
            mouseInterval.Minimum = 5;
            mouseInterval.SmallChange = 50;
            mouseInterval.TickFrequency = 50;
            mouseInterval.TickStyle = TickStyle.Both;

            mouseInterval.ValueChanged += new EventHandler(mouseInterval_ValueChanged);

            t = new Timer();
            t.Tick += new EventHandler(t_Tick);
            t.Interval = mouseInterval.Value;
            t.Enabled = true;
            t.Start();

            toplevelWindowTimer = new Timer();
            toplevelWindowTimer.Tick += new EventHandler(toplevelWindowTimer_Tick);
            toplevelWindowTimer.Interval = 5 * 1000;
            toplevelWindowTimer.Enabled = true;
            toplevelWindowTimer.Start();
        }

        void toplevelWindowTimer_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var win in SystemWindow.AllToplevelWindows.ToList().Where(w=>!string.IsNullOrWhiteSpace(w.Title)))
            {
                listBox1.Items.Add(string.Format("{0} - {1}", win.Title, win.HWnd));
            }
        }

        void mouseInterval_ValueChanged(object sender, EventArgs e)
        {
            t.Interval = mouseInterval.Value;
            scanFreq.Text = t.Interval + " ms";
        }

        void t_Tick(object sender, EventArgs e)
        {
            debugText.Text = ws.InputStateDebugInfo.ToString();
        }
    }
}
