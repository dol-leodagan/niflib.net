/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

namespace Niflib
{
	using System;
	using System.IO;

    /// <summary>
    /// Class ATextureRenderData.
    /// </summary>
    public class ATextureRenderData : NiObject
	{
        /// <summary>
        /// The pixel format
        /// </summary>
        public ePixelFormat PixelFormat;

        /// <summary>
        /// The red mask
        /// </summary>
        public uint RedMask;

        /// <summary>
        /// The green mask
        /// </summary>
        public uint GreenMask;

        /// <summary>
        /// The blue mask
        /// </summary>
        public uint BlueMask;

        /// <summary>
        /// The alpha mask
        /// </summary>
        public uint AlphaMask;

        /// <summary>
        /// The bits per pixel
        /// </summary>
        public byte BitsPerPixel;

        /// <summary>
        /// The unkown3 bytes
        /// </summary>
        public byte[] Unkown3Bytes;

        /// <summary>
        /// The unkown8 bytes
        /// </summary>
        public byte[] Unkown8Bytes;

        /// <summary>
        /// The unkown int
        /// </summary>
        public uint UnkownInt;

        /// <summary>
        /// The unkown int2
        /// </summary>
        public uint UnkownInt2;

        /// <summary>
        /// The unkown int3
        /// </summary>
        public uint UnkownInt3;

        /// <summary>
        /// The unkown int4
        /// </summary>
        public uint UnkownInt4;

        /// <summary>
        /// The flags
        /// </summary>
        public byte Flags;

        /// <summary>
        /// The unkown byte1
        /// </summary>
        public byte UnkownByte1;

        /// <summary>
        /// The channel data
        /// </summary>
        public ChannelData[] ChannelData;

        /// <summary>
        /// The palette
        /// </summary>
        public NiRef<NiPalette> Palette;

        /// <summary>
        /// The number mip maps
        /// </summary>
        public uint NumMipMaps;

        /// <summary>
        /// The bytes per pixel
        /// </summary>
        public uint BytesPerPixel;

        /// <summary>
        /// The mip maps
        /// </summary>
        public MipMap[] MipMaps;

        /// <summary>
        /// Initializes a new instance of the <see cref="ATextureRenderData" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
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
