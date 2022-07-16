using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Darts
{
	public class UnlimitedPoisonDarts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Poison Darts");
			base.Tooltip.SetDefault("Never run out of Poison Darts.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1310);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1310, 3996).AddTile(18).Register();
		}
	}
}
