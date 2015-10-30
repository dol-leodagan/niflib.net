#if OpenTK
using OpenTK.Graphics;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Color4 = Microsoft.Xna.Framework.Color;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class Color4Key : BaseKey
	{
		public float Time;

		public Color4 Value;

		public Color4 Forward;

		public Color4 Backward;

		public Color4Key(BinaryReader reader, eKeyType type) : base(reader, type)
		{
			this.Time = reader.ReadSingle();
			if (type < eKeyType.LINEAR_KEY || type > eKeyType.TBC_KEY)
			{
				throw new Exception("Invalid eKeyType!");
			}
			this.Value = reader.ReadColor4();
			if (type == eKeyType.QUADRATIC_KEY)
			{
				this.Forward = reader.ReadColor4();
				this.Backward = reader.ReadColor4();
			}
		}
	}
}
