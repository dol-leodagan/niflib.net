using System;
using System.IO;

namespace Niflib
{
	public class ATextureRenderData : NiObject
	{
		public ePixelFormat PixelFormat;

		public uint RedMask;

		public uint GreenMask;

		public uint BlueMask;

		public uint AlphaMask;

		public byte BitsPerPixel;

		public byte[] Unkown3Bytes;

		public byte[] Unkown8Bytes;

		public uint UnkownInt;

		public uint UnkownInt2;

		public uint UnkownInt3;

		public uint UnkownInt4;

		public byte Flags;

		public byte UnkownByte1;

		public ChannelData[] ChannelData;

		public NiRef<NiPalette> Palette;

		public uint NumMipMaps;

		public uint BytesPerPixel;

		public MipMap[] MipMaps;

		public ATextureRenderData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.PixelFormat = (ePixelFormat)reader.ReadUInt32();
			if (base.Version <= eNifVersion.VER_10_2_0_0)
			{
				this.RedMask = reader.ReadUInt32();
				this.GreenMask = reader.ReadUInt32();
				this.BlueMask = reader.ReadUInt32();
				this.AlphaMask = reader.ReadUInt32();
				this.BitsPerPixel = reader.ReadByte();
				this.Unkown3Bytes = new byte[3];
				for (int i = 0; i < this.Unkown3Bytes.Length; i++)
				{
					this.Unkown3Bytes[i] = reader.ReadByte();
				}
				this.Unkown8Bytes = new byte[8];
				for (int j = 0; j < this.Unkown8Bytes.Length; j++)
				{
					this.Unkown8Bytes[j] = reader.ReadByte();
				}
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0 && base.Version <= eNifVersion.VER_10_2_0_0)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				this.BitsPerPixel = reader.ReadByte();
				this.UnkownInt2 = reader.ReadUInt32();
				this.UnkownInt3 = reader.ReadUInt32();
				this.Flags = reader.ReadByte();
				this.UnkownInt4 = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_20_3_0_6)
			{
				this.UnkownByte1 = reader.ReadByte();
			}
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				this.ChannelData = new ChannelData[4];
				for (int k = 0; k < 4; k++)
				{
					this.ChannelData[k] = new ChannelData(file, reader);
				}
			}
			this.Palette = new NiRef<NiPalette>(reader);
			this.NumMipMaps = reader.ReadUInt32();
			this.BytesPerPixel = reader.ReadUInt32();
			this.MipMaps = new MipMap[this.NumMipMaps];
			int num = 0;
			while ((long)num < (long)((ulong)this.NumMipMaps))
			{
				this.MipMaps[num] = new MipMap(file, reader);
				num++;
			}
		}
	}
}
