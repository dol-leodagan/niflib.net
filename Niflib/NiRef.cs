using System;
using System.IO;

namespace Niflib
{
	public class NiRef<T> where T : NiObject
	{
		public T Object
		{
			get;
			private set;
		}

		public uint RefId
		{
			get;
			private set;
		}

		public NiRef(uint refId)
		{
			this.RefId = refId;
		}

		public NiRef(BinaryReader reader) : this(reader.ReadUInt32())
		{
		}

		public bool IsValid()
		{
			return this.RefId != 4294967295u;
		}

		public void SetRef(NiFile file)
		{
			if (this.IsValid())
			{
				this.Object = (T)((object)file.ObjectsByRef[this.RefId]);
			}
		}
	}
}
