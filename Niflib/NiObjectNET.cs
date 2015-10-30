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
    /// Class NiObjectNET.
    /// </summary>
    public class NiObjectNET : NiObject
	{
        /// <summary>
        /// The name
        /// </summary>
        public NiString Name;

        /// <summary>
        /// The extra data
        /// </summary>
        public NiRef<NiExtraData>[] ExtraData;

        /// <summary>
        /// The controller
        /// </summary>
        public NiRef<NiTimeController> Controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiObjectNET" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        /// <exception cref="Exception">Unsupported Version!</exception>
        public NiObjectNET(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Name = new NiString(file, reader);
			if (this.File.Header.Version <= eNifVersion.VER_2_3)
			{
				throw new Exception("Unsupported Version!");
			}
			if (this.File.Header.Version >= eNifVersion.VER_3_0 && this.File.Header.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.ExtraData = new NiRef<NiExtraData>[1];
				this.ExtraData[0] = new NiRef<NiExtraData>(reader.ReadUInt32());
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				uint num = reader.ReadUInt32();
				this.ExtraData = new NiRef<NiExtraData>[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.ExtraData[num2] = new NiRef<NiExtraData>(reader.ReadUInt32());
					num2++;
				}
			}
			if (this.File.Header.Version >= eNifVersion.VER_3_0)
			{
				this.Controller = new NiRef<NiTimeController>(reader.ReadUInt32());
			}
		}
	}
}
