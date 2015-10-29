using System;
using System.IO;

namespace Niflib
{
	public class SkinPartitionUnkownItem1
	{
		public uint Flags;

		public float Unkown1;

		public float Unkown2;

		public float Unkown3;

		public float Unkown4;

		public float Unkown5;

		public SkinPartitionUnkownItem1(NiFile file, BinaryReader reader)
		{
			this.Flags = reader.ReadUInt32();
			this.Unkown1 = reader.ReadSingle();
			this.Unkown2 = reader.ReadSingle();
			this.Unkown3 = reader.ReadSingle();
			this.Unkown4 = reader.ReadSingle();
			this.Unkown5 = reader.ReadSingle();
		}
	}
}
