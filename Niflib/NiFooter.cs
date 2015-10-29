using System;
using System.IO;

namespace Niflib
{
	public class NiFooter
	{
		public NiRef<NiObject>[] RootNodes;

		public NiFooter(NiFile file, BinaryReader reader)
		{
			if (file.Header.Version >= eNifVersion.VER_3_3_0_13)
			{
				uint num = reader.ReadUInt32();
				this.RootNodes = new NiRef<NiObject>[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.RootNodes[num2] = new NiRef<NiObject>(reader.ReadUInt32());
					num2++;
				}
			}
		}
	}
}
