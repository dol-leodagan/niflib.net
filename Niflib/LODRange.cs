using System;
using System.IO;

namespace Niflib
{
	public class LODRange
	{
		public float NearExtent;

		public float FarExtent;

		public uint[] UnkownInts;

		public LODRange(NiFile file, BinaryReader reader)
		{
			this.NearExtent = reader.ReadSingle();
			this.FarExtent = reader.ReadSingle();
			if (file.Version <= eNifVersion.VER_3_1)
			{
				this.UnkownInts = new uint[]
				{
					reader.ReadUInt32(),
					reader.ReadUInt32(),
					reader.ReadUInt32()
				};
			}
		}
	}
}
