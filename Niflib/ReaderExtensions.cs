using SharpDX;
using System;
using System.IO;

namespace Niflib
{
	public static class ReaderExtensions
	{
		public static float[] ReadFloatArray(this BinaryReader reader, int length)
		{
			float[] array = new float[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = reader.ReadSingle();
			}
			return array;
		}

		public static uint[] ReadUInt32Array(this BinaryReader reader, int length)
		{
			uint[] array = new uint[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = reader.ReadUInt32();
			}
			return array;
		}

		public static ushort[] ReadUInt16Array(this BinaryReader reader, int length)
		{
			ushort[] array = new ushort[length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = reader.ReadUInt16();
			}
			return array;
		}

		public static Vector2 ReadVector2(this BinaryReader reader)
		{
			return new Vector2(reader.ReadSingle(), reader.ReadSingle());
		}

		public static Vector3 ReadVector3(this BinaryReader reader)
		{
			return new Vector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static Vector4 ReadVector4(this BinaryReader reader)
		{
			return new Vector4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static Color3 ReadColor3(this BinaryReader reader)
		{
			return new Color3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static Color4 ReadColor4(this BinaryReader reader)
		{
			return new Color4(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
		}

		public static Color4 ReadColor4Byte(this BinaryReader reader)
		{
			return new Color4((float)reader.ReadByte() / 255f, (float)reader.ReadByte() / 255f, (float)reader.ReadByte() / 255f, (float)reader.ReadByte() / 255f);
		}

		public static Matrix ReadMatrix33(this BinaryReader reader)
		{
			Matrix identity = Matrix.Identity;
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					identity[j, i] = reader.ReadSingle();
				}
			}
			return identity;
		}
	}
}
