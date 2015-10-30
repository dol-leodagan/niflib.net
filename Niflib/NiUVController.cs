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
    /// Class NiUVController.
    /// </summary>
    public class NiUVController : NiTimeController
	{
        /// <summary>
        /// The unkown short1
        /// </summary>
        public ushort UnkownShort1;

        /// <summary>
        /// The data
        /// </summary>
        public NiRef<NiUVData> Data;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiUVController"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiUVController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownShort1 = reader.ReadUInt16();
			this.Data = new NiRef<NiUVData>(reader);
		}
	}
}
