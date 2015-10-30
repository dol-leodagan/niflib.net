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
	public class ByteKey
	{
		public float Time;

		public byte Value;

		public Vector3 TBC;

		public ByteKey(BinaryReader reader, eKeyType type)
		{
			this.Time = reader.ReadSingle();
			if (type != eKeyType.LINEAR_KEY)
			{
				throw new Exception("Invalid eKeyType");
			}
			this.Value = reader.ReadByte();
			if (type == eKeyType.TBC_KEY)
			{
				this.TBC = reader.ReadVector3();
			}
		}
	}
}
