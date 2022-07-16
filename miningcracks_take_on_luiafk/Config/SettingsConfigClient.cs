using Terraria.ModLoader.Config;

namespace miningcracks_take_on_luiafk.Config
{
	[BackgroundColor(164, 153, 190, 255)]
	[Label("Luiafk Client Configs")]
	internal class SettingsConfigClient : ModConfig
	{
		[Label("Such Empty, might be used in the future ^^")]
		public bool empty_stuff;

		public override ConfigScope Mode => ConfigScope.ClientSide;
	}
}
