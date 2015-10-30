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
    /// Class ChannelData.
    /// </summary>
    public class ChannelData
	{
        /// <summary>
        /// The type
        /// </summary>
        public eChannelType Type;

        /// <summary>
        /// The convention
        /// </summary>
        public eChannelConvention Convention;

        /// <summary>
        /// The bits per channel
        /// </summary>
        public byte BitsPerChannel;

        /// <summary>
        /// The unkown byte
        /// </summary>
        public byte UnkownByte;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelData"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public ChannelData(NiFile file, BinaryReader reader)
		{
			this.Type = (eChannelType)reader.ReadUInt32();
			this.Convention = (eChannelConvention)reader.ReadUInt32();
			this.BitsPerChannel = reader.ReadByte();
			this.UnkownByte = reader.ReadByte();
		}
	}
}
