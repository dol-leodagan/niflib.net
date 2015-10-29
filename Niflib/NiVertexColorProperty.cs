using System;
using System.IO;

namespace Niflib
{
	public class NiVertexColorProperty : NiProperty
	{
		public ushort Flags;

		public uint VertexMode;

		public uint LightingMode;

		public NiVertexColorProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
			if (base.Version > eNifVersion.VER_20_0_0_5)
			{
				throw new Exception("unsupported data!");
			}
			this.VertexMode = reader.ReadUInt32();
			this.LightingMode = reader.ReadUInt32();
		}
	}
}
