using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedSilverBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Silver Bullets");
			base.Tooltip.SetDefault("Never run out of Silver Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 278);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(278, 3996).AddTile(18).Register();
		}
	}
}
