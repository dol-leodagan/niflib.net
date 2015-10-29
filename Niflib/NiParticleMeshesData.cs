using System;
using System.IO;

namespace Niflib
{
	public class NiParticleMeshesData : NiRotatingParticlesData
	{
		public NiRef<NiAVObject> UnkownLink;

		public NiParticleMeshesData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownLink = new NiRef<NiAVObject>(reader);
		}
	}
}
