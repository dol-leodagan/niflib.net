using System;
using System.IO;

namespace Niflib
{
	public class NiFloatInterpController : NiSingleInterpController
	{
		public NiFloatInterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
