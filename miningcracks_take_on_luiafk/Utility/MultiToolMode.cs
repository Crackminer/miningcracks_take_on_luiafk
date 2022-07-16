using System;

namespace miningcracks_take_on_luiafk.Utility
{
	[Flags]
	internal enum MultiToolMode : byte
	{
		Red = 0x1,
		Green = 0x2,
		Blue = 0x4,
		Yellow = 0x8,
		Actuator = 0x10,
		Cutter = 0x20
	}
}
