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
    /// Class NiUVData.
    /// </summary>
    public class NiUVData : NiObject
	{
        /// <summary>
        /// The u translation
        /// </summary>
        public KeyGroup<FloatKey> UTranslation;

        /// <summary>
        /// The v translation
        /// </summary>
        public KeyGroup<FloatKey> VTranslation;

        /// <summary>
        /// The u scaling and tiling
        /// </summary>
        public KeyGroup<FloatKey> UScalingAndTiling;

        /// <summary>
        /// The v scaling and tiling
        /// </summary>
        public KeyGroup<FloatKey> VScalingAndTiling;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiUVData"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiUVData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UTranslation = new KeyGroup<FloatKey>(reader);
			this.VTranslation = new KeyGroup<FloatKey>(reader);
			this.UScalingAndTiling = new KeyGroup<FloatKey>(reader);
			this.VScalingAndTiling = new KeyGroup<FloatKey>(reader);
		}
	}
}
