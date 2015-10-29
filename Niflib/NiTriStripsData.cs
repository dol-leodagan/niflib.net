using System;
using System.IO;

namespace Niflib
{
	public class NiTriStripsData : NiTriBasedGeomData
	{
		public bool HasPoints;

		public ushort[][] Points;

		public NiTriStripsData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			ushort[] array = new ushort[(int)reader.ReadUInt16()];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = reader.ReadUInt16();
			}
			if (base.Version >= eNifVersion.VER_10_0_1_3)
			{
				this.HasPoints = reader.ReadBoolean();
			}
			if (base.Version < eNifVersion.VER_10_0_1_3 || this.HasPoints)
			{
				this.Points = new ushort[array.Length][];
				for (int j = 0; j < array.Length; j++)
				{
					this.Points[j] = new ushort[(int)array[j]];
					for (ushort num = 0; num < array[j]; num += 1)
					{
						this.Points[j][(int)num] = reader.ReadUInt16();
					}
				}
			}
		}
	}
}
