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
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class SkinData.
    /// </summary>
    public class SkinData
	{
        /// <summary>
        /// The transform
        /// </summary>
        public SkinTransform Transform;

        /// <summary>
        /// The bounding sphere offset
        /// </summary>
        public Vector3 BoundingSphereOffset;

        /// <summary>
        /// The bounding sphere radius
        /// </summary>
        public float BoundingSphereRadius;

        /// <summary>
        /// The unkown13 shorts
        /// </summary>
        public ushort[] Unkown13Shorts;

        /// <summary>
        /// The number vertices
        /// </summary>
        public ushort NumVertices;

        /// <summary>
        /// The vertex weights
        /// </summary>
        public SkinWeight[] VertexWeights;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinData"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        /// <param name="hasVertexWeights">if set to <c>true</c> [has vertex weights].</param>
        public SkinData(NiFile file, BinaryReader reader, bool hasVertexWeights)
		{
			this.Transform = new SkinTransform(file, reader);
			this.BoundingSphereOffset = reader.ReadVector3();
			this.BoundingSphereRadius = reader.ReadSingle();
			if (file.Version == eNifVersion.VER_20_3_0_9 && file.Header.UserVersion == 131072u)
			{
				this.Unkown13Shorts = new ushort[13];
				for (int i = 0; i < 13; i++)
				{
					this.Unkown13Shorts[i] = reader.ReadUInt16();
				}
			}
			this.NumVertices = reader.ReadUInt16();
			if (hasVertexWeights)
			{
				this.VertexWeights = new SkinWeight[(int)this.NumVertices];
				for (int j = 0; j < (int)this.NumVertices; j++)
				{
					this.VertexWeights[j] = new SkinWeight(file, reader);
				}
			}
		}
	}
}
