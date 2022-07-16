using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedNanoBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Nano Bullets");
			base.Tooltip.SetDefault("Never run out of Nano Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1350);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1350, 3996).AddTile(18).Register();
		}
	}
}
