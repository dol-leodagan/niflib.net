using System;
using System.IO;

namespace Niflib
{
	public class NiTextureTransformController : NiFloatInterpController
	{
		public byte Unkown2;

		public eTexType TextureSlot;

		public eTexTransform Operation;

		public NiRef<NiFloatData> Data;

		public NiTextureTransformController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Unkown2 = reader.ReadByte();
			this.TextureSlot = (eTexType)reader.ReadUInt32();
			this.Operation = (eTexTransform)reader.ReadUInt32();
			if (base.Version <= eNifVersion.VER_10_1_0_0)
			{
				this.Data = new NiRef<NiFloatData>(reader);
			}
		}
	}
}
