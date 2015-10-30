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
#if OpenTK
using OpenTK;
using Matrix = OpenTK.Matrix4;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
#endif
using System;
using System.IO;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class SkinTransform.
    /// </summary>
    public class SkinTransform
	{
        /// <summary>
        /// The rotation
        /// </summary>
        public Matrix Rotation;

        /// <summary>
        /// The translation
        /// </summary>
        public Vector3 Translation;

        /// <summary>
        /// The scale
        /// </summary>
        public float Scale;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinTransform"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public SkinTransform(NiFile file, BinaryReader reader)
		{
			this.Rotation = reader.ReadMatrix33();
			this.Translation = reader.ReadVector3();
			this.Scale = reader.ReadSingle();
		}
	}
}
