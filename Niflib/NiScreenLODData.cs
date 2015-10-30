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
	public class NiScreenLODData : NiLODData
	{
		public Vector3 BoundCenter;

		public float BoundRadius;

		public Vector3 WorldCenter;

		public float WorldRadius;

		public float[] ProportionLevels;

		public NiScreenLODData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.BoundCenter = reader.ReadVector3();
			this.BoundRadius = reader.ReadSingle();
			this.WorldCenter = reader.ReadVector3();
			this.WorldRadius = reader.ReadSingle();
			uint num = reader.ReadUInt32();
			this.ProportionLevels = new float[num];
			int num2 = 0;
			while ((long)num2 < (long)((ulong)num))
			{
				this.ProportionLevels[num2] = reader.ReadSingle();
				num2++;
			}
		}
	}
}
