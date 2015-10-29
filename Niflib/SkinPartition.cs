using System;
using System.IO;

namespace Niflib
{
	public class SkinPartition
	{
		public ushort NumVertices;

		public ushort NumTriangles;

		public ushort NumBones;

		public ushort NumStrips;

		public ushort NumWeightsPerVertex;

		public ushort[] Bones;

		public bool HasVertexMap;

		public ushort[] VertexMap;

		public bool HasVertexWeights;

		public float[][] VertexWeights;

		public ushort[] StripLengths;

		public bool HasFaces;

		public ushort[][] Strips;

		public Triangle[] Triangles;

		public bool HasBoneIndicies;

		public byte[][] BoneIndicies;

		public ushort UnkownShort;

		public ushort UnkownShort2;

		public ushort UnkownShort3;

		public ushort NumVertices2;

		public ushort UnkownShort4;

		public ushort UnkownShort5;

		public ushort UnkownShort6;

		public SkinPartitionUnkownItem1[] UnkownArr;

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
