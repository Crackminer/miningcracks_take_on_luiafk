using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedCursedBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Cursed Bullets");
			base.Tooltip.SetDefault("Never run out of Cursed Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 546);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(546, 3996).AddTile(18).Register();
		}
	}
}
