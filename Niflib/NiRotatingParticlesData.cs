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
	public class NiRotatingParticlesData : NiParticlesData
	{
		public bool HasRotations2;

		public Vector4[] Rotations2;

		public NiRotatingParticlesData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.HasRotations2 = reader.ReadBoolean();
				this.Rotations2 = new Vector4[this.NumVertices];
				int num = 0;
				while ((long)num < (long)((ulong)this.NumVertices))
				{
					this.Rotations2[num] = reader.ReadVector4();
					num++;
				}
			}
		}
	}
}
