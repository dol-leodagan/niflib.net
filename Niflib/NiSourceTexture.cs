using System;
using System.IO;

namespace Niflib
{
	public class NiSourceTexture : NiTexture
	{
		public bool UseExternal;

		public NiString FileName;

		public ePixelLayout PixelLayout;

		public eMipMapFormat UseMipmaps;

		public eAlphaFormat AlphaFormat;

		public bool IsStatic;

		public bool DirectRender;

		public bool PersistentRenderData;

		public NiRef<ATextureRenderData> InternalTexture;

		public NiSourceTexture(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.IsStatic = true;
			this.UseExternal = reader.ReadBoolean();
			if (this.UseExternal)
			{
				this.FileName = new NiString(file, reader);
				if (base.Version >= eNifVersion.VER_10_1_0_0)
				{
					reader.ReadUInt32();
				}
			}
			if (!this.UseExternal)
			{
				if (base.Version <= eNifVersion.VER_10_0_1_0)
				{
					reader.ReadByte();
				}
				if (base.Version >= eNifVersion.VER_10_1_0_0)
				{
					this.FileName = new NiString(file, reader);
				}
				this.InternalTexture = new NiRef<ATextureRenderData>(reader);
			}
			this.PixelLayout = (ePixelLayout)reader.ReadUInt32();
			this.UseMipmaps = (eMipMapFormat)reader.ReadUInt32();
			this.AlphaFormat = (eAlphaFormat)reader.ReadUInt32();
			this.IsStatic = reader.ReadBoolean();
			if (base.Version >= eNifVersion.VER_10_1_0_106)
			{
				this.DirectRender = reader.ReadBoolean();
			}
			if (base.Version >= eNifVersion.VER_20_2_0_7)
			{
				this.PersistentRenderData = reader.ReadBoolean();
			}
		}
	}
}
