using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Locators
{
	public class TempleLocator : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Lihzahrd Detector");
			base.Tooltip.SetDefault("Locates the Jungle Temple.\nUse to search below you.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override bool? UseItem(Player player)
		{
						if (Main.netMode != 1)
			{
				TileChecks.SearchBelow(player, TileChecks.Temple, new Color(255, 0, 0), "Temple Located", 50);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1141).AddIngredient(1006, 5).AddIngredient(530, 50)
				.AddIngredient(3102)
				.AddTile(134)
				.Register();
		}
	}
}
