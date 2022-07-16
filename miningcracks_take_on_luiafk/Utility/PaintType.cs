using System;

namespace miningcracks_take_on_luiafk.Utility
{
	[Flags]
	internal enum PaintType : byte
	{
		Tile = 0x1,
		Wall = 0x2,
		Remove = 0x4
	}
}
