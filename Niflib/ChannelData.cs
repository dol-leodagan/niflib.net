using System;
using System.IO;

namespace Niflib
{
	public class ChannelData
	{
		public eChannelType Type;

		public eChannelConvention Convention;

		public byte BitsPerChannel;

		public byte UnkownByte;

		public ChannelData(NiFile file, BinaryReader reader)
		{
			this.Type = (eChannelType)reader.ReadUInt32();
			this.Convention = (eChannelConvention)reader.ReadUInt32();
			this.BitsPerChannel = reader.ReadByte();
			this.UnkownByte = reader.ReadByte();
		}
	}
}
