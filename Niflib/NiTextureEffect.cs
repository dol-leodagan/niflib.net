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
    /// Class NiTextureEffect.
    /// </summary>
    public class NiTextureEffect : NiDynamicEffect
	{
        /// <summary>
        /// The model projection matrix
        /// </summary>
        public Matrix ModelProjectionMatrix;

        /// <summary>
        /// The model projection transform
        /// </summary>
        public Vector3 ModelProjectionTransform;

        /// <summary>
        /// The texture filtering
        /// </summary>
        public eTexFilterMode TextureFiltering;

        /// <summary>
        /// The texture clamping
        /// </summary>
        public eTexClampMode TextureClamping;

        /// <summary>
        /// The unknown1
        /// </summary>
        public ushort Unknown1;

        /// <summary>
        /// The effect type
        /// </summary>
        public eEffectType EffectType;

        /// <summary>
        /// The coord gen type
        /// </summary>
        public eCoordGenType CoordGenType;

        /// <summary>
        /// The source texture
        /// </summary>
        public NiRef<NiSourceTexture> SourceTexture;

        /// <summary>
        /// The clipping plane
        /// </summary>
        public bool ClippingPlane;

        /// <summary>
        /// The unknown vector
        /// </summary>
        public Vector3 unknownVector;

        /// <summary>
        /// The unknown2
        /// </summary>
        public float Unknown2;

        /// <summary>
        /// The p s2 l
        /// </summary>
        public short PS2L;

        /// <summary>
        /// The p s2 k
        /// </summary>
        public short PS2K;

        /// <summary>
        /// The unknown3
        /// </summary>
        public ushort Unknown3;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiTextureEffect"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        /// <exception cref="Exception">NOT SUPPORTED!</exception>
        public NiTextureEffect(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.ModelProjectionMatrix = reader.ReadMatrix33();
			this.ModelProjectionTransform = reader.ReadVector3();
			this.TextureFiltering = (eTexFilterMode)reader.ReadUInt32();
			this.TextureClamping = (eTexClampMode)reader.ReadUInt32();
			this.EffectType = (eEffectType)reader.ReadUInt32();
			this.CoordGenType = (eCoordGenType)reader.ReadUInt32();
			if (base.Version <= eNifVersion.VER_3_1)
			{
				throw new Exception("NOT SUPPORTED!");
			}
			if (base.Version >= eNifVersion.VER_4_0_0_0)
			{
				this.SourceTexture = new NiRef<NiSourceTexture>(reader);
			}
			this.ClippingPlane = reader.ReadBoolean(Version);
			this.unknownVector = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			this.Unknown2 = reader.ReadSingle();
			if (this.File.Header.Version <= eNifVersion.VER_10_2_0_0)
			{
				this.PS2L = reader.ReadInt16();
				this.PS2K = reader.ReadInt16();
			}
			if (this.File.Header.Version <= eNifVersion.VER_4_1_0_12)
			{
				this.Unknown3 = reader.ReadUInt16();
			}
		}
	}
}
