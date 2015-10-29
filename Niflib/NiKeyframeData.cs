using System;
using System.IO;

namespace Niflib
{
	public class NiKeyframeData : NiObject
	{
		public eKeyType KeyType;

		public QuatKey[] QuaternionKeys;

		public float UnkownFloat;

		public KeyGroup<FloatKey>[] Rotations;

		public KeyGroup<VecKey> Translations;

		public KeyGroup<FloatKey> Scales;

		public NiKeyframeData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			uint num = reader.ReadUInt32();
			if (num != 0u)
			{
				this.KeyType = (eKeyType)reader.ReadUInt32();
			}
			if (this.KeyType != eKeyType.XYZ_ROTATION_KEY)
			{
				this.QuaternionKeys = new QuatKey[num];
				int num2 = 0;
				while ((long)num2 < (long)((ulong)num))
				{
					this.QuaternionKeys[num2] = new QuatKey(reader, this.KeyType);
					num2++;
				}
			}
			if (base.Version <= eNifVersion.VER_10_1_0_0 && this.KeyType == eKeyType.XYZ_ROTATION_KEY)
			{
				this.UnkownFloat = reader.ReadSingle();
			}
			if (this.KeyType == eKeyType.XYZ_ROTATION_KEY)
			{
				this.Rotations = new KeyGroup<FloatKey>[3];
				for (int i = 0; i < 3; i++)
				{
					this.Rotations[i] = new KeyGroup<FloatKey>(reader);
				}
			}
			this.Translations = new KeyGroup<VecKey>(reader);
			this.Scales = new KeyGroup<FloatKey>(reader);
		}
	}
}
