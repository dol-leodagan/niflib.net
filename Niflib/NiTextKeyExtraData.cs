using System;
using System.IO;

namespace Niflib
{
	public class NiTextKeyExtraData : NiExtraData
	{
		public uint NumTextKeys;

		public uint UnkownInt1;

		public StringKey[] TextKeys;

		public NiTextKeyExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.UnkownInt1 = reader.ReadUInt32();
			}
			this.NumTextKeys = reader.ReadUInt32();
			this.TextKeys = new StringKey[this.NumTextKeys];
			int num = 0;
			while ((long)num < (long)((ulong)this.NumTextKeys))
			{
				this.TextKeys[num] = new StringKey(reader, eKeyType.LINEAR_KEY);
				num++;
			}
		}
	}
}
