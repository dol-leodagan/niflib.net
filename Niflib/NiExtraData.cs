using System;
using System.IO;

namespace Niflib
{
	public class NiExtraData : NiObject
	{
		public NiString Name;

		public NiRef<NiExtraData> NextExtraData;

		public NiExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.Name = new NiString(file, reader);
			}
			if (this.File.Header.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.NextExtraData = new NiRef<NiExtraData>(reader.ReadUInt32());
			}
		}
	}
}
