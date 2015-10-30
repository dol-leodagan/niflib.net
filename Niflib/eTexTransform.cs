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
    /// Enum eTexTransform
    /// </summary>
    public enum eTexTransform : uint
	{
        /// <summary>
        /// The t t_ translat e_ u
        /// </summary>
        TT_TRANSLATE_U,
        /// <summary>
        /// The t t_ translat e_ v
        /// </summary>
        TT_TRANSLATE_V,
        /// <summary>
        /// The t t_ rotate
        /// </summary>
        TT_ROTATE,
        /// <summary>
        /// The t t_ scal e_ u
        /// </summary>
        TT_SCALE_U,
        /// <summary>
        /// The t t_ scal e_ v
        /// </summary>
        TT_SCALE_V
    }
}
