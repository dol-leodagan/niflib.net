using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiVectorExtraData : NiExtraData
	{
		public Vector3 Data;

		public float UnkownFloat;

		public NiVectorExtraData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = reader.ReadVector3();
			this.UnkownFloat = reader.ReadSingle();
		}
	}
}
