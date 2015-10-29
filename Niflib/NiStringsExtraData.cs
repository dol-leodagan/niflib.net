using System;
using System.IO;

namespace Niflib
{
	public class NiStringsExtraData : NiExtraData
	{
		public NiString[] ExtraStringData;

		public NiStringsExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.ExtraStringData = new NiString[reader.ReadUInt32()];
			for (int i = 0; i < this.ExtraStringData.Length; i++)
			{
				this.ExtraStringData[i] = new NiString(file, reader);
			}
		}
	}
}
