using System;
using System.IO;

namespace Niflib
{
	public class NiMaterialColorController : NiPoint3InterpController
	{
		public NiMaterialColorController(NiFile file, BinaryReader reader) : base(file, reader)
		{
		}
	}
}
