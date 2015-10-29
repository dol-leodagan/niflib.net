using System;
using System.IO;

namespace Niflib
{
	public class NiIntegersExtraData : NiExtraData
	{
		public uint[] ExtraIntData;

		public NiIntegersExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.ExtraIntData = new uint[reader.ReadUInt32()];
			for (int i = 0; i < this.ExtraIntData.Length; i++)
			{
				this.ExtraIntData[i] = reader.ReadUInt32();
			}
		}
	}
}
