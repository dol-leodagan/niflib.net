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
	public class SkinData
	{
		public SkinTransform Transform;

		public Vector3 BoundingSphereOffset;

		public float BoundingSphereRadius;

		public ushort[] Unkown13Shorts;

		public ushort NumVertices;

		public SkinWeight[] VertexWeights;

		public SkinData(NiFile file, BinaryReader reader, bool hasVertexWeights)
		{
			this.Transform = new SkinTransform(file, reader);
			this.BoundingSphereOffset = reader.ReadVector3();
			this.BoundingSphereRadius = reader.ReadSingle();
			if (file.Version == eNifVersion.VER_20_3_0_9 && file.Header.UserVersion == 131072u)
			{
				this.Unkown13Shorts = new ushort[13];
				for (int i = 0; i < 13; i++)
				{
					this.Unkown13Shorts[i] = reader.ReadUInt16();
				}
			}
			this.NumVertices = reader.ReadUInt16();
			if (hasVertexWeights)
			{
				this.VertexWeights = new SkinWeight[(int)this.NumVertices];
				for (int j = 0; j < (int)this.NumVertices; j++)
				{
					this.VertexWeights[j] = new SkinWeight(file, reader);
				}
			}
		}
	}
}
