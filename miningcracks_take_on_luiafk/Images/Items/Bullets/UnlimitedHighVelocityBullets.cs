using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedHighVelocityBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited High Velocity Bullets");
			base.Tooltip.SetDefault("Never run out of High Velocity Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1302);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1302, 3996).AddTile(18).Register();
		}
	}
}
