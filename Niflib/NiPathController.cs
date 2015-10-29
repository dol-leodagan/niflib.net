using System;
using System.IO;

namespace Niflib
{
	public class NiPathController : NiTimeController
	{
		public ushort Unknown1;

		public uint Unknown2;

		public float Unknown3;

		public float Unknown4;

		public ushort Unknown5;

		public NiRef<NiPosData> PosData;

		public NiRef<NiFloatData> FloatData;

		public NiPathController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.Unknown1 = reader.ReadUInt16();
			}
			this.Unknown2 = reader.ReadUInt32();
			this.Unknown3 = reader.ReadSingle();
			this.Unknown4 = reader.ReadSingle();
			this.Unknown5 = reader.ReadUInt16();
			this.PosData = new NiRef<NiPosData>(reader);
			this.FloatData = new NiRef<NiFloatData>(reader);
		}
	}
}
