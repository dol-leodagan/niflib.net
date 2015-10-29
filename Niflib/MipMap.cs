using System;
using System.IO;

namespace Niflib
{
	public class MipMap
	{
		public uint Width;

		public uint Height;

		public uint Offset;

		public MipMap(NiFile file, BinaryReader reader)
		{
			this.Width = reader.ReadUInt32();
			this.Height = reader.ReadUInt32();
			this.Offset = reader.ReadUInt32();
		}
	}
}
