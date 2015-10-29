using System;
using System.IO;

namespace Niflib
{
	public class NiBillboardNode : NiNode
	{
		public eBillboardMode BillboardMode;

		public NiBillboardNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.BillboardMode = (eBillboardMode)reader.ReadUInt16();
			}
		}
	}
}
