#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class FloatKey : BaseKey
	{
		public float Time;

		public float Value;

		public float Forward;

		public float Backward;

		public Vector3 TBC;

		public FloatKey(BinaryReader reader, eKeyType type) : base(reader, type)
		{
			this.Time = reader.ReadSingle();
			this.Value = reader.ReadSingle();
			if (type < eKeyType.LINEAR_KEY || type > eKeyType.TBC_KEY)
			{
				throw new Exception("Invalid eKeyType!");
			}
			if (type == eKeyType.QUADRATIC_KEY)
			{
				this.Forward = reader.ReadSingle();
				this.Backward = reader.ReadSingle();
			}
			if (type == eKeyType.TBC_KEY)
			{
				this.TBC = new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
			}
		}
	}
}
