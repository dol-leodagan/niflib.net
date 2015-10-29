using System;
using System.IO;

namespace Niflib
{
	public class NiSpecularProperty : NiProperty
	{
		public ushort Flags;

		public NiSpecularProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
		}
	}
}
