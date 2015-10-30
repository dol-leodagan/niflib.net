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
using OpenTK.Graphics;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
using Color4 = Microsoft.Xna.Framework.Color;
#endif
using System;
using System.IO;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class NiGeometryData.
    /// </summary>
    public class NiGeometryData : NiObject
	{
        /// <summary>
        /// The unkown1
        /// </summary>
        public uint Unkown1;

        /// <summary>
        /// The keep flags
        /// </summary>
        public byte KeepFlags;

        /// <summary>
        /// The compress flags
        /// </summary>
        public byte CompressFlags;

        /// <summary>
        /// The has vertices
        /// </summary>
        public bool HasVertices;

        /// <summary>
        /// The vertices
        /// </summary>
        public Vector3[] Vertices;

        /// <summary>
        /// The t space flag
        /// </summary>
        public byte TSpaceFlag;

        /// <summary>
        /// The has normals
        /// </summary>
        public bool HasNormals;

        /// <summary>
        /// The normals
        /// </summary>
        public Vector3[] Normals;

        /// <summary>
        /// The has vertex colors
        /// </summary>
        public bool HasVertexColors;

        /// <summary>
        /// The has uv
        /// </summary>
        public bool HasUV;

        /// <summary>
        /// The consistency flags
        /// </summary>
        public ushort ConsistencyFlags;

        /// <summary>
        /// The center
        /// </summary>
        public Vector3 Center;

        /// <summary>
        /// The radius
        /// </summary>
        public float Radius;

        /// <summary>
        /// The vertex colors
        /// </summary>
        public Color4[] VertexColors;

        /// <summary>
        /// The uv sets
        /// </summary>
        public Vector2[][] UVSets;

        /// <summary>
        /// The additional data identifier
        /// </summary>
        public uint AdditionalDataID;

        /// <summary>
        /// The binormals
        /// </summary>
        public Vector3[] Binormals;

        /// <summary>
        /// The tangents
        /// </summary>
        public Vector3[] Tangents;

        /// <summary>
        /// The number vertices
        /// </summary>
        public uint NumVertices;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiObject" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiGeometryData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_2_0_0)
			{
				this.Unkown1 = reader.ReadUInt32();
			}
			this.NumVertices = (uint)reader.ReadUInt16();
			if (base.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.KeepFlags = reader.ReadByte();
				this.CompressFlags = reader.ReadByte();
			}
			this.HasVertices = reader.ReadBoolean();
			if (this.HasVertices)
			{
				this.Vertices = new Vector3[this.NumVertices];
				int num = 0;
				while ((long)num < (long)((ulong)this.NumVertices))
				{
					this.Vertices[num] = reader.ReadVector3();
					num++;
				}
			}
			int num2 = 0;
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				num2 = (int)reader.ReadByte();
				this.TSpaceFlag = reader.ReadByte();
			}
			this.HasNormals = reader.ReadBoolean();
			if (this.HasNormals)
			{
				this.Normals = new Vector3[this.NumVertices];
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.NumVertices))
				{
					this.Normals[num3] = reader.ReadVector3();
					num3++;
				}
			}
			if (base.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.Binormals = new Vector3[this.NumVertices];
				this.Tangents = new Vector3[this.NumVertices];
				if (this.HasNormals && (this.TSpaceFlag & 240) != 0)
				{
					int num4 = 0;
					while ((long)num4 < (long)((ulong)this.NumVertices))
					{
						this.Binormals[num4] = reader.ReadVector3();
						num4++;
					}
					int num5 = 0;
					while ((long)num5 < (long)((ulong)this.NumVertices))
					{
						this.Tangents[num5] = reader.ReadVector3();
						num5++;
					}
				}
			}
			this.Center = reader.ReadVector3();
			this.Radius = reader.ReadSingle();
			this.HasVertexColors = reader.ReadBoolean();
			if (this.HasVertexColors)
			{
				this.VertexColors = new Color4[this.NumVertices];
				int num6 = 0;
				while ((long)num6 < (long)((ulong)this.NumVertices))
				{
					this.VertexColors[num6] = reader.ReadColor4();
					num6++;
				}
			}
			if (base.Version <= eNifVersion.VER_4_2_2_0)
			{
				num2 = (int)reader.ReadByte();
				this.TSpaceFlag = reader.ReadByte();
			}
			if (base.Version <= eNifVersion.VER_4_0_0_2)
			{
				this.HasUV = reader.ReadBoolean();
			}
			int num7;
			if (base.Version < eNifVersion.VER_20_2_0_7 || this.File.Header.UserVersion != 1u)
			{
				num7 = (num2 & 63);
			}
			else
			{
				num7 = (num2 & 1);
			}
			this.UVSets = new Vector2[num7][];
			for (int i = 0; i < num7; i++)
			{
				this.UVSets[i] = new Vector2[this.NumVertices];
				int num8 = 0;
				while ((long)num8 < (long)((ulong)this.NumVertices))
				{
					this.UVSets[i][num8] = reader.ReadVector2();
					num8++;
				}
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.ConsistencyFlags = reader.ReadUInt16();
			}
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				this.AdditionalDataID = reader.ReadUInt32();
			}
		}
	}
}
