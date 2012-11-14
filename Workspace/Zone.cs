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
using System.Drawing;
using System.Windows.Forms;
using ManagedWinapi.Windows;

namespace RedSnapper
{
    /// <summary>
    /// Represents an area in which the a window can be positioned.
    /// </summary>
    [Serializable]
    public class Zone
    {

        [NonSerialized]
        private Timer frameRenderer;

        [NonSerialized]
        private Form frame;

        [NonSerialized]
        private ZoneEditForm editForm;

        private Point location;
        private Size size;

        private event EventHandler deleteEvent;

        public Zone()
        {
        }

        public void PostSerializationInit()
        {
        }

        #region event handlers

        void frame_VisibleChanged(object sender, EventArgs e)
        {
            if (Frame.Visible)
            {
                SetFramePosition();
            }
        }

        void editForm_VisibleChanged(object sender, EventArgs e)
        {
            if (EditForm.Visible)
            {
                this.HideOutline();
                EditForm.Size = this.Size;
                EditForm.Location = this.Location;
            }
            else
            {
                if (EditForm.DialogResult == DialogResult.OK)
                {
                    this.Size = EditForm.Size;
                    this.Location = EditForm.Location;
                    return;
                }

                if (EditForm.DialogResult == DialogResult.Abort)
                {
                    if (null != deleteEvent)
                    {
                        deleteEvent.Invoke(this, new EventArgs());
                        return;
                    }
                }
            }
        }

        #endregion

        #region properties

        /// <summary>
        /// Event raised when the user requested to delete the zone.
        /// </summary>
        public event EventHandler Delete
        {
            add
            {
                deleteEvent += value;
            }
            remove
            {
                deleteEvent -= value;
            }
        }

        public Point Location
        {
            get { return this.location; }
            set { this.location = value; }
        }

        public Size Size
        {
            get { return this.size; }
            set { this.size = value;}
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
            }
        }

        /// <summary>
        /// Specifies if this zone is showing it's outline.
        /// </summary>
        public bool IsOutlined
        {
            get
            {
                System.Diagnostics.Debug.WriteLine(string.Format("Get Is Outlined {0}", this.Frame.Visible));
                return this.Frame.Visible;
            }
        }

        /// <summary>
        /// Specifies if this zone is being edited.
        /// </summary>
        public bool IsInEditMode
        {
            get
            {
                return this.EditForm.Visible;
            }
        }

        /// <summary>
        /// Specifies the window handle of the frame
        /// </summary>
        public IntPtr WindowHandle
        {
            get
            {
                return null == frame ? IntPtr.Zero : frame.Handle;
            }
        }

        private Form Frame
        {
            get
            {
                if (null == this.frame)
                {
                    //this.frame = new ZoneFrame();
                    this.frame = new Form();

                    this.frame.VisibleChanged += new EventHandler(frame_VisibleChanged);

                    frame.Text = string.Empty;
                    frame.TopMost = true;
                    Frame.BackColor = Color.Magenta;
                    Frame.TransparencyKey = Color.Magenta;
                    frame.ControlBox = false;
                    frame.ShowInTaskbar = false;
                    //frame.Size = this.Size;
                    frame.Location = this.Location;

                    //Note: attempting to use a background color w/ opacity causes very strange behavior. (very, very strange)
                    //frame.BackColor = Color.AliceBlue;
                    //frame.Opacity = .35;

                    //TODO: not sure if i really need to do this.
                    //Win32.SetParent(Frame.Handle, SystemWindow.DesktopWindow.HWnd);
                }

                return frame;
            }
        }

        private ZoneEditForm EditForm
        {
            get
            {
                if (null == this.editForm)
                {
                    editForm = new ZoneEditForm();
                    editForm.Location = this.Location;
                    editForm.Size = this.Size;
                    editForm.VisibleChanged += new EventHandler(editForm_VisibleChanged);
                }

                return this.editForm;
            }
        }
        #endregion

        #region methods
        
        /// <summary>
        /// Sets the specified window's placement with-in this zone.
        /// </summary>
        /// <param name="hwnd"></param>
        public void AcquireWindow(IntPtr hwnd)
        {
            if (IsInEditMode)
            {
                return;
            }

            if (hwnd == Frame.Handle)
            {
                return;
            }

            new Snapper().SnapWindow(hwnd, this);
        }

        /// <summary>
        /// Renders representation of size and position.
        /// </summary>
        public void ShowOutline()
        {
            if (IsInEditMode)
            {
                throw new Exception("Cannot show outline while in edit mode");
            }

            //System.Diagnostics.Debugger.Break();
            System.Diagnostics.Debug.WriteLine("Show outline called.");

            SetFramePosition();
            Frame.BringToFront();
            Frame.TopMost = true; //TODO: this is a problem.  need to see if i can draw to the desktop directly
            Frame.Visible = true;
        }

        /// <summary>
        /// Hides the outline
        /// </summary>
        public void HideOutline()
        {
            SystemWindow.DesktopWindow.Refresh();
            Frame.Visible = false;
            Frame.Hide();
            System.Diagnostics.Debug.WriteLine("Hide outline called");
        }

        public void StartEditMode()
        {
            EditForm.Visible = true;
        }

        public void SaveAndEndEditMode()
        {
            EditForm.DialogResult = DialogResult.OK;
            EditForm.Visible = false;
        }
        
        /// <summary>
        /// Cancels the editing of this zone.  The Edit form will be hidden and any changes to the position will not be saved.
        /// </summary>
        public void CancelEditMode()
        {
            EditForm.DialogResult = DialogResult.Cancel;
            EditForm.Visible = false;
        }

        private void SetFramePosition()
        {
            Frame.Size = this.Size;
            Frame.MaximumSize = this.Size;
            Frame.MinimumSize = this.Size;
            Frame.Location = this.Location;
        }
        #endregion
    }
}
