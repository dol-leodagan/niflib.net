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
    /// Class NiGeomMorpherController.
    /// </summary>
    public class NiGeomMorpherController : NiInterpController
	{
        /// <summary>
        /// The extra flags
        /// </summary>
        public ushort ExtraFlags;

        /// <summary>
        /// The unknown2
        /// </summary>
        public byte Unknown2;

        /// <summary>
        /// The data
        /// </summary>
        public NiRef<NiMorphData> Data;

        /// <summary>
        /// The always update
        /// </summary>
        public bool AlwaysUpdate;

        /// <summary>
        /// The number interpolators
        /// </summary>
        public uint NumInterpolators;

        /// <summary>
        /// The interpolators
        /// </summary>
        public NiRef<NiInterpolator>[] Interpolators;

        /// <summary>
        /// The number unkown ints
        /// </summary>
        public uint NumUnkownInts;

        /// <summary>
        /// The unkown ints
        /// </summary>
        public uint[] UnkownInts;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiGeomMorpherController" /> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        /// <exception cref="Exception">Version too new!</exception>
        public NiGeomMorpherController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_0_1_2)
			{
				this.ExtraFlags = reader.ReadUInt16();
			}
			if (base.Version == eNifVersion.VER_10_1_0_106)
			{
				this.Unknown2 = reader.ReadByte();
			}
			this.Data = new NiRef<NiMorphData>(reader);
			this.AlwaysUpdate = reader.ReadBoolean(Version);
			if (base.Version >= eNifVersion.VER_10_1_0_106)
			{
				this.NumInterpolators = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_10_1_0_106 && base.Version < eNifVersion.VER_20_2_0_7)
			{
				this.Interpolators = new NiRef<NiInterpolator>[this.NumInterpolators];
				int num = 0;
				while ((long)num < (long)((ulong)this.NumInterpolators))
				{
					this.Interpolators[num] = new NiRef<NiInterpolator>(reader);
					num++;
				}
			}
			if (base.Version >= eNifVersion.VER_20_0_0_4)
			{
				throw new Exception("Version too new!");
			}
		}
	}
}
