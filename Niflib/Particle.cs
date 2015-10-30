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
	public class Particle
	{
		public Vector3 Velocity;

		public Vector3 UnkownVector;

		public float Lifetime;

		public float Lifespan;

		public float Timestamp;

		public ushort UnkownShort;

		public ushort VertexID;

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
