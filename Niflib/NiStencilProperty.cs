using System;
using System.IO;

namespace Niflib
{
	public class NiStencilProperty : NiProperty
	{
		public ushort Flags;

		public bool IsStencilEnabled;

		public eStencilCompareMode StencilFunction;

		public uint StencilRef;

		public uint StencilMask;

		public eStencilAction FailAction;

		public eStencilAction ZFailAction;

		public eStencilAction PassAction;

		public eFaceDrawMode FaceDrawMode;

		public NiStencilProperty(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version <= eNifVersion.VER_10_0_1_2)
			{
				this.Flags = reader.ReadUInt16();
			}
			if (this.File.Header.Version <= eNifVersion.VER_20_0_0_5)
			{
				this.IsStencilEnabled = reader.ReadBoolean();
				this.StencilFunction = (eStencilCompareMode)reader.ReadUInt32();
				this.StencilRef = reader.ReadUInt32();
				this.StencilMask = reader.ReadUInt32();
				this.FailAction = (eStencilAction)reader.ReadUInt32();
				this.ZFailAction = (eStencilAction)reader.ReadUInt32();
				this.PassAction = (eStencilAction)reader.ReadUInt32();
				this.FaceDrawMode = (eFaceDrawMode)reader.ReadUInt32();
			}
			if (this.File.Header.Version >= eNifVersion.VER_20_1_0_3)
			{
				this.Flags = reader.ReadUInt16();
				this.StencilRef = reader.ReadUInt32();
				this.StencilMask = reader.ReadUInt32();
			}
		}
	}
}
