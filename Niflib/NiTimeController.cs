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
    /// Class NiTimeController.
    /// </summary>
    public class NiTimeController : NiObject
	{
        /// <summary>
        /// The next controller
        /// </summary>
        public NiRef<NiTimeController> NextController;

        /// <summary>
        /// The flags
        /// </summary>
        public ushort Flags;

        /// <summary>
        /// The frequency
        /// </summary>
        public float Frequency;

        /// <summary>
        /// The phase
        /// </summary>
        public float Phase;

        /// <summary>
        /// The start time
        /// </summary>
        public float StartTime;

        /// <summary>
        /// The stop time
        /// </summary>
        public float StopTime;

        /// <summary>
        /// The target
        /// </summary>
        public NiRef<NiObjectNET> Target;

        /// <summary>
        /// The unkown int
        /// </summary>
        public uint UnkownInt;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiTimeController"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiTimeController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NextController = new NiRef<NiTimeController>(reader);
			this.Flags = reader.ReadUInt16();
			this.Frequency = reader.ReadSingle();
			this.Phase = reader.ReadSingle();
			this.StartTime = reader.ReadSingle();
			this.StopTime = reader.ReadSingle();
			if (file.Header.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.Target = new NiRef<NiObjectNET>(reader);
			}
			if (file.Header.Version <= eNifVersion.VER_3_1)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
		}
	}
}
