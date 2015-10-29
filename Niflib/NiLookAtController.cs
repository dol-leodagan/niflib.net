using System;
using System.IO;

namespace Niflib
{
	public class NiLookAtController : NiTimeController
	{
		public ushort Unknown1;

		public NiRef<NiNode> CameraTargetNode;

		public NiLookAtController(NiFile file, BinaryReader reader) : base(file, reader)
		{
			if (this.File.Header.Version >= eNifVersion.VER_10_1_0_0)
			{
				this.Unknown1 = reader.ReadUInt16();
			}
			this.CameraTargetNode = new NiRef<NiNode>(reader);
		}
	}
}
