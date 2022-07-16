using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedRedSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Red Solution");
			base.Tooltip.SetDefault("Never run out of Red Solution.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, 4);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(784, 999).AddTile(18).Register();
		}
	}
}
