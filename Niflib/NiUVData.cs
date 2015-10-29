using System;
using System.IO;

namespace Niflib
{
	public class NiUVData : NiObject
	{
		public KeyGroup<FloatKey> UTranslation;

		public KeyGroup<FloatKey> VTranslation;

		public KeyGroup<FloatKey> UScalingAndTiling;

		public KeyGroup<FloatKey> VScalingAndTiling;

		public NiUVData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.UTranslation = new KeyGroup<FloatKey>(reader);
			this.VTranslation = new KeyGroup<FloatKey>(reader);
			this.UScalingAndTiling = new KeyGroup<FloatKey>(reader);
			this.VScalingAndTiling = new KeyGroup<FloatKey>(reader);
		}
	}
}
