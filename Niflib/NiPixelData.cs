using System;
using System.IO;

namespace Niflib
{
	public class NiPixelData : ATextureRenderData
	{
		public uint NumPixels;

		public uint NumFaces;

		public byte[][] PixelData;

		public NiPixelData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NumPixels = reader.ReadUInt32();
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				this.NumFaces = reader.ReadUInt32();
				this.PixelData = new byte[this.NumFaces][];
				int num = 0;
				while ((long)num < (long)((ulong)this.NumFaces))
				{
					this.PixelData[num] = new byte[this.NumPixels];
					int num2 = 0;
					while ((long)num2 < (long)((ulong)this.NumPixels))
					{
						this.PixelData[num][num2] = reader.ReadByte();
						num2++;
					}
					num++;
				}
			}
			if (base.Version <= eNifVersion.VER_10_2_0_0)
			{
				this.NumFaces = 1u;
				this.PixelData = new byte[this.NumFaces][];
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.NumFaces))
				{
					this.PixelData[num3] = new byte[this.NumPixels];
					int num4 = 0;
					while ((long)num4 < (long)((ulong)this.NumPixels))
					{
						this.PixelData[num3][num4] = reader.ReadByte();
						num4++;
					}
					num3++;
				}
			}
		}
	}
}
