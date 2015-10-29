using System;
using System.IO;

namespace Niflib
{
	public class NiIntegerExtraData : NiExtraData
	{
		public uint Data;

		public NiIntegerExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = reader.ReadUInt32();
		}
	}
}
