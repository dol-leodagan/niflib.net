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
    /// Class NiNode.
    /// </summary>
    public class NiNode : NiAVObject
	{
        /// <summary>
        /// The children
        /// </summary>
        public NiRef<NiAVObject>[] Children;

        /// <summary>
        /// The effects
        /// </summary>
        public NiRef<NiDynamicEffect>[] Effects;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiNode"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Children = new NiRef<NiAVObject>[reader.ReadUInt32()];
			for (int i = 0; i < this.Children.Length; i++)
			{
				this.Children[i] = new NiRef<NiAVObject>(reader.ReadUInt32());
			}
			this.Effects = new NiRef<NiDynamicEffect>[reader.ReadUInt32()];
			for (int j = 0; j < this.Effects.Length; j++)
			{
				this.Effects[j] = new NiRef<NiDynamicEffect>(reader.ReadUInt32());
			}
		}
	}
}
