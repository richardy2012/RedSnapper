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
using Gma.UserActivityMonitor;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using ManagedWinapi.Windows;

namespace RedSnapper
{
    /// <summary>
    /// Coordinates events between mouse movements and Zones.
    /// </summary>
    [Serializable]
    public class Workspace
    {
        private List<Zone> zones;
        
        [NonSerialized]
        private RuntimeContext runtimeContext;

        [NonSerialized]
        private InputState inputState;

        [NonSerialized]
        private Timer zoneScanner;

        [NonSerialized]
        private string path;

        [NonSerialized]
        private bool inRevealMode;

        public Workspace(RuntimeContext runtimeContext)
        {
            Debug.Assert(null != runtimeContext, "Argument runtimeContext was null");

            this.runtimeContext = runtimeContext;

            zones = new List<Zone>();
            inputState = new InputState();
            zoneScanner = new Timer();

            zoneScanner.Interval = 100;
            zoneScanner.Tick += new EventHandler(zoneScanner_Tick);
            zoneScanner.Start();

            HookManager.MouseMoveExt += new EventHandler<MouseEventExtArgs>(HookManager_MouseMoveExt);
            HookManager.MouseDown += new System.Windows.Forms.MouseEventHandler(HookManager_MouseDown);
            HookManager.MouseUp += new System.Windows.Forms.MouseEventHandler(HookManager_MouseUp);
            HookManager.BeforeProcesssing += new EventHandler(HookManager_BeforeProcesssing);
        }

        #region properties
        /// <summary>
        /// Exposes the internal <see cref="Workspace.InputState"/> data.  This should only be used for debugging.
        /// </summary>
        public InputState InputStateDebugInfo
        {
            get
            {
                return this.inputState;
            }
        }

        /// <summary>
        /// Specifies if the user is toggling the right key combination and dragging a window.
        /// </summary>
        private bool ShouldShowZones
        {
            get
            {
                //TODO: add detection to check for a window being dragged.
                if (inputState.LeftMouseButtonDown && inputState.ShiftDepressed)
                {
                    DetectWindow();
                    var result = inputState.WindowHandle != IntPtr.Zero;

                    Debug.WriteLine(string.Format("window detected: {0}", result));

                    return result;
                }
                else
                {
                    Debug.WriteLine("leftmousebuttondown = false or shiftdepressed = false");
                }

                return false;
            }
        }

        /// <summary>
        /// Specifies the file which is currently open.
        /// </summary>
        public string Path
        {
            get { return path; }
        }

        /// <summary>
        /// Specifies if at least one zone is being edited.
        /// </summary>
        public bool ZoneInEditMode
        {
            get
            {
                return zones.Where(z => z.IsInEditMode).Count() > 0;
            }
        }
        
        #endregion

        #region event handlers

        void zoneScanner_Tick(object sender, EventArgs e)
        {
            ScanZones();
        }

        void HookManager_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            inputState.MouseX = e.X;
            inputState.MouseY = e.Y;
            AcquireWindowIfPossible();

            //reset the whole thing because the user no longer taking action we care about.
            //TODO: analyze if i really have to reset the input state.
            inputState = new InputState();
        }

