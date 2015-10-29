using System;
using System.IO;

namespace Niflib
{
	public class NiTimeController : NiObject
	{
		public NiRef<NiTimeController> NextController;

		public ushort Flags;

		public float Frequency;

		public float Phase;

		public float StartTime;

		public float StopTime;

		public NiRef<NiObjectNET> Target;

		public uint UnkownInt;

		public NiTimeController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NextController = new NiRef<NiTimeController>(reader);
			this.Flags = reader.ReadUInt16();
			this.Frequency = reader.ReadSingle();
			this.Phase = reader.ReadSingle();
			this.StartTime = reader.ReadSingle();
			this.StopTime = reader.ReadSingle();
			if (file.Header.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.Target = new NiRef<NiObjectNET>(reader);
			}
			if (file.Header.Version <= eNifVersion.VER_3_1)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
		}
	}
}
