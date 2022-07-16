using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedExplodingBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Exploding Bullets");
			base.Tooltip.SetDefault("Never run out of Exploding Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1351);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1351, 3996).AddTile(18).Register();
		}
	}
}
