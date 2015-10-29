using System;
using System.IO;

namespace Niflib
{
	public class NiPoint3InterpController : NiSingleInterpController
	{
		public eTargetColor TargetColor;

		public NiRef<NiPosData> Data;

		public NiPoint3InterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.TargetColor = (eTargetColor)reader.ReadUInt16();
			}
			if (base.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Data = new NiRef<NiPosData>(reader);
			}
		}
	}
}
