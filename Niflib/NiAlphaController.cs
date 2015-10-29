using System;
using System.IO;

namespace Niflib
{
	public class NiAlphaController : NiFloatInterpController
	{
		public NiRef<NiFloatData> Data;

		public NiAlphaController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Data = new NiRef<NiFloatData>(reader);
			}
		}
	}
}
