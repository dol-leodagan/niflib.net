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
using OpenTK.Graphics;
using Color3 = OpenTK.Graphics.Color4;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Color3 = Microsoft.Xna.Framework.Color;
#endif
using System;
using System.IO;

/// <summary>
/// The Niflib namespace.
/// </summary>
namespace Niflib
{
    /// <summary>
    /// Class NiLight.
    /// </summary>
    public class NiLight : NiDynamicEffect
	{
        /// <summary>
        /// The dimmer
        /// </summary>
        public float Dimmer;

        /// <summary>
        /// The ambient color
        /// </summary>
        public Color3 AmbientColor;

        /// <summary>
        /// The diffuse color
        /// </summary>
        public Color3 DiffuseColor;

        /// <summary>
        /// The specular color
        /// </summary>
        public Color3 SpecularColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiLight"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Dimmer = reader.ReadSingle();
			this.AmbientColor = reader.ReadColor3();
			this.DiffuseColor = reader.ReadColor3();
			this.SpecularColor = reader.ReadColor3();
		}
	}
}
