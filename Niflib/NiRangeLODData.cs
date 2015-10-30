#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiRangeLODData : NiLODData
	{
		public Vector3 LODCenter;

		public LODRange[] LODLevels;

		public NiRangeLODData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.LODCenter = reader.ReadVector3();
			uint num = reader.ReadUInt32();
			this.LODLevels = new LODRange[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.LODLevels[num2] = new LODRange(file, reader);
				num2++;
			}
		}
	}
}
