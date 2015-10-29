using System;
using System.IO;

namespace Niflib
{
	public class NiGeometry : NiAVObject
	{
		public NiRef<NiGeometryData> Data;

		public NiRef<NiSkinInstance> SkinInstance;

		public NiString[] MaterialNames;

		public int[] MaterialExtraData;

		public int ActiveMaterial;

		public bool HasShader;

		public string ShaderName;

		public uint UnkownInteger;

		public NiGeometry(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.Data = new NiRef<NiGeometryData>(reader);
			if (base.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.SkinInstance = new NiRef<NiSkinInstance>(reader);
			}
			if (base.Version >= eNifVersion.VER_20_2_0_7)
			{
				this.MaterialNames = new NiString[reader.ReadUInt32()];
				for (int i = 0; i < this.MaterialNames.Length; i++)
				{
					this.MaterialNames[i] = new NiString(file, reader);
				}
				this.MaterialExtraData = new int[this.MaterialNames.Length];
				for (int j = 0; j < this.MaterialNames.Length; j++)
				{
					this.MaterialExtraData[j] = reader.ReadInt32();
				}
				this.ActiveMaterial = reader.ReadInt32();
			}
			if (base.Version >= eNifVersion.VER_10_0_1_0 && base.Version <= eNifVersion.VER_20_1_0_3)
			{
				this.HasShader = reader.ReadBoolean();
				if (this.HasShader)
				{
					this.ShaderName = new string(reader.ReadChars(reader.ReadInt32()));
					this.UnkownInteger = reader.ReadUInt32();
				}
			}
			if (base.Version == eNifVersion.VER_10_4_0_1)
			{
				reader.ReadUInt32();
			}
			if (base.Version >= eNifVersion.VER_20_2_0_7)
			{
				throw new Exception("unspported data");
			}
		}
	}
}
