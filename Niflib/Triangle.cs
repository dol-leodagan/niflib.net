using System;
using System.IO;

namespace Niflib
{
	public class Triangle
	{
		public ushort X;

		public ushort Y;

		public ushort Z;

		public Triangle(ushort x, ushort y, ushort z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Triangle(BinaryReader reader)
		{
			this.X = reader.ReadUInt16();
			this.Y = reader.ReadUInt16();
			this.Z = reader.ReadUInt16();
		}
	}
}
