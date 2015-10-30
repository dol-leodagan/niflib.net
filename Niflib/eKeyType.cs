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
    /// Enum eKeyType
    /// </summary>
    public enum eKeyType : uint
	{
        /// <summary>
        /// The linea r_ key
        /// </summary>
        LINEAR_KEY = 1u,
        /// <summary>
        /// The quadrati c_ key
        /// </summary>
        QUADRATIC_KEY,
        /// <summary>
        /// The tb c_ key
        /// </summary>
        TBC_KEY,
        /// <summary>
        /// The xy z_ rotatio n_ key
        /// </summary>
        XYZ_ROTATION_KEY,
        /// <summary>
        /// The cons t_ key
        /// </summary>
        CONST_KEY
    }
}
