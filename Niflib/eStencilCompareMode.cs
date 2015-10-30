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
    /// Enum eStencilCompareMode
    /// </summary>
    public enum eStencilCompareMode : uint
	{
        /// <summary>
        /// The tes t_ never
        /// </summary>
        TEST_NEVER,
        /// <summary>
        /// The tes t_ less
        /// </summary>
        TEST_LESS,
        /// <summary>
        /// The tes t_ equal
        /// </summary>
        TEST_EQUAL,
        /// <summary>
        /// The tes t_ les s_ equal
        /// </summary>
        TEST_LESS_EQUAL,
        /// <summary>
        /// The tes t_ greater
        /// </summary>
        TEST_GREATER,
        /// <summary>
        /// The tes t_ no t_ equal
        /// </summary>
        TEST_NOT_EQUAL,
        /// <summary>
        /// The tes t_ greate r_ equal
        /// </summary>
        TEST_GREATER_EQUAL,
        /// <summary>
        /// The tes t_ always
        /// </summary>
        TEST_ALWAYS
    }
}
