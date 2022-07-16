using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedChlorophyteBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Chlorophyte Bullets");
			base.Tooltip.SetDefault("Never run out of Chlorophyte Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1179);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1179, 3996).AddTile(18).Register();
		}
	}
}
