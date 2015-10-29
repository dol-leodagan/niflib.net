using System;
using System.IO;

namespace Niflib
{
	public class NiMorphData : NiObject
	{
		public uint NumMorphs;

		public uint NumVertices;

		public byte RelativeTargets;

		public Morph[] Morphs;

		public NiMorphData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NumMorphs = reader.ReadUInt32();
			this.NumVertices = reader.ReadUInt32();
			this.RelativeTargets = reader.ReadByte();
			this.Morphs = new Morph[this.NumMorphs];
			int num = 0;
			while ((long)num < (long)((ulong)this.NumMorphs))
			{
				this.Morphs[num] = new Morph(file, reader, this.NumVertices);
				num++;
			}
		}
	}
}