        void HookManager_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                inputState.LeftMouseButtonDown = true;
                inputState.MouseX = e.X;
                inputState.MouseY = e.Y;
           } 
        }

        void HookManager_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            inputState.MouseX = e.X;
            inputState.MouseY = e.Y;
        }

        void HookManager_BeforeProcesssing(object sender, EventArgs e)
        {
        }

        void zone_Delete(object zone, EventArgs e)
        {
            var z = (Zone)zone;
            zones.Remove(z);
        }

        #endregion

        #region methods

        private void AcquireWindowIfPossible()
        {
            //|| inRevealMode
            if (ShouldShowZones)
            {
                //TODO: perhaps there is better logic for detecting WHICH zone to use when multiple zones are displayed
                //var bestMatchingZone = zones.Where(z => z.IsOutlined).FirstOrDefault();

                //Note: i added MouseInZone check to help when inRevalMode is true.
                var bestMatchingZone = zones.Where(z => z.IsOutlined && MouseInZone(z)).FirstOrDefault();

                if (null != bestMatchingZone)
                {
                    IntPtr hwnd = inputState.WindowHandle;
                    bestMatchingZone.AcquireWindow(hwnd);
                    if (! inRevealMode)
                    {
                        bestMatchingZone.HideOutline();
                    }
                }
            }
        }

        /// <summary>
        /// Scans zones checking if the mouse resides with-in a given zone
        /// </summary>
        private void ScanZones()
        {

            if (ZoneInEditMode)
            {
                return;
            }

            Debug.WriteLine("=================================================");
            if (!ShouldShowZones)
            {
                Debug.WriteLine("hiding outlined zones");
                zones.Where(z=>z.IsOutlined)
                    .ToList()
                    .ForEach(z => z.HideOutline());

                SystemWindow.DesktopWindow.Refresh();

                Debug.WriteLine("=================================================");

                return;
            }

            zones.ForEach(z => 
                {
                    if(! z.IsOutlined)
                    {
                        Debug.WriteLine(string.Format("Showing outline for zone at location [{0}, {1}]", z.Location.X, z.Location.Y));
                        z.ShowOutline();
                    }
                });


            Debug.WriteLine("=================================================");

            return;

            #region old way = show zones only as window is over them
            /*
            List<Zone> zonesToOutline = new List<Zone>(); ;
            List<Zone> zonesAlreadyDisplayed = new List<Zone>();

            foreach (var z in zones)
            {
                if (MouseInZone(z))
                {
                    zonesToOutline.Add(z);
                }

                if (z.IsOutlined)
                {
                    zonesAlreadyDisplayed.Add(z);
                }
            }

            //hide zones which are not in the zonesToOutline list
            zonesAlreadyDisplayed
                .Where(z => ! zonesToOutline.Contains(z))
                .ToList().ForEach(z=>z.HideOutline());

            zonesToOutline.ForEach(z => z.ShowOutline());
            */
            #endregion
            
            //TODO: it's feasible detect the mouse position and show more about the zone
        }

        private bool MouseInZone(Zone z)
        {
            Rectangle mouseRect = new Rectangle(inputState.MouseX, inputState.MouseY, 1, 1);
            return z.Rectangle.IntersectsWith(mouseRect);
        }

        private bool IsBeingDragged(IntPtr hwnd, int x, int y)
        {
            //TODO: do i need this?
            //if (windowBeingDragged == Win32.GetDesktopWindow())
            //{
            //    return;
            //}


            //TODO: add test for win.IsDescendantOf(SystemWindow.DesktopWindow))?

            if (hwnd == IntPtr.Zero)
            {
                Debug.WriteLine("IsBeingDragged: hwnd was zero");
            }
            else
            {
                IntPtr lParam = new IntPtr(65536 * y + x);
                int hitTestPtr = Win32.SendMessage(hwnd, (int)Win32.WindowMessages.WM_NCHITTEST, IntPtr.Zero, lParam);
                if ((int)hitTestPtr == Win32.HitTestConstants.HTCAPTION)
                {
                    Debug.WriteLine("mouse is in htcaption");
                    return true;
                }
                else
                {
                    Debug.WriteLine("mouse is not in htcaption");
                }
            }

            return false;
        }

        /// <summary>
        /// Detects if a valid window is being dragged
        /// </summary>
        private void DetectWindow()
        {
            if (! inputState.LeftMouseButtonDown)
            {
                Debug.WriteLine("DetectWindow: left mouse button down: FALSE");
                return;
            }

            var win = SystemWindow.FromPointEx(inputState.MouseX, inputState.MouseY, true, true);

            if (runtimeContext.IgnoredWindows.Contains(win.HWnd) || zones.Exists(z=> z.WindowHandle == win.HWnd))
            {
                Debug.WriteLine("DetectWindow: window detected [title={0}] was in ignored list.", win.Title);
                return;
            }

            Debug.WriteLine("Determining if Window from point (title=[{0}] hwnd=[{1}]) is being dragged", win.Title, win.HWnd);

            if(IsBeingDragged(win.HWnd, inputState.MouseX, inputState.MouseY))
            {
                inputState.WindowHandle = win.HWnd;
                Debug.WriteLine("Window being dragged: TRUE");
                return;
            }

            Debug.WriteLine("Window being dragged: FALSE");
            inputState.WindowHandle = IntPtr.Zero;
        }

        public void ToggleRevealZones(bool on)
        {
            if (on)
            {
                if (inRevealMode) //stops flicker
                {
                    return;
                }

                Debug.Write("Revealing Zones: true\n");
                zoneScanner.Enabled = false;
                inRevealMode = true;
                zones.ForEach(z => { if (!z.IsInEditMode) { z.ShowOutline(); } });
            }
            else
            {
                Debug.Write("Revealing Zones: false\n");
                zoneScanner.Enabled = true;
                inRevealMode = false;
                HideAllZones();
            }
        }

        public void EditAllZones()
        {
            zones.ForEach(z => z.StartEditMode());
        }

        public void SaveAllZones()
        {
            zones.ForEach(z => z.SaveAndEndEditMode());
        }

        public void HideAllZones()
        {
            zones.ForEach(z => z.HideOutline());
        }

        public Zone Create()
        {
            Zone z = new Zone();
         
            //defaults
            z.Size = new Size(500,500);
            z.Location = new Point(100, 100);
            zones.Add(z);
            
            z.Delete += new EventHandler(zone_Delete);
            z.StartEditMode();

            return z;
        }

        public void Open(string path)
        {
            using (var fs = File.OpenRead(path))
            {
                BinaryFormatter f = new BinaryFormatter();

                //clean up any oustanding zones.
                zones.ForEach(z => { z.CancelEditMode(); z.HideOutline(); });
                zones = (List<Zone>)f.Deserialize(fs);

                zones.ForEach(x => x.PostSerializationInit());
                
                this.path = path;
            }
        }

        public void Save(string path)
        {
            using (var fs = File.OpenWrite(path))
            {
                BinaryFormatter f = new BinaryFormatter();
                f.Serialize(fs, zones);
            }
        }

        #endregion

    }
}
