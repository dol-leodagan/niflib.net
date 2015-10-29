using System;
using System.IO;

namespace Niflib
{
	public class NiVisController : NiBoolInterpController
	{
		public NiRef<NiVisData> Data;

		public NiVisController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Data = new NiRef<NiVisData>(reader);
			}
		}
	}
}
