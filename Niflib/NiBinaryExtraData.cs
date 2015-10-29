using System;
using System.IO;

namespace Niflib
{
	public class NiBinaryExtraData : NiExtraData
	{
		public byte[] Data;

		public NiBinaryExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = reader.ReadBytes((int)reader.ReadUInt32());
		}
	}
}
