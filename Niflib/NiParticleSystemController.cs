using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiParticleSystemController : NiTimeController
	{
		public uint OldSpeed;

		public float Speed;

		public float RandomSpeed;

		public float VerticalDirection;

		public float VerticalAngle;

		public float HorizontalDirection;

		public float HorizontalAngle;

		public Vector3 UnkownNormal;

		public Color4 UnkownColor;

		public float Size;

		public float EmitStartTime;

		public float EmitStopTime;

		public byte UnkownByte;

		public uint OldEmitRate;

		public float EmitRate;

		public float Lifetime;

		public float LifetimeRandom;

		public ushort EmitFlags;

		public Vector3 StartRandom;

		public NiRef<NiObject> Emitter;

		public Vector3 ParticleVelocity;

		public Vector3 ParticleUnkownVector;

		public float ParticleLifeTime;

		public NiRef<NiObject> ParticleLink;

		public uint ParticleTimestamp;

		public ushort ParticleUnkownShort;

		public ushort ParticleVertexId;

		public ushort NumParticles;

		public ushort NumValid;

		public Particle[] Particles;

		public NiRef<NiObject> UnkownRef;

		public NiRef<NiParticleModifier> ParticleExtra;

		public NiRef<NiObject> UnkownRef2;

		public byte Trailer;

		public NiRef<NiColorData> ColorData;

		public float UnkownFloat1;

		public float[] UnkownFloats2;

		public NiParticleSystemController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_3_1)
			{
				this.OldSpeed = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.Speed = reader.ReadSingle();
			}
			this.RandomSpeed = reader.ReadSingle();
			this.VerticalDirection = reader.ReadSingle();
			this.VerticalAngle = reader.ReadSingle();
			this.HorizontalDirection = reader.ReadSingle();
			this.HorizontalAngle = reader.ReadSingle();
			this.UnkownNormal = reader.ReadVector3();
			this.UnkownColor = reader.ReadColor4();
			this.Size = reader.ReadSingle();
			this.EmitStartTime = reader.ReadSingle();
			this.EmitStopTime = reader.ReadSingle();
			if (base.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.UnkownByte = reader.ReadByte();
			}
			if (base.Version <= eNifVersion.VER_3_1)
			{
				this.OldEmitRate = reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.EmitRate = reader.ReadSingle();
			}
			this.Lifetime = reader.ReadSingle();
			this.LifetimeRandom = reader.ReadSingle();
			if (base.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.EmitFlags = reader.ReadUInt16();
			}
			this.StartRandom = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			this.Emitter = new NiRef<NiObject>(reader);
			if (base.Version >= eNifVersion.VER_4_0_0_2)
			{
				reader.ReadUInt16();
				reader.ReadSingle();
				reader.ReadUInt32();
				reader.ReadUInt32();
				reader.ReadUInt16();
			}
			if (base.Version <= eNifVersion.VER_3_1)
			{
				this.ParticleVelocity = reader.ReadVector3();
				this.ParticleUnkownVector = reader.ReadVector3();
				this.ParticleLifeTime = reader.ReadSingle();
				this.ParticleLink = new NiRef<NiObject>(reader);
				this.ParticleTimestamp = reader.ReadUInt32();
				this.ParticleUnkownShort = reader.ReadUInt16();
				this.ParticleVertexId = reader.ReadUInt16();
			}
			if (base.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.NumParticles = reader.ReadUInt16();
				this.NumValid = reader.ReadUInt16();
				this.Particles = new Particle[(int)this.NumParticles];
				for (int i = 0; i < (int)this.NumParticles; i++)
				{
					this.Particles[i] = new Particle(file, reader);
				}
				this.UnkownRef = new NiRef<NiObject>(reader);
			}
			this.ParticleExtra = new NiRef<NiParticleModifier>(reader);
			this.UnkownRef2 = new NiRef<NiObject>(reader);
			if (base.Version >= eNifVersion.VER_4_0_0_2)
			{
				this.Trailer = reader.ReadByte();
			}
			if (base.Version <= eNifVersion.VER_3_1)
			{
				this.ColorData = new NiRef<NiColorData>(reader);
				this.UnkownFloat1 = reader.ReadSingle();
				this.UnkownFloats2 = reader.ReadFloatArray((int)this.ParticleUnkownShort);
			}
		}
	}
}
