using System;
using System.IO;

namespace Niflib
{
	public class NiZBufferProperty : NiProperty
	{
		public ushort Flags;

		public uint ZCompareMode;

		public NiZBufferProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
			if (base.Version >= eNifVersion.VER_4_1_0_12 && base.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.ZCompareMode = reader.ReadUInt32();
			}
		}
	}
}
