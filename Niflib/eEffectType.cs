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
    /// Enum eEffectType
    /// </summary>
    public enum eEffectType : uint
	{
        /// <summary>
        /// The effec t_ projecte d_ light
        /// </summary>
        EFFECT_PROJECTED_LIGHT,
        /// <summary>
        /// The effec t_ projecte d_ shadow
        /// </summary>
        EFFECT_PROJECTED_SHADOW,
        /// <summary>
        /// The effec t_ environmen t_ map
        /// </summary>
        EFFECT_ENVIRONMENT_MAP,
        /// <summary>
        /// The effec t_ fo g_ map
        /// </summary>
        EFFECT_FOG_MAP
    }
}
