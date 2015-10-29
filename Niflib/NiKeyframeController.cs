using System;
using System.IO;

namespace Niflib
{
	public class NiKeyframeController : NiSingleInterpController
	{
		public NiRef<NiKeyframeData> Data;

		public NiKeyframeController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Data = new NiRef<NiKeyframeData>(reader);
			}
		}
	}
}
