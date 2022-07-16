using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Locators
{
	public class PlanteraLocator : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plantera Detector");
			base.Tooltip.SetDefault("Locates a Plantera Bulb.\nUse to search below you.");
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
				TileChecks.SearchBelow(player, TileChecks.PlanteraBulb, new Color(255, 0, 255), "Plantera Located.", 2);
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(547, 5).AddIngredient(548, 5).AddIngredient(549, 5)
				.AddIngredient(530, 50)
				.AddIngredient(3118)
				.AddTile(134)
				.Register();
		}
	}
}
