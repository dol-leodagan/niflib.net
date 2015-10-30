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
using System.IO;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class NiPlanarCollider.
    /// </summary>
    public class NiPlanarCollider : NiParticleModifier
	{
        /// <summary>
        /// The unkown short1
        /// </summary>
        public ushort UnkownShort1;

        /// <summary>
        /// The unkown float1
        /// </summary>
        public float UnkownFloat1;

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
        /// The unkown float6
        /// </summary>
        public float UnkownFloat6;

        /// <summary>
        /// The unkown float7
        /// </summary>
        public float UnkownFloat7;

        /// <summary>
        /// The unkown float8
        /// </summary>
        public float UnkownFloat8;

        /// <summary>
        /// The unkown float9
        /// </summary>
        public float UnkownFloat9;

        /// <summary>
        /// The unkown float10
        /// </summary>
        public float UnkownFloat10;

        /// <summary>
        /// The unkown float11
        /// </summary>
        public float UnkownFloat11;

        /// <summary>
        /// The unkown float12
        /// </summary>
        public float UnkownFloat12;

        /// <summary>
        /// The unkown float13
        /// </summary>
        public float UnkownFloat13;

        /// <summary>
        /// The unkown float14
        /// </summary>
        public float UnkownFloat14;

        /// <summary>
        /// The unkown float15
        /// </summary>
        public float UnkownFloat15;

        /// <summary>
        /// The unkown float16
        /// </summary>
        public float UnkownFloat16;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiPlanarCollider"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiPlanarCollider(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.UnkownShort1 = reader.ReadUInt16();
			}
			this.UnkownFloat1 = reader.ReadSingle();
			this.UnkownFloat2 = reader.ReadSingle();
			if (base.Version == eNifVersion.VER_4_2_2_0)
			{
				this.UnkownShort2 = reader.ReadUInt16();
			}
			this.UnkownFloat3 = reader.ReadSingle();
			this.UnkownFloat4 = reader.ReadSingle();
			this.UnkownFloat5 = reader.ReadSingle();
			this.UnkownFloat6 = reader.ReadSingle();
			this.UnkownFloat7 = reader.ReadSingle();
			this.UnkownFloat8 = reader.ReadSingle();
			this.UnkownFloat9 = reader.ReadSingle();
			this.UnkownFloat10 = reader.ReadSingle();
			this.UnkownFloat11 = reader.ReadSingle();
			this.UnkownFloat12 = reader.ReadSingle();
			this.UnkownFloat13 = reader.ReadSingle();
			this.UnkownFloat14 = reader.ReadSingle();
			this.UnkownFloat15 = reader.ReadSingle();
			this.UnkownFloat16 = reader.ReadSingle();
		}
	}
}
