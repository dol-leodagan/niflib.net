using System;
using System.IO;

namespace Niflib
{
	public class NiTriShape : NiTriBasedGeometry
	{
		public NiTriShape(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
