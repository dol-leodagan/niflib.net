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
using System;
using System.IO;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class SkinPartitionUnkownItem1.
    /// </summary>
    public class SkinPartitionUnkownItem1
	{
        /// <summary>
        /// The flags
        /// </summary>
        public uint Flags;

        /// <summary>
        /// The unkown1
        /// </summary>
        public float Unkown1;

        /// <summary>
        /// The unkown2
        /// </summary>
        public float Unkown2;

        /// <summary>
        /// The unkown3
        /// </summary>
        public float Unkown3;

        /// <summary>
        /// The unkown4
        /// </summary>
        public float Unkown4;

        /// <summary>
        /// The unkown5
        /// </summary>
        public float Unkown5;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinPartitionUnkownItem1"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public SkinPartitionUnkownItem1(NiFile file, BinaryReader reader)
		{
			this.Flags = reader.ReadUInt32();
			this.Unkown1 = reader.ReadSingle();
			this.Unkown2 = reader.ReadSingle();
			this.Unkown3 = reader.ReadSingle();
			this.Unkown4 = reader.ReadSingle();
			this.Unkown5 = reader.ReadSingle();
		}
	}
}
