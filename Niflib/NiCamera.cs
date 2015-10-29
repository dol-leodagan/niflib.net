using System;
using System.IO;

namespace Niflib
{
	public class NiCamera : NiAVObject
	{
		public ushort Unkown1;

		public float FrustrumLeft;

		public float FrustrumRight;

		public float FrustrumTop;

		public float FrustrumBottom;

		public float FrustrumNear;

		public float FrustrumFar;

		public bool UseOrthographicsProjection;

		public float ViewportLeft;

		public float ViewportRight;

		public float ViewportTop;

		public float ViewportBottom;

		public float LODAdjust;

		public NiRef<NiObject> UnkownLink;

		public uint Unkown2;

		public uint Unkown3;

		public uint Unkown4;

		public NiCamera(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.Unkown1 = reader.ReadUInt16();
			}
			this.FrustrumLeft = reader.ReadSingle();
			this.FrustrumRight = reader.ReadSingle();
			this.FrustrumTop = reader.ReadSingle();
			this.FrustrumBottom = reader.ReadSingle();
			this.FrustrumNear = reader.ReadSingle();
			this.FrustrumFar = reader.ReadSingle();
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.UseOrthographicsProjection = reader.ReadBoolean();
			}
			this.ViewportLeft = reader.ReadSingle();
			this.ViewportRight = reader.ReadSingle();
			this.ViewportTop = reader.ReadSingle();
			this.ViewportBottom = reader.ReadSingle();
			this.LODAdjust = reader.ReadSingle();
			this.UnkownLink = new NiRef<NiObject>(reader);
			this.Unkown2 = reader.ReadUInt32();
			if (this.File.Header.Version >= eNifVersion.VER_4_2_1_0)
			{
				this.Unkown3 = reader.ReadUInt32();
			}
			if (this.File.Header.Version <= eNifVersion.VER_3_1)
			{
				this.Unkown4 = reader.ReadUInt32();
			}
		}
	}
}
