using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedLuminiteBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Luminite Bullets");
			base.Tooltip.SetDefault("Never run out of Luminite Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3567);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3567, 3996).AddTile(18).Register();
		}
	}
}
