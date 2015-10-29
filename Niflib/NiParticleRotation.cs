using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiParticleRotation : NiParticleModifier
	{
		public bool RandomInitalAxis;

		public Vector3 InitialAxis;

		public float Speed;

		public NiParticleRotation(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.RandomInitalAxis = reader.ReadBoolean();
			this.InitialAxis = reader.ReadVector3();
			this.Speed = reader.ReadSingle();
		}
	}
}
