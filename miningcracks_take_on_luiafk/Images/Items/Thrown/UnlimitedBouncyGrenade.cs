using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedBouncyGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bouncy Grenades");
			base.Tooltip.SetDefault("Never run out of Bouncy Grenades.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3116, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3111, 80).AddIngredient(null, "UnlimitedGrenade").AddTile(18)
				.Register();
			CreateRecipe().AddIngredient(3116, 396).AddTile(18).Register();
		}
	}
}
