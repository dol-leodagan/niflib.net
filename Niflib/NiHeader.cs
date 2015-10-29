using System;
using System.Data;
using System.IO;

namespace Niflib
{
	public class NiHeader
	{
		public string VersionString;

		public eNifVersion Version = (eNifVersion)4294967295u;

		public uint UserVersion;

		public uint UserVersion2;

		public NiString[] BlockTypes;

		public ushort[] BlockTypeIndex;

		public uint[] BlockSizes;

		public uint NumBlocks;

		public uint UnkownInt;

		public NiHeader(NiFile file, BinaryReader reader)
		{
			int num = 0;
			long position = reader.BaseStream.Position;
			while (reader.ReadByte() != 10)
			{
				num++;
			}
			reader.BaseStream.Position = position;
			this.VersionString = new string(reader.ReadChars(num));
			reader.ReadByte();
			uint version = reader.ReadUInt32();
			this.Version = (eNifVersion)version;
			if (this.Version >= eNifVersion.VER_20_0_0_4)
			{
				throw new Exception("NIF Version not supported yet!");
			}
			if (this.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.UserVersion = reader.ReadUInt32();
			}
			if (this.Version >= eNifVersion.VER_3_3_0_13)
			{
				this.NumBlocks = reader.ReadUInt32();
			}
			if (this.Version >= eNifVersion.VER_10_1_0_0 && (this.UserVersion == 10u || this.UserVersion == 11u))
			{
				this.UserVersion2 = reader.ReadUInt32();
			}
			if (this.Version == eNifVersion.VER_20_0_0_5)
			{
				throw new VersionNotFoundException("Version 20.0.0.5 not supported!");
			}
			if (this.Version == eNifVersion.VER_10_0_1_2)
			{
				throw new Exception("NIF Version not supported yet!");
			}
			if (this.Version >= eNifVersion.VER_10_1_0_0 && (this.UserVersion == 10u || this.UserVersion == 11u))
			{
				throw new Exception("NIF Version not supported yet!");
			}
			if (this.Version >= eNifVersion.VER_10_0_1_0)
			{
				ushort num2 = reader.ReadUInt16();
				this.BlockTypes = new NiString[(int)num2];
				for (int i = 0; i < (int)num2; i++)
				{
					this.BlockTypes[i] = new NiString(file, reader);
				}
				this.BlockTypeIndex = new ushort[this.NumBlocks];
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.NumBlocks))
				{
					this.BlockTypeIndex[num3] = reader.ReadUInt16();
					num3++;
				}
			}
			if (this.Version >= eNifVersion.VER_20_2_0_7)
			{
				throw new Exception("NIF Version not supported yet!");
			}
			if (this.Version >= eNifVersion.VER_20_1_0_3)
			{
				throw new Exception("NIF Version not supported yet!");
			}
			if (this.Version >= eNifVersion.VER_10_0_1_0)
			{
				this.UnkownInt = reader.ReadUInt32();
			}
		}
	}
}
