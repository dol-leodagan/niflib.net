using System;
using System.IO;

namespace Niflib
{
	public class NiWireframeProperty : NiProperty
	{
		public ushort Flags;

		public NiWireframeProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
		}
	}
}
