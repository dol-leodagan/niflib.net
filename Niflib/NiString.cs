using System;
using System.IO;

namespace Niflib
{
	public class NiString
	{
		public string Value;

		public NiString(NiFile file, BinaryReader reader)
		{
			this.Value = new string(reader.ReadChars((int)reader.ReadUInt32()));
		}

		public override string ToString()
		{
			return this.Value;
		}
	}
}
