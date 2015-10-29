using System;
using System.IO;

namespace Niflib
{
	public class NiSkinData : NiObject
	{
		public SkinTransform Transform;

		public NiRef<NiSkinPartition> Partition;

		public bool HasVertexWeights;

		public SkinData[] BoneList;

		public NiSkinData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.HasVertexWeights = true;
			this.Transform = new SkinTransform(file, reader);
			uint num = reader.ReadUInt32();
			if (base.Version >= eNifVersion.VER_4_0_0_2 && base.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Partition = new NiRef<NiSkinPartition>(reader);
			}
			if (base.Version >= eNifVersion.VER_4_2_1_0)
			{
				this.HasVertexWeights = reader.ReadBoolean();
			}
			if (this.HasVertexWeights)
			{
				this.BoneList = new SkinData[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.BoneList[num2] = new SkinData(file, reader, this.HasVertexWeights);
					num2++;
				}
			}
		}
	}
}
