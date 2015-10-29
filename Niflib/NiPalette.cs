using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiPalette : NiObject
	{
		public byte UnkownByte;

		public Color4[] Palette;

		public NiPalette(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownByte = reader.ReadByte();
			this.Palette = new Color4[reader.ReadUInt32()];
			for (int i = 0; i < this.Palette.Length; i++)
			{
				this.Palette[i] = reader.ReadColor4Byte();
			}
		}
	}
}
