using System;
using System.IO;

namespace Niflib
{
	public class NiFloatData : NiObject
	{
		public KeyGroup<FloatKey> Data;

		public NiFloatData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new KeyGroup<FloatKey>(reader);
		}
	}
}
