using System;
using System.IO;

namespace Niflib
{
	public class NiPointLight : NiLight
	{
		public float ConstantAttenuation;

		public float LinearAttenuation;

		public float QuadraticAttenuation;

		public NiPointLight(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.ConstantAttenuation = reader.ReadSingle();
			this.LinearAttenuation = reader.ReadSingle();
			this.QuadraticAttenuation = reader.ReadSingle();
		}
	}
}
