#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class QuatKey
	{
		public float Time;

		public Vector4 Value;

		public Vector3 TBC;

		public QuatKey(BinaryReader reader, eKeyType type)
		{
			this.Time = reader.ReadSingle();
			if (type < eKeyType.LINEAR_KEY || type > eKeyType.TBC_KEY)
			{
				throw new Exception("Invalid eKeyType");
			}
			this.Value = reader.ReadVector4();
			if (type == eKeyType.TBC_KEY)
			{
				this.TBC = reader.ReadVector3();
			}
		}
	}
}
