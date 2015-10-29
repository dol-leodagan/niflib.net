using System;
using System.IO;

namespace Niflib
{
	public class NiParticleColorModifier : NiParticleModifier
	{
		public NiRef<NiColorData> Data;

		public NiParticleColorModifier(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new NiRef<NiColorData>(reader);
		}
	}
}
