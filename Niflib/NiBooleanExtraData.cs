using System;
using System.IO;

namespace Niflib
{
	public class NiBooleanExtraData : NiExtraData
	{
		public bool Data;

		public NiBooleanExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = reader.ReadBoolean();
		}
	}
}
