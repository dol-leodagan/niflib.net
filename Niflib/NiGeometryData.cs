using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiGeometryData : NiObject
	{
		public uint Unkown1;

		public byte KeepFlags;

		public byte CompressFlags;

		public bool HasVertices;

		public Vector3[] Vertices;

		public byte TSpaceFlag;

		public bool HasNormals;

		public Vector3[] Normals;

		public bool HasVertexColors;

		public bool HasUV;

		public ushort ConsistencyFlags;

		public Vector3 Center;

		public float Radius;

		public Color4[] VertexColors;

		public Vector2[][] UVSets;

		public uint AdditionalDataID;

		public Vector3[] Binormals;

		public Vector3[] Tangents;

		public uint NumVertices;

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
