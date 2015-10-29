using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiTexturingProperty : NiProperty
	{
		public ushort Flags;

		public uint ApplyMode;

		public uint TextureCount;

		public TexDesc BaseTexture;

		public TexDesc DarkTexture;

		public TexDesc DetailTexture;

		public TexDesc GlossTexture;

		public TexDesc GlowTexture;

		public TexDesc BumpMapTexture;

		public TexDesc Decal0Texture;

		public TexDesc Decal1Texture;

		public TexDesc Decal2Texture;

		public TexDesc Decal3Texture;

		public uint Unkown1;

		public float BumpMapLumaScale;

		public float BumpMapLumaOffset;

		public Vector3 BumpMapMatrix;

		public uint NumShaderTextures;

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
