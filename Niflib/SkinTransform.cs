#if OpenTK
using OpenTK;
using Matrix = OpenTK.Matrix4;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class SkinTransform
	{
		public Matrix Rotation;

		public Vector3 Translation;

		public float Scale;

		public SkinTransform(NiFile file, BinaryReader reader)
		{
			this.Rotation = reader.ReadMatrix33();
			this.Translation = reader.ReadVector3();
			this.Scale = reader.ReadSingle();
		}
	}
}
