using System;
using System.IO;

namespace Niflib
{
	public class NiObjectNET : NiObject
	{
		public NiString Name;

		public NiRef<NiExtraData>[] ExtraData;

		public NiRef<NiTimeController> Controller;

		public NiObjectNET(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Name = new NiString(file, reader);
			if (this.File.Header.Version <= eNifVersion.VER_2_3)
			{
				throw new Exception("Unsupported Version!");
			}
			if (this.File.Header.Version >= eNifVersion.VER_3_0 && this.File.Header.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.ExtraData = new NiRef<NiExtraData>[1];
				this.ExtraData[0] = new NiRef<NiExtraData>(reader.ReadUInt32());
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				uint num = reader.ReadUInt32();
				this.ExtraData = new NiRef<NiExtraData>[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.ExtraData[num2] = new NiRef<NiExtraData>(reader.ReadUInt32());
					num2++;
				}
			}
			if (this.File.Header.Version >= eNifVersion.VER_3_0)
			{
				this.Controller = new NiRef<NiTimeController>(reader.ReadUInt32());
			}
		}
	}
}
