using System;
using System.IO;

namespace Niflib
{
	public class NiParticleMeshModifier : NiParticleModifier
	{
		public NiRef<NiAVObject>[] ParticleMeshes;

		public NiParticleMeshModifier(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.ParticleMeshes = new NiRef<NiAVObject>[reader.ReadUInt32()];
			for (int i = 0; i < this.ParticleMeshes.Length; i++)
			{
				this.ParticleMeshes[i] = new NiRef<NiAVObject>(reader);
			}
		}
	}
}
