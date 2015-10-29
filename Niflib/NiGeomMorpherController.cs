using System;
using System.IO;

namespace Niflib
{
	public class NiGeomMorpherController : NiInterpController
	{
		public ushort ExtraFlags;

		public byte Unknown2;

		public NiRef<NiMorphData> Data;

		public bool AlwaysUpdate;

		public uint NumInterpolators;

		public NiRef<NiInterpolator>[] Interpolators;

		public uint NumUnkownInts;

		public uint[] UnkownInts;

		public NiGeomMorpherController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_0_1_2)
			{
				this.ExtraFlags = reader.ReadUInt16();
			}
			if (base.Version == eNifVersion.VER_10_1_0_106)
			{
				this.Unknown2 = reader.ReadByte();
			}
			this.Data = new NiRef<NiMorphData>(reader);
			this.AlwaysUpdate = reader.ReadBoolean();
			if (base.Version >= eNifVersion.VER_10_1_0_106)
			{
				this.NumInterpolators = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_10_1_0_106 && base.Version < eNifVersion.VER_20_2_0_7)
			{
				this.Interpolators = new NiRef<NiInterpolator>[this.NumInterpolators];
				int num = 0;
				while ((long)num < (long)((ulong)this.NumInterpolators))
				{
					this.Interpolators[num] = new NiRef<NiInterpolator>(reader);
					num++;
				}
			}
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				throw new Exception("Version too new!");
			}
		}
	}
}
