using System;
using System.IO;

namespace Niflib
{
	public class NiParticleGrowFade : NiParticleModifier
	{
		public float Grow;

		public float Fade;

		public NiParticleGrowFade(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Grow = reader.ReadSingle();
			this.Fade = reader.ReadSingle();
		}
	}
}
