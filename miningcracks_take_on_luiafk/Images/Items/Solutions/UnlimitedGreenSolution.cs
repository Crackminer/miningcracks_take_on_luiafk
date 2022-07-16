using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedGreenSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Green Solution");
			base.Tooltip.SetDefault("Never run out of Green Solution.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, 0);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(780, 999).AddTile(18).Register();
		}
	}
}
