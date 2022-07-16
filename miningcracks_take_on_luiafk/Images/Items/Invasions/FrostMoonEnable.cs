using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Invasions
{
	public class FrostMoonEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Naughty Present");
			base.Tooltip.SetDefault("Starts the Frost Moon.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
						if (!Main.dayTime && !Main.snowMoon && !Main.pumpkinMoon && !DD2Event.Ongoing && Main.netMode != 1)
			{
				MiscMethods.WriteText(Lang.misc[34].Value, new Color(50, 255, 130));
				Main.startSnowMoon();
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1958, 10).AddTile(18).Register();
		}
	}
}
