using System;
using System.IO;

namespace Niflib
{
	public class NiStringExtraData : NiExtraData
	{
		public uint BytesRemaining;

		public NiString StringData;

		public NiStringExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.BytesRemaining = reader.ReadUInt32();
			}
			this.StringData = new NiString(file, reader);
		}
	}
}
