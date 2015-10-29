using System;
using System.IO;

namespace Niflib
{
	public class NiUVController : NiTimeController
	{
		public ushort UnkownShort1;

		public NiRef<NiUVData> Data;

		public NiUVController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownShort1 = reader.ReadUInt16();
			this.Data = new NiRef<NiUVData>(reader);
		}
	}
}
