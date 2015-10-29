using System;
using System.IO;

namespace Niflib
{
	public class NiSpotLight : NiPointLight
	{
		public float CutoffAngle;

		public float UnkownFloat;

		public float Exponent;

		public NiSpotLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.CutoffAngle = reader.ReadSingle();
			if (base.Version >= eNifVersion.VER_20_2_0_7)
			{
				this.UnkownFloat = reader.ReadSingle();
			}
			this.Exponent = reader.ReadSingle();
		}
	}
}
