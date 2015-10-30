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
	using System.IO;

    /// <summary>
    /// Class NiSphericalCollider.
    /// </summary>
    public class NiSphericalCollider : NiParticleModifier
	{
        /// <summary>
        /// The unkown float1
        /// </summary>
        public float UnkownFloat1;

        /// <summary>
        /// The unkown short1
        /// </summary>
        public ushort UnkownShort1;

        /// <summary>
        /// The unkown float2
        /// </summary>
        public float UnkownFloat2;

        /// <summary>
        /// The unkown short2
        /// </summary>
        public ushort UnkownShort2;

        /// <summary>
        /// The unkown float3
        /// </summary>
        public float UnkownFloat3;

        /// <summary>
        /// The unkown float4
        /// </summary>
        public float UnkownFloat4;

        /// <summary>
        /// The unkown float5
        /// </summary>
        public float UnkownFloat5;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiSphericalCollider"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiSphericalCollider(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownFloat1 = reader.ReadSingle();
			this.UnkownShort1 = reader.ReadUInt16();
			this.UnkownFloat2 = reader.ReadSingle();
			if (base.Version <= eNifVersion.VER_4_2_0_2)
			{
				this.UnkownShort2 = reader.ReadUInt16();
			}
			else
			{
				this.UnkownFloat3 = reader.ReadSingle();
			}
			this.UnkownFloat4 = reader.ReadSingle();
			this.UnkownFloat5 = reader.ReadSingle();
		}
	}
}
