using System;
using System.IO;

namespace Niflib
{
	public class NiTriShapeData : NiTriBasedGeomData
	{
		public uint NumTrianglePoints;

		public bool HasTriangles;

		public Triangle[] Triangles;

		public ushort[][] MatchGroups;

		public NiTriShapeData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NumTrianglePoints = reader.ReadUInt32();
			if (base.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasTriangles = reader.ReadBoolean();
			}
			if (base.Version <= eNifVersion.VER_10_0_1_2 || this.HasTriangles || base.Version >= eNifVersion.VER_10_0_1_3)
			{
				this.Triangles = new Triangle[(int)this.NumTriangles];
				for (int i = 0; i < (int)this.NumTriangles; i++)
				{
					this.Triangles[i] = new Triangle(reader);
				}
			}
			if (base.Version >= eNifVersion.VER_3_1)
			{
				ushort num = reader.ReadUInt16();
				this.MatchGroups = new ushort[(int)num][];
				for (int j = 0; j < (int)num; j++)
				{
					ushort num2 = reader.ReadUInt16();
					this.MatchGroups[j] = new ushort[(int)num2];
					for (int k = 0; k < (int)num2; k++)
					{
						this.MatchGroups[j][k] = reader.ReadUInt16();
					}
				}
			}
		}
	}
}
