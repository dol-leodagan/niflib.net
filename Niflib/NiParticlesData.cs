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
    /// Class NiParticlesData.
    /// </summary>
    public class NiParticlesData : NiGeometryData
	{
        /// <summary>
        /// The number particles
        /// </summary>
        public ushort NumParticles;

        /// <summary>
        /// The particle radius
        /// </summary>
        public float ParticleRadius;

        /// <summary>
        /// The has radii
        /// </summary>
        public bool HasRadii;

        /// <summary>
        /// The radii
        /// </summary>
        public float[] Radii;

        /// <summary>
        /// The number active
        /// </summary>
        public ushort NumActive;

        /// <summary>
        /// The has sizes
        /// </summary>
        public bool HasSizes;

        /// <summary>
        /// The sizes
        /// </summary>
        public float[] Sizes;

        /// <summary>
        /// The has rotations
        /// </summary>
        public bool HasRotations;

        /// <summary>
        /// The rotations
        /// </summary>
        public Vector4[] Rotations;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiParticlesData"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiParticlesData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version <= eNifVersion.VER_4_0_0_2)
			{
				this.NumParticles = reader.ReadUInt16();
			}
			if (this.File.Header.Version <= eNifVersion.VER_10_0_1_0)
			{
				this.ParticleRadius = reader.ReadSingle();
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasRadii = reader.ReadBoolean();
				if (this.HasRadii)
				{
					this.Radii = reader.ReadFloatArray((int)this.NumVertices);
				}
			}
			this.NumActive = reader.ReadUInt16();
			this.HasSizes = reader.ReadBoolean();
			if (this.HasSizes)
			{
				this.Sizes = reader.ReadFloatArray((int)this.NumVertices);
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.HasRotations = reader.ReadBoolean();
				if (this.HasRotations)
				{
					this.Rotations = new Vector4[this.NumVertices];
					int num = 0;
					while ((long)num < (long)((ulong)this.NumVertices))
					{
						this.Rotations[num] = reader.ReadVector4();
						num++;
					}
				}
			}
		}
	}
}
