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
    /// Class NiRef.
    /// </summary>
    /// <typeparam name="T">NiObject</typeparam>
    public class NiRef<T> where T : NiObject
	{
        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>The object.</value>
        public T Object
		{
			get;
			private set;
		}

        /// <summary>
        /// Gets the reference identifier.
        /// </summary>
        /// <value>The reference identifier.</value>
        public uint RefId
		{
			get;
			private set;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NiRef{T}"/> class.
        /// </summary>
        /// <param name="refId">The reference identifier.</param>
        public NiRef(uint refId)
		{
			this.RefId = refId;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="NiRef{T}"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public NiRef(BinaryReader reader) : this(reader.ReadUInt32())
		{
		}

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns><c>true</c> if this instance is valid; otherwise, <c>false</c>.</returns>
        public bool IsValid()
		{
			return this.RefId != 4294967295u;
		}

        /// <summary>
        /// Sets the reference.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SetRef(NiFile file)
		{
			if (this.IsValid())
			{
				this.Object = (T)((object)file.ObjectsByRef[this.RefId]);
			}
		}
	}
}
