using System;
using System.IO;

namespace Niflib
{
	public class NiNode : NiAVObject
	{
		public NiRef<NiAVObject>[] Children;

		public NiRef<NiDynamicEffect>[] Effects;

		public NiNode(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Children = new NiRef<NiAVObject>[reader.ReadUInt32()];
			for (int i = 0; i < this.Children.Length; i++)
			{
				this.Children[i] = new NiRef<NiAVObject>(reader.ReadUInt32());
			}
			this.Effects = new NiRef<NiDynamicEffect>[reader.ReadUInt32()];
			for (int j = 0; j < this.Effects.Length; j++)
			{
				this.Effects[j] = new NiRef<NiDynamicEffect>(reader.ReadUInt32());
			}
		}
	}
}
