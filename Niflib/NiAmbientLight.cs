using System;
using System.IO;

namespace Niflib
{
	public class NiAmbientLight : NiLight
	{
		public NiAmbientLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
