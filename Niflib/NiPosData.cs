using System;
using System.IO;

namespace Niflib
{
	public class NiPosData : NiObject
	{
		public KeyGroup<VecKey> Data;

		public NiPosData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new KeyGroup<VecKey>(reader);
		}
	}
}
