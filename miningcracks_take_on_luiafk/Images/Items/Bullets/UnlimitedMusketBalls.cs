using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedMusketBalls : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Musket Balls");
			base.Tooltip.SetDefault("Never run out of Musket Balls.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 97);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(97, 3996).AddTile(18).Register();
		}
	}
}
