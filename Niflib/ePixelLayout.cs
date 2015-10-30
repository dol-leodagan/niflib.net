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

namespace Niflib
{
	using System;

    /// <summary>
    /// Enum ePixelLayout
    /// </summary>
    public enum ePixelLayout : uint
	{
        /// <summary>
        /// The pi x_ la y_ palettised
        /// </summary>
        PIX_LAY_PALETTISED,
        /// <summary>
        /// The pi x_ la y_ hig h_ colo R_16
        /// </summary>
        PIX_LAY_HIGH_COLOR_16,
        /// <summary>
        /// The pi x_ la y_ tru e_ colo R_32
        /// </summary>
        PIX_LAY_TRUE_COLOR_32,
        /// <summary>
        /// The pi x_ la y_ compressed
        /// </summary>
        PIX_LAY_COMPRESSED,
        /// <summary>
        /// The pi x_ la y_ bumpmap
        /// </summary>
        PIX_LAY_BUMPMAP,
        /// <summary>
        /// The pi x_ la y_ palettise D_4
        /// </summary>
        PIX_LAY_PALETTISED_4,
        /// <summary>
        /// The pi x_ la y_ default
        /// </summary>
        PIX_LAY_DEFAULT
    }
}
