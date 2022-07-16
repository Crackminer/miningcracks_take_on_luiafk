using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedGrenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Grenades");
			base.Tooltip.SetDefault("Never run out of Grenades.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 168, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(168, 396).AddTile(18).Register();
		}
	}
}
