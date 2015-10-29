using System;
using System.IO;

namespace Niflib
{
	public class StringKey
	{
		public float Time;

		public NiString Value;

		public StringKey(BinaryReader reader, eKeyType type)
		{
			this.Time = reader.ReadSingle();
			if (type != eKeyType.LINEAR_KEY)
			{
				throw new Exception("Invalid eKeyType");
			}
			this.Value = new NiString(null, reader);
		}
	}
}
