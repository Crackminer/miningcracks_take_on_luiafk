using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Darts
{
	public class UnlimitedCrystalDarts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Crystal Darts");
			base.Tooltip.SetDefault("Never run out of Crystal Darts.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3009);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3009, 3996).AddTile(18).Register();
		}
	}
}
