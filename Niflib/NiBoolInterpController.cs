using System;
using System.IO;

namespace Niflib
{
	public class NiBoolInterpController : NiSingleInterpController
	{
		public NiBoolInterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
