using System;
using System.IO;

namespace Niflib
{
	public class NiSingleInterpController : NiInterpController
	{
		public NiRef<NiInterpolator> Interpolator;

		public NiSingleInterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_2_0_0)
			{
				this.Interpolator = new NiRef<NiInterpolator>(reader);
			}
		}
	}
}
