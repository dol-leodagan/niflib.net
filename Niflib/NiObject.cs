using System;
using System.IO;

namespace Niflib
{
	public class NiObject
	{
		public NiFile File;

		public eNifVersion Version
		{
			get
			{
				return this.File.Version;
			}
		}

		public NiObject(NiFile file, BinaryReader reader)
		{
			this.File = file;
		}
	}
}
