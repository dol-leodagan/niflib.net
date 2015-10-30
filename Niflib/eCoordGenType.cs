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
    /// Enum eCoordGenType
    /// </summary>
    public enum eCoordGenType : uint
	{
        /// <summary>
        /// The c g_ worl d_ parallel
        /// </summary>
        CG_WORLD_PARALLEL,
        /// <summary>
        /// The c g_ worl d_ perspective
        /// </summary>
        CG_WORLD_PERSPECTIVE,
        /// <summary>
        /// The c g_ spher e_ map
        /// </summary>
        CG_SPHERE_MAP,
        /// <summary>
        /// The c g_ specula r_ cub e_ map
        /// </summary>
        CG_SPECULAR_CUBE_MAP,
        /// <summary>
        /// The c g_ diffus e_ cub e_ map
        /// </summary>
        CG_DIFFUSE_CUBE_MAP
    }
}
