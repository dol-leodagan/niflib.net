using System;
using System.IO;

namespace Niflib
{
	public class NiTriStrips : NiTriBasedGeometry
	{
		public NiTriStrips(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
