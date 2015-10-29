using System;
using System.IO;

namespace Niflib
{
	public class NiInterpController : NiTimeController
	{
		public NiInterpController(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
