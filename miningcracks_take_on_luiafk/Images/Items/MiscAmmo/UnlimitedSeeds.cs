using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Seeds");
			base.Tooltip.SetDefault("Never run out of Seeds.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 283);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(283, 999).AddTile(18).Register();
		}
	}
}
