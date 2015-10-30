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
	#if OpenTK
	using OpenTK;
	#elif SharpDX
	using SharpDX;
	#elif MonoGame
	using Microsoft.Xna.Framework;
	#endif
	using System;
	using System.IO;

    /// <summary>
    /// Class NiLODNode.
    /// </summary>
    public class NiLODNode : NiSwitchNode
	{
        /// <summary>
        /// The lod center
        /// </summary>
        public Vector3 LODCenter;

        /// <summary>
        /// The lod levels
        /// </summary>
        public LODRange[] LODLevels;

        /// <summary>
        /// The lod level data
        /// </summary>
        public NiRef<NiLODData> LODLevelData;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiLODNode" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiLODNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_4_0_0_2 && base.Version <= eNifVersion.VER_10_0_1_0)
			{
				this.LODCenter = reader.ReadVector3();
			}
			if (base.Version <= eNifVersion.VER_10_0_1_0)
			{
				uint num = reader.ReadUInt32();
				this.LODLevels = new LODRange[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.LODLevels[num2] = new LODRange(file, reader);
					num2++;
				}
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.LODLevelData = new NiRef<NiLODData>(reader);
			}
		}
	}
}
