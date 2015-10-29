using System;
using System.IO;

namespace Niflib
{
	public class NiCollisionObject : NiObject
	{
		public NiRef<NiAVObject> Target;

		public NiCollisionObject(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Target = new NiRef<NiAVObject>(reader);
		}
	}
}
