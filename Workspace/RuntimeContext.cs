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

namespace RedSnapper
{
    /// <summary>
    /// Specifies various runtime parameters required by the Workspace class
    /// </summary>
    public class RuntimeContext
    {
        private List<IntPtr> ignoredWindows;

        public RuntimeContext(List<IntPtr> ignoredWindowHandles)
        {
            this.ignoredWindows = ignoredWindowHandles;

            if (null == this.ignoredWindows)
            {
                this.ignoredWindows = new List<IntPtr>();
            }
        }

        /// <summary>
        /// Specifies a list of window handles that should be 
        /// ignored and therefore not detected by Workspace.DetectWindow()
        /// </summary>
        public List<IntPtr> IgnoredWindows
        {
            get
            {
                return this.ignoredWindows;
            }
        }
    }
}
