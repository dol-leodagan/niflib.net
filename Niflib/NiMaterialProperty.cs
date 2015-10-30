#if OpenTK
using Color3 = OpenTK.Graphics.Color4;
#elif SharpDX
using SharpDX;
#elif MonoGame
using Microsoft.Xna.Framework;
using Color3 = Microsoft.Xna.Framework.Color;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiMaterialProperty : NiProperty
	{
		public ushort Flags;

		public Color3 AmbientColor;

		public Color3 DiffuseColor;

		public Color3 SpecularColor;

		public Color3 EmissiveColor;

		public float Glossiness;

		public float Alpha;

		public NiMaterialProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (base.Version <= eNifVersion.VER_10_0_1_2)
			{
				this.Flags = reader.ReadUInt16();
			}
			this.AmbientColor = reader.ReadColor3();
			this.DiffuseColor = reader.ReadColor3();
			this.SpecularColor = reader.ReadColor3();
			this.EmissiveColor = reader.ReadColor3();
			this.Glossiness = reader.ReadSingle();
			this.Alpha = reader.ReadSingle();
		}
	}
}
