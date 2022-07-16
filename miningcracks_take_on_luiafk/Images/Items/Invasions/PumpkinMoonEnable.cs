using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class PumpkinMoonEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Pumpkin Moon Medallion");
			base.Tooltip.SetDefault("Starts the Pumpkin Moon.");
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
						if (!Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon && !DD2Event.Ongoing && Main.netMode != 1)
			{
				MiscMethods.WriteText(Lang.misc[31].Value, new Color(50, 255, 130));
				Main.startPumpkinMoon();
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1844, 10).AddTile(18).Register();
		}
	}
}
