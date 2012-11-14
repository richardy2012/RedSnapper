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

namespace RedSnapper
{
    public class InputState
    {
        private int mouseX;
        private int mouseY;
        private bool leftMouseButtonDown;
        private IntPtr windowHandle;

        public InputState()
        {
        }

        #region properties

        public int MouseX
        {
            get
            {
                return mouseX;
            }
            set
            {
                mouseX = value;
            }
        }

        public int MouseY
        {
            get { return mouseY; }
            set
            {
                mouseY = value;
            }
        }

        public bool LeftMouseButtonDown
        {
            get
            {
                return leftMouseButtonDown;
            }
            set
            {
                this.leftMouseButtonDown = value;
            }
        }

        public bool ShiftDepressed
        {
            get
            {
                return Win32.IsShiftKeyDown();
            }
        }

        /// <summary>
        /// Specifies the handle of the window being dragged.  If this value is IntPtr.Zero, no window is being dragged.
        /// </summary>
        public IntPtr WindowHandle
        {
            get { return this.windowHandle; }
            set {this.windowHandle = value;} 
        }

        #endregion

        #region methods
        public override string ToString()
        {
            string debugInfo = string.Format("MouseX:{0}\r\n", MouseX);
            debugInfo += string.Format("MouseY:{0}\r\n", MouseY);
            debugInfo += string.Format("LeftMouseButtonDown:{0}\r\n", LeftMouseButtonDown);
            debugInfo += string.Format("ShiftDepressed:{0}\r\n", ShiftDepressed);
            
            debugInfo += string.Format("WindowHandle:{0}\r\n", WindowHandle);
            return debugInfo;
        }
        #endregion

    }
}
