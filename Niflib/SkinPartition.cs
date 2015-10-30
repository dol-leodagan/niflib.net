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
    /// Class SkinPartition.
    /// </summary>
    public class SkinPartition
	{
        /// <summary>
        /// The number vertices
        /// </summary>
        public ushort NumVertices;

        /// <summary>
        /// The number triangles
        /// </summary>
        public ushort NumTriangles;

        /// <summary>
        /// The number bones
        /// </summary>
        public ushort NumBones;

        /// <summary>
        /// The number strips
        /// </summary>
        public ushort NumStrips;

        /// <summary>
        /// The number weights per vertex
        /// </summary>
        public ushort NumWeightsPerVertex;

        /// <summary>
        /// The bones
        /// </summary>
        public ushort[] Bones;

        /// <summary>
        /// The has vertex map
        /// </summary>
        public bool HasVertexMap;

        /// <summary>
        /// The vertex map
        /// </summary>
        public ushort[] VertexMap;

        /// <summary>
        /// The has vertex weights
        /// </summary>
        public bool HasVertexWeights;

        /// <summary>
        /// The vertex weights
        /// </summary>
        public float[][] VertexWeights;

        /// <summary>
        /// The strip lengths
        /// </summary>
        public ushort[] StripLengths;

        /// <summary>
        /// The has faces
        /// </summary>
        public bool HasFaces;

        /// <summary>
        /// The strips
        /// </summary>
        public ushort[][] Strips;

        /// <summary>
        /// The triangles
        /// </summary>
        public Triangle[] Triangles;

        /// <summary>
        /// The has bone indicies
        /// </summary>
        public bool HasBoneIndicies;

        /// <summary>
        /// The bone indicies
        /// </summary>
        public byte[][] BoneIndicies;

        /// <summary>
        /// The unkown short
        /// </summary>
        public ushort UnkownShort;

        /// <summary>
        /// The unkown short2
        /// </summary>
        public ushort UnkownShort2;

        /// <summary>
        /// The unkown short3
        /// </summary>
        public ushort UnkownShort3;

        /// <summary>
        /// The number vertices2
        /// </summary>
        public ushort NumVertices2;

        /// <summary>
        /// The unkown short4
        /// </summary>
        public ushort UnkownShort4;

        /// <summary>
        /// The unkown short5
        /// </summary>
        public ushort UnkownShort5;

        /// <summary>
        /// The unkown short6
        /// </summary>
        public ushort UnkownShort6;

        /// <summary>
        /// The unkown arr
        /// </summary>
        public SkinPartitionUnkownItem1[] UnkownArr;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinPartition"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public SkinPartition(NiFile file, BinaryReader reader)
		{
			this.NumVertices = reader.ReadUInt16();
			this.NumTriangles = reader.ReadUInt16();
			this.NumBones = reader.ReadUInt16();
			this.NumStrips = reader.ReadUInt16();
			this.NumWeightsPerVertex = reader.ReadUInt16();
			this.Bones = reader.ReadUInt16Array((int)this.NumBones);
			this.HasVertexMap = true;
			this.HasVertexWeights = true;
			this.HasFaces = true;
			if (file.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasVertexMap = reader.ReadBoolean();
			}
			if (this.HasVertexMap)
			{
				this.VertexMap = reader.ReadUInt16Array((int)this.NumVertices);
			}
			if (file.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasVertexWeights = reader.ReadBoolean();
			}
			if (this.HasVertexWeights)
			{
				this.VertexWeights = new float[(int)this.NumVertices][];
				for (int i = 0; i < (int)this.NumVertices; i++)
				{
					this.VertexWeights[i] = reader.ReadFloatArray((int)this.NumWeightsPerVertex);
				}
			}
			this.StripLengths = reader.ReadUInt16Array((int)this.NumStrips);
			if (file.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasFaces = reader.ReadBoolean();
			}
			if (this.HasFaces && this.NumStrips != 0)
			{
				this.Strips = new ushort[(int)this.NumStrips][];
				for (int j = 0; j < (int)this.NumStrips; j++)
				{
					this.Strips[j] = reader.ReadUInt16Array((int)this.StripLengths[j]);
				}
			}
			else if (this.HasFaces && this.NumStrips == 0)
			{
				this.Triangles = new Triangle[(int)this.NumTriangles];
				for (int k = 0; k < this.Triangles.Length; k++)
				{
					this.Triangles[k] = new Triangle(reader);
				}
			}
			this.HasBoneIndicies = reader.ReadBoolean();
			if (this.HasBoneIndicies)
			{
				this.BoneIndicies = new byte[(int)this.NumVertices][];
				for (int l = 0; l < this.BoneIndicies.Length; l++)
				{
					this.BoneIndicies[l] = new byte[(int)this.NumWeightsPerVertex];
					for (int m = 0; m < (int)this.NumWeightsPerVertex; m++)
					{
						this.BoneIndicies[l][m] = reader.ReadByte();
					}
				}
			}
			if (file.Header.UserVersion >= 12u)
			{
				this.UnkownShort = reader.ReadUInt16();
			}
			if (file.Version == eNifVersion.VER_10_2_0_0 && file.Header.UserVersion == 1u)
			{
				this.UnkownShort2 = reader.ReadUInt16();
				this.UnkownShort3 = reader.ReadUInt16();
				this.NumVertices2 = reader.ReadUInt16();
				this.UnkownShort4 = reader.ReadUInt16();
				this.UnkownShort5 = reader.ReadUInt16();
				this.UnkownShort6 = reader.ReadUInt16();
				this.UnkownArr = new SkinPartitionUnkownItem1[(int)this.NumVertices2];
				for (int n = 0; n < (int)this.NumVertices2; n++)
				{
					this.UnkownArr[n] = new SkinPartitionUnkownItem1(file, reader);
				}
			}
		}
	}
}
