#if OpenTK
using OpenTK;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class VecKey : BaseKey
	{
		public float Time;

		public Vector3 Value;

		public Vector3 Forward;

		public Vector3 Backward;

		public Vector3 TBC;

		public VecKey(BinaryReader reader, eKeyType type) : base(reader, type)
		{
			this.Time = reader.ReadSingle();
			if (type < eKeyType.LINEAR_KEY || type > eKeyType.TBC_KEY)
			{
				throw new Exception("Invalid eKeyType!");
			}
			if (type == eKeyType.LINEAR_KEY)
			{
				this.Value = reader.ReadVector3();
			}
			if (type == eKeyType.QUADRATIC_KEY)
			{
				this.Value = reader.ReadVector3();
				this.Forward = reader.ReadVector3();
				this.Backward = reader.ReadVector3();
			}
			if (type == eKeyType.TBC_KEY)
			{
				this.Value = reader.ReadVector3();
				this.TBC = reader.ReadVector3();
			}
		}
	}
}
