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
	public class Morph
	{
		public NiString FrameName;

		public uint NumKeys;

		public uint Interpolation;

		public KeyGroup<FloatKey> Keys;

		public uint UnkownInt;

		public Vector3[] Vectors;

		public Morph(NiFile file, BinaryReader reader, uint numVertices)
		{
			if (file.Version >= eNifVersion.VER_10_1_0_106)
			{
				this.FrameName = new NiString(file, reader);
			}
			if (file.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Keys = new KeyGroup<FloatKey>(reader);
			}
			if (file.Version >= eNifVersion.VER_10_1_0_106 && file.Version <= eNifVersion.VER_10_2_0_0)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
			if (file.Version >= eNifVersion.VER_20_0_0_4 && file.Version <= eNifVersion.VER_20_1_0_3)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
			this.Vectors = new Vector3[numVertices];
			int num = 0;
			while ((long)num < (long)((ulong)numVertices))
			{
				this.Vectors[num] = reader.ReadVector3();
				num++;
			}
		}
	}
}
