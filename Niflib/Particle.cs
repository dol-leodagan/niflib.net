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
    /// Class Particle.
    /// </summary>
    public class Particle
	{
        /// <summary>
        /// The velocity
        /// </summary>
        public Vector3 Velocity;

        /// <summary>
        /// The unkown vector
        /// </summary>
        public Vector3 UnkownVector;

        /// <summary>
        /// The lifetime
        /// </summary>
        public float Lifetime;

        /// <summary>
        /// The lifespan
        /// </summary>
        public float Lifespan;

        /// <summary>
        /// The timestamp
        /// </summary>
        public float Timestamp;

        /// <summary>
        /// The unkown short
        /// </summary>
        public ushort UnkownShort;

        /// <summary>
        /// The vertex identifier
        /// </summary>
        public ushort VertexID;

        /// <summary>
        /// Initializes a new instance of the <see cref="Particle"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public Particle(NiFile file, BinaryReader reader)
		{
			this.Velocity = reader.ReadVector3();
			this.UnkownVector = reader.ReadVector3();
			this.Lifetime = reader.ReadSingle();
			this.Lifespan = reader.ReadSingle();
			this.Timestamp = reader.ReadSingle();
			this.UnkownShort = reader.ReadUInt16();
			this.VertexID = reader.ReadUInt16();
		}
	}
}
