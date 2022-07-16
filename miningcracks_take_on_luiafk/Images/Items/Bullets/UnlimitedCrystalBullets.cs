using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedCrystalBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Crystal Bullets");
			base.Tooltip.SetDefault("Never run out of Crystal Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 515);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(515, 3996).AddTile(18).Register();
		}
	}
}
