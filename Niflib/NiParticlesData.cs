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
	public class NiParticlesData : NiGeometryData
	{
		public ushort NumParticles;

		public float ParticleRadius;

		public bool HasRadii;

		public float[] Radii;

		public ushort NumActive;

		public bool HasSizes;

		public float[] Sizes;

		public bool HasRotations;

		public Vector4[] Rotations;

		public NiParticlesData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version <= eNifVersion.VER_4_0_0_2)
			{
				this.NumParticles = reader.ReadUInt16();
			}
			if (this.File.Header.Version <= eNifVersion.VER_10_0_1_0)
			{
				this.ParticleRadius = reader.ReadSingle();
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.HasRadii = reader.ReadBoolean();
				if (this.HasRadii)
				{
					this.Radii = reader.ReadFloatArray((int)this.NumVertices);
				}
			}
			this.NumActive = reader.ReadUInt16();
			this.HasSizes = reader.ReadBoolean();
			if (this.HasSizes)
			{
				this.Sizes = reader.ReadFloatArray((int)this.NumVertices);
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.HasRotations = reader.ReadBoolean();
				if (this.HasRotations)
				{
					this.Rotations = new Vector4[this.NumVertices];
					int num = 0;
					while ((long)num < (long)((ulong)this.NumVertices))
					{
						this.Rotations[num] = reader.ReadVector4();
						num++;
					}
				}
			}
		}
	}
}
