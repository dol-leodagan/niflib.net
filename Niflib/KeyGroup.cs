using System;
using System.IO;

namespace Niflib
{
	public class KeyGroup<T> where T : BaseKey
	{
		public eKeyType Interpolation;

		public T[] Values;

		public KeyGroup(BinaryReader reader)
		{
			this.Values = new T[reader.ReadUInt32()];
			if (this.Values.Length != 0)
			{
				this.Interpolation = (eKeyType)reader.ReadUInt32();
			}
			for (int i = 0; i < this.Values.Length; i++)
			{
				this.Values[i] = (T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					reader,
					this.Interpolation
				}));
			}
		}
	}
}
