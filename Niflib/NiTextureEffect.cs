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

namespace Niflib
{
	public class NiTextureEffect : NiDynamicEffect
	{
		public Matrix ModelProjectionMatrix;

		public Vector3 ModelProjectionTransform;

		public eTexFilterMode TextureFiltering;

		public eTexClampMode TextureClamping;

		public ushort Unknown1;

		public eEffectType EffectType;

		public eCoordGenType CoordGenType;

		public NiRef<NiSourceTexture> SourceTexture;

		public bool ClippingPlane;

		public Vector3 unknownVector;

		public float Unknown2;

		public short PS2L;

		public short PS2K;

		public ushort Unknown3;

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
			this.ClippingPlane = reader.ReadBoolean();
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
