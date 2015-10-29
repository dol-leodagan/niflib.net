using System;
using System.IO;

namespace Niflib
{
	public class NiTriBasedGeometry : NiGeometry
	{
		public NiTriBasedGeometry(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
