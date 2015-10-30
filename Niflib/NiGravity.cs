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
	public class NiGravity : NiParticleModifier
	{
		public float UnkownFloat1;

		public float Force;

		public uint Type;

		public Vector3 Position;

		public Vector3 Direction;

		public NiGravity(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.UnkownFloat1 = reader.ReadSingle();
			}
			this.Force = reader.ReadSingle();
			this.Type = reader.ReadUInt32();
			this.Position = reader.ReadVector3();
			this.Direction = reader.ReadVector3();
		}
	}
}
