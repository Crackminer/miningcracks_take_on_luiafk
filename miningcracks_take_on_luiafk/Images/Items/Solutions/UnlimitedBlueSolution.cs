using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedBlueSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Blue Solution");
			base.Tooltip.SetDefault("Never run out of Blue Solution.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, 1);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(781, 999).AddTile(18).Register();
		}
	}
}
