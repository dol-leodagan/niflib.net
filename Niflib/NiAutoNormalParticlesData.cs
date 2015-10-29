using System;
using System.IO;

namespace Niflib
{
	public class NiAutoNormalParticlesData : NiParticlesData
	{
		public NiAutoNormalParticlesData(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
