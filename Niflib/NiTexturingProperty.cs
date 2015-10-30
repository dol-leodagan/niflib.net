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
	#elif SharpDX
	using SharpDX;
	#elif MonoGame
	using Microsoft.Xna.Framework;
	#endif
	using System;
	using System.IO;

    /// <summary>
    /// Class NiTexturingProperty.
    /// </summary>
    public class NiTexturingProperty : NiProperty
	{
        /// <summary>
        /// The flags
        /// </summary>
        public ushort Flags;

        /// <summary>
        /// The apply mode
        /// </summary>
        public uint ApplyMode;

        /// <summary>
        /// The texture count
        /// </summary>
        public uint TextureCount;

        /// <summary>
        /// The base texture
        /// </summary>
        public TexDesc BaseTexture;

        /// <summary>
        /// The dark texture
        /// </summary>
        public TexDesc DarkTexture;

        /// <summary>
        /// The detail texture
        /// </summary>
        public TexDesc DetailTexture;

        /// <summary>
        /// The gloss texture
        /// </summary>
        public TexDesc GlossTexture;

        /// <summary>
        /// The glow texture
        /// </summary>
        public TexDesc GlowTexture;

        /// <summary>
        /// The bump map texture
        /// </summary>
        public TexDesc BumpMapTexture;

        /// <summary>
        /// The decal0 texture
        /// </summary>
        public TexDesc Decal0Texture;

        /// <summary>
        /// The decal1 texture
        /// </summary>
        public TexDesc Decal1Texture;

        /// <summary>
        /// The decal2 texture
        /// </summary>
        public TexDesc Decal2Texture;

        /// <summary>
        /// The decal3 texture
        /// </summary>
        public TexDesc Decal3Texture;

        /// <summary>
        /// The unkown1
        /// </summary>
        public uint Unkown1;

        /// <summary>
        /// The bump map luma scale
        /// </summary>
        public float BumpMapLumaScale;

        /// <summary>
        /// The bump map luma offset
        /// </summary>
        public float BumpMapLumaOffset;

        /// <summary>
        /// The bump map matrix
        /// </summary>
        public Vector3 BumpMapMatrix;

        /// <summary>
        /// The number shader textures
        /// </summary>
        public uint NumShaderTextures;

        /// <summary>
        /// Initializes a new instance of the <see cref="NiTexturingProperty"/> class.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        public NiTexturingProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_10_0_1_2 || base.Version >= eNifVersion.VER_20_1_0_3)
			{
				this.Flags = reader.ReadUInt16();
			}
			if (base.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.ApplyMode = reader.ReadUInt32();
			}
			this.TextureCount = reader.ReadUInt32();
			if (reader.ReadBoolean())
			{
				this.BaseTexture = new TexDesc(file, reader);
			}
			if (reader.ReadBoolean())
			{
				this.DarkTexture = new TexDesc(file, reader);
			}
			if (reader.ReadBoolean())
			{
				this.DetailTexture = new TexDesc(file, reader);
			}
			if (reader.ReadBoolean())
			{
				this.GlossTexture = new TexDesc(file, reader);
			}
			if (reader.ReadBoolean())
			{
				this.GlowTexture = new TexDesc(file, reader);
			}
			if (reader.ReadBoolean())
			{
				this.BumpMapTexture = new TexDesc(file, reader);
				this.BumpMapLumaScale = reader.ReadSingle();
				this.BumpMapLumaOffset = reader.ReadSingle();
				this.BumpMapMatrix = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
				reader.ReadSingle();
			}
			if (reader.ReadBoolean())
			{
				this.Decal0Texture = new TexDesc(file, reader);
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.NumShaderTextures = reader.ReadUInt32();
				int num = 0;
				while ((long)num < (long)((ulong)this.NumShaderTextures))
				{
					if (reader.ReadBoolean())
					{
						new TexDesc(file, reader);
						reader.ReadUInt32();
					}
					num++;
				}
			}
		}
	}
}
