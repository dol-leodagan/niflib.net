using System;
using System.IO;

namespace Niflib
{
	public class NiPlanarCollider : NiParticleModifier
	{
		public ushort UnkownShort1;

		public float UnkownFloat1;

		public float UnkownFloat2;

		public ushort UnkownShort2;

		public float UnkownFloat3;

		public float UnkownFloat4;

		public float UnkownFloat5;

		public float UnkownFloat6;

		public float UnkownFloat7;

		public float UnkownFloat8;

		public float UnkownFloat9;

		public float UnkownFloat10;

		public float UnkownFloat11;

		public float UnkownFloat12;

		public float UnkownFloat13;

		public float UnkownFloat14;

		public float UnkownFloat15;

		public float UnkownFloat16;

		public NiPlanarCollider(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.UnkownShort1 = reader.ReadUInt16();
			}
			this.UnkownFloat1 = reader.ReadSingle();
			this.UnkownFloat2 = reader.ReadSingle();
			if (base.Version == eNifVersion.VER_4_2_2_0)
			{
				this.UnkownShort2 = reader.ReadUInt16();
			}
			this.UnkownFloat3 = reader.ReadSingle();
			this.UnkownFloat4 = reader.ReadSingle();
			this.UnkownFloat5 = reader.ReadSingle();
			this.UnkownFloat6 = reader.ReadSingle();
			this.UnkownFloat7 = reader.ReadSingle();
			this.UnkownFloat8 = reader.ReadSingle();
			this.UnkownFloat9 = reader.ReadSingle();
			this.UnkownFloat10 = reader.ReadSingle();
			this.UnkownFloat11 = reader.ReadSingle();
			this.UnkownFloat12 = reader.ReadSingle();
			this.UnkownFloat13 = reader.ReadSingle();
			this.UnkownFloat14 = reader.ReadSingle();
			this.UnkownFloat15 = reader.ReadSingle();
			this.UnkownFloat16 = reader.ReadSingle();
		}
	}
}
