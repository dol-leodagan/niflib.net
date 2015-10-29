using System;
using System.IO;

namespace Niflib
{
	public class SkinWeight
	{
		public ushort Index;

		public float Weight;

		public SkinWeight(NiFile file, BinaryReader reader)
		{
			this.Index = reader.ReadUInt16();
			this.Weight = reader.ReadSingle();
		}
	}
}
