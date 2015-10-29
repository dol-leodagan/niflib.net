using System;
using System.IO;

namespace Niflib
{
	public class NiVisData : NiObject
	{
		public ByteKey[] Keys;

		public NiVisData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			uint num = reader.ReadUInt32();
			this.Keys = new ByteKey[num];
			for (int i = 0; i < this.Keys.Length; i++)
			{
				this.Keys[i] = new ByteKey(reader, eKeyType.LINEAR_KEY);
			}
		}
	}
}
