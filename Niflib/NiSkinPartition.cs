using System;
using System.IO;

namespace Niflib
{
	public class NiSkinPartition : NiObject
	{
		public SkinPartition[] Partitions;

		public NiSkinPartition(NiFile file, BinaryReader reader) : base(file, reader)
		{
			uint num = reader.ReadUInt32();
			this.Partitions = new SkinPartition[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.Partitions[num2] = new SkinPartition(file, reader);
				num2++;
			}
		}
	}
}
