using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedGoldenBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Golden Bullets");
			base.Tooltip.SetDefault("Never run out of Golden Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1352);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1352, 3996).AddTile(18).Register();
		}
	}
}
