using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public class NiLODNode : NiSwitchNode
	{
		public Vector3 LODCenter;

		public LODRange[] LODLevels;

		public NiRef<NiLODData> LODLevelData;

		public NiLODNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version >= eNifVersion.VER_4_0_0_2 && base.Version <= eNifVersion.VER_10_0_1_0)
			{
				this.LODCenter = reader.ReadVector3();
			}
			if (base.Version <= eNifVersion.VER_10_0_1_0)
			{
				uint num = reader.ReadUInt32();
				this.LODLevels = new LODRange[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.LODLevels[num2] = new LODRange(file, reader);
					num2++;
				}
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.LODLevelData = new NiRef<NiLODData>(reader);
			}
		}
	}
}
