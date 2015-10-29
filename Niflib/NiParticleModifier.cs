using System;
using System.IO;

namespace Niflib
{
	public class NiParticleModifier : NiObject
	{
		public NiRef<NiParticleModifier> Next;

		public NiRef<NiParticleSystemController> Controller;

		public NiParticleModifier(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Next = new NiRef<NiParticleModifier>(reader);
			if (this.File.Header.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.Controller = new NiRef<NiParticleSystemController>(reader);
			}
		}
	}
}
