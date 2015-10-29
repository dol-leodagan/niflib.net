using System;
using System.IO;

namespace Niflib
{
	public class NiDitherProperty : NiProperty
	{
		public ushort Flags;

		public NiDitherProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
		}
	}
}
