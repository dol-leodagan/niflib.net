using System;

namespace Niflib
{
	public enum eChannelType : uint
	{
		CHNL_RED,
		CHNL_GREEN,
		CHNL_BLUE,
		CHNL_ALPHA,
		CHNL_COMPRESSED,
		CHNL_INDEX = 16u,
		CHNL_EMPTY = 19u
	}
}
