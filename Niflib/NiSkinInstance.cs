using System;
using System.IO;

namespace Niflib
{
	public class NiSkinInstance : NiObject
	{
		public NiRef<NiSkinData> Data;

		public NiRef<NiSkinPartition> Partition;

		public NiRef<NiNode> SkeletonRoot;

		public NiRef<NiNode>[] Bones;

		public NiSkinInstance(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new NiRef<NiSkinData>(reader);
			if (base.Version >= eNifVersion.VER_10_2_0_0)
			{
				this.Partition = new NiRef<NiSkinPartition>(reader);
			}
			this.SkeletonRoot = new NiRef<NiNode>(reader);
			uint num = reader.ReadUInt32();
			this.Bones = new NiRef<NiNode>[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.Bones[num2] = new NiRef<NiNode>(reader);
				num2++;
			}
		}
	}
}
