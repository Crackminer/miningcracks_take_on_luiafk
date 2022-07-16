using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedPurpleSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Purple Solution");
			base.Tooltip.SetDefault("Never run out of Purple Solution.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, 2);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(782, 999).AddTile(18).Register();
		}
	}
}
