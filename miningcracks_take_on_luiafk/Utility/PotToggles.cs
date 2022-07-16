using System;

namespace miningcracks_take_on_luiafk.Utility
{
	[Flags]
	internal enum PotToggles : ushort
	{
		UltBattler =		0b000000001,
		UltPeaceful =		0b000000010,
		Grav =				0b000000100,
		Feather =			0b000001000,
		Inferno =			0b000010000,
		Invis =				0b000100000,
		Crate =				0b001000000,
		Spelunker =			0b010000000,
		DangerHunter =		0b100000000
	}
}
