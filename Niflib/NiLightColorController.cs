using System;
using System.IO;

namespace Niflib
{
	public class NiLightColorController : NiPoint3InterpController
	{
		public NiLightColorController(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
