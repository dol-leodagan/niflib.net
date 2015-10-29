using System;
using System.IO;

namespace Niflib
{
	public class NiParticleMeshes : NiParticles
	{
		public NiParticleMeshes(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
