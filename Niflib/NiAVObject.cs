#if OpenTK
using OpenTK;
using Matrix = OpenTK.Matrix3;
#elif SharpDX
using SharpDX;
#endif
using System;
using System.IO;

namespace Niflib
{
	public class NiAVObject : NiObjectNET
	{
		public ushort Flags;

		public ushort UnkownShort1;

		public Vector3 Translation;

		public Matrix Rotation;

		public float Scale;

		public Vector3 Velocity;

		public NiRef<NiProperty>[] Properties;

		public uint[] UnkownInts1;

		public byte UnkownByte;

		public bool HasBoundingBox;

		public NiRef<NiCollisionObject> CollisionObject;

		public NiNode Parent;

		public NiAVObject(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_3_0)
			{
				this.Flags = reader.ReadUInt16();
			}
			if (this.File.Header.Version >= eNifVersion.VER_20_2_0_7 && this.File.Header.UserVersion == 11u && this.File.Header.UserVersion2 > 26u)
			{
				this.UnkownShort1 = reader.ReadUInt16();
			}
			this.Translation = reader.ReadVector3();
			this.Rotation = reader.ReadMatrix33();
			this.Scale = reader.ReadSingle();
			if (this.File.Header.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.Velocity = reader.ReadVector3();
			}
			if (this.File.Header.Version <= eNifVersion.VER_20_2_0_7 || this.File.Header.UserVersion <= 11u)
			{
				uint num = reader.ReadUInt32();
				this.Properties = new NiRef<NiProperty>[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.Properties[num2] = new NiRef<NiProperty>(reader.ReadUInt32());
					num2++;
				}
			}
			if (this.File.Header.Version <= eNifVersion.VER_2_3)
			{
				this.UnkownInts1 = new uint[4];
				for (int i = 0; i < 4; i++)
				{
					this.UnkownInts1[i] = reader.ReadUInt32();
				}
				this.UnkownByte = reader.ReadByte();
			}
			if (this.File.Header.Version >= eNifVersion.VER_3_0 && this.File.Header.Version <= eNifVersion.VER_4_2_2_0)
			{
				this.HasBoundingBox = reader.ReadBoolean();
				if (this.HasBoundingBox)
				{
					throw new Exception("Cannot read BoundingBoxes yet");
				}
			}
			if (this.File.Header.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.CollisionObject = new NiRef<NiCollisionObject>(reader.ReadUInt32());
			}
		}
	}
}
