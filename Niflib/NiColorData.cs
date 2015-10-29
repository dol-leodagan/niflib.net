using System;
using System.IO;

namespace Niflib
{
	public class NiColorData : NiObject
	{
		public KeyGroup<Color4Key> Data;

		public NiColorData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new KeyGroup<Color4Key>(reader);
		}
	}
}
