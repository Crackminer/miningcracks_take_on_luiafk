using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedIchorBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ichor Bullets");
			base.Tooltip.SetDefault("Never run out of Ichor Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1335);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1335, 3996).AddTile(18).Register();
		}
	}
}
