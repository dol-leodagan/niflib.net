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
    /// Class KeyGroup.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class KeyGroup<T> where T : BaseKey
	{
        /// <summary>
        /// The interpolation
        /// </summary>
        public eKeyType Interpolation;

        /// <summary>
        /// The values
        /// </summary>
        public T[] Values;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyGroup{T}"/> class.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public KeyGroup(BinaryReader reader)
		{
			this.Values = new T[reader.ReadUInt32()];
			if (this.Values.Length != 0)
			{
				this.Interpolation = (eKeyType)reader.ReadUInt32();
			}
			for (int i = 0; i < this.Values.Length; i++)
			{
				this.Values[i] = (T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					reader,
					this.Interpolation
				}));
			}
		}
	}
}
