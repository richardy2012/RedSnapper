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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ManagedWinapi.Windows;
using System.Runtime.InteropServices;

namespace RedSnapper
{
    internal class Snapper
    {
        readonly Timer timer;
        IntPtr windowToSnap;
        Zone zone;

        public Snapper()
        {
            //timer is used to allow us to move the window after the operating system has handled its "mouse up" event
            //the correct way is to cancel the "mouse up" event but i dont like tampering w/ windows messages
            //Note: i might be able to extend the mouseeventsExt event to mouseup event
            timer = new Timer();
            timer.Interval = 10;
            timer.Enabled = false;

            timer.Tick += new EventHandler(timer_Tick);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (IntPtr.Zero != windowToSnap)
            {
                SystemWindow win = new SystemWindow(windowToSnap);
                win.Location = zone.Location;
                win.Size = zone.Size;
                windowToSnap = IntPtr.Zero;
            }

            timer.Stop();
        }

        public void SnapWindow(IntPtr hwnd, Zone zone)
        {
            this.zone = zone;
            this.windowToSnap = hwnd;
            timer.Start();
        }
    }
}
