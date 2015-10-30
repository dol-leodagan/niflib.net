#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class TexDesc
	{
		public NiRef<NiSourceTexture> Source;

		public eTexClampMode ClampMode;

		public eTexFilterMode FilterMode;

		public ushort Flags;

		public uint UVSetIndex;

		public short PS2L;

		public short PS2K;

		public bool HasTextureTransform;

		public Vector2 Translation;

		public Vector2 Tiling;

		public float WRotation;

		public uint TransformType;

		public Vector2 CenterOffset;

		public TexDesc(NiFile file, BinaryReader reader)
		{
			this.Source = new NiRef<NiSourceTexture>(reader);
			if (file.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.ClampMode = (eTexClampMode)reader.ReadUInt32();
				this.FilterMode = (eTexFilterMode)reader.ReadUInt32();
			}
			if (file.Version >= eNifVersion.VER_20_1_0_3)
			{
				this.Flags = reader.ReadUInt16();
			}
			if (file.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.UVSetIndex = reader.ReadUInt32();
			}
			if (file.Version <= eNifVersion.VER_10_4_0_1)
			{
				this.PS2L = reader.ReadInt16();
				this.PS2K = reader.ReadInt16();
			}
			if (file.Version <= eNifVersion.VER_4_1_0_12)
			{
				reader.ReadUInt16();
			}
			if (file.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasTextureTransform = reader.ReadBoolean();
				if (this.HasTextureTransform)
				{
					this.Translation = reader.ReadVector2();
					this.Tiling = reader.ReadVector2();
					this.WRotation = reader.ReadSingle();
					this.TransformType = reader.ReadUInt32();
					this.CenterOffset = reader.ReadVector2();
				}
			}
		}
	}
}
