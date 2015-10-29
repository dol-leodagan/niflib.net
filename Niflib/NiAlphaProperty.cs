using System;
using System.IO;

namespace Niflib
{
	public class NiAlphaProperty : NiProperty
	{
		public ushort Flags;

		public byte Threshold;

		public NiAlphaProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
			this.Threshold = reader.ReadByte();
		}
	}
}
