using System;
using System.IO;

namespace Niflib
{
	public class NiDynamicEffect : NiAVObject
	{
		public bool SwitchState;

		public NiRef<NiAVObject>[] AffectedNodes;

		public NiDynamicEffect(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.SwitchState = true;
			if (base.Version >= eNifVersion.VER_10_1_0_106)
			{
				this.SwitchState = reader.ReadBoolean();
			}
			if (base.Version <= eNifVersion.VER_4_0_0_2 || base.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.AffectedNodes = new NiRef<NiAVObject>[reader.ReadUInt32()];
				for (int i = 0; i < this.AffectedNodes.Length; i++)
				{
					this.AffectedNodes[i] = new NiRef<NiAVObject>(reader);
				}
			}
		}
	}
}
