using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedDarkBlueSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Dark Blue Solution");
			base.Tooltip.SetDefault("Never run out of Dark Blue Solution.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, 3);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(783, 999).AddTile(18).Register();
		}
	}
}
