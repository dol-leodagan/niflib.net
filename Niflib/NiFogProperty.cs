#if OpenTK
using OpenTK.Graphics;
using Color3 = OpenTK.Graphics.Color4;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiFogProperty : NiProperty
	{
		public ushort Flags;

		public float Depth;

		public Color3 Color;

		public NiFogProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Flags = reader.ReadUInt16();
			this.Depth = reader.ReadSingle();
			this.Color = reader.ReadColor3();
		}
	}
}
