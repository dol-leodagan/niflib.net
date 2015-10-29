using System;
using System.IO;

namespace Niflib
{
	public class NiSphericalCollider : NiParticleModifier
	{
		public float UnkownFloat1;

		public ushort UnkownShort1;

		public float UnkownFloat2;

		public ushort UnkownShort2;

		public float UnkownFloat3;

		public float UnkownFloat4;

		public float UnkownFloat5;

		public NiSphericalCollider(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UnkownFloat1 = reader.ReadSingle();
			this.UnkownShort1 = reader.ReadUInt16();
			this.UnkownFloat2 = reader.ReadSingle();
			if (base.Version <= eNifVersion.VER_4_2_0_2)
			{
				this.UnkownShort2 = reader.ReadUInt16();
			}
			else
			{
				this.UnkownFloat3 = reader.ReadSingle();
			}
			this.UnkownFloat4 = reader.ReadSingle();
			this.UnkownFloat5 = reader.ReadSingle();
		}
	}
}
