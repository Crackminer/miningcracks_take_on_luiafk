using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedStickyGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Sticky Grenades");
			base.Tooltip.SetDefault("Never run out of Sticky Grenades.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 2586, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(23, 80).AddIngredient(null, "UnlimitedGrenade").AddTile(18)
				.Register();
			CreateRecipe().AddIngredient(2586, 396).AddTile(18).Register();
		}
	}
}
