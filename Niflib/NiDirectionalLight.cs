using System;
using System.IO;

namespace Niflib
{
	public class NiDirectionalLight : NiLight
	{
		public NiDirectionalLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
