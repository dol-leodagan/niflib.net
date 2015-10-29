using System;
using System.IO;

namespace Niflib
{
	public class NiFloatExtraData : NiExtraData
	{
		public float Data;

		public NiFloatExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = reader.ReadSingle();
		}
	}
}
