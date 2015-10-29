using System;
using System.IO;

namespace Niflib
{
	public class NiTriBasedGeomData : NiGeometryData
	{
		public ushort NumTriangles;

		public NiTriBasedGeomData(NiFile file, BinaryReader reader) : base(file, reader)
		{
			this.NumTriangles = reader.ReadUInt16();
		}
	}
}
