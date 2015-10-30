#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiParticleBomb : NiParticleModifier
	{
		public float Decay;

		public float Duration;

		public float DeltaV;

		public float Start;

		public eDecayType DecayType;

		public eSymmetryType SymmetryType;

		public Vector3 Position;

		public Vector3 Direction;

		public NiParticleBomb(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Decay = reader.ReadSingle();
			this.Duration = reader.ReadSingle();
			this.DeltaV = reader.ReadSingle();
			this.Start = reader.ReadSingle();
			this.DecayType = (eDecayType)reader.ReadUInt32();
			if (base.Version >= eNifVersion.VER_4_1_0_12)
			{
				this.SymmetryType = (eSymmetryType)reader.ReadUInt32();
			}
			this.Position = reader.ReadVector3();
			this.Direction = reader.ReadVector3();
		}
	}
}
