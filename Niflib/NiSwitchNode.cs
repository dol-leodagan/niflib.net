using System;
using System.IO;

namespace Niflib
{
	public class NiSwitchNode : NiNode
	{
		public ushort UnkownFlags;

		public int UnkownInt;

		public NiSwitchNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.UnkownFlags = reader.ReadUInt16();
			}
			this.UnkownInt = reader.ReadInt32();
		}
	}
}
