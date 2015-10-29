using System;
using System.IO;

namespace Niflib
{
	public class NiRotatingParticles : NiParticles
	{
		public NiRotatingParticles(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
