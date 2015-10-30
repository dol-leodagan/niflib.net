/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */
using System;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Enum ePixelFormat
    /// </summary>
    public enum ePixelFormat : uint
	{
        /// <summary>
        /// The p x_ fm t_ rg b8
        /// </summary>
        PX_FMT_RGB8,
        /// <summary>
        /// The p x_ fm t_ RGB a8
        /// </summary>
        PX_FMT_RGBA8,
        /// <summary>
        /// The p x_ fm t_ pa l8
        /// </summary>
        PX_FMT_PAL8,
        /// <summary>
        /// The p x_ fm t_ dx t1
        /// </summary>
        PX_FMT_DXT1 = 4u,
        /// <summary>
        /// The p x_ fm t_ dx t5
        /// </summary>
        PX_FMT_DXT5,
        /// <summary>
        /// The p x_ fm t_ dx T5_ alt
        /// </summary>
        PX_FMT_DXT5_ALT
    }
}
