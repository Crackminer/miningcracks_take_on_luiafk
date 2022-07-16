using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedBeenade : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Beenades");
			base.Tooltip.SetDefault("Never run out of Beenades.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1130, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2431, 396).AddIngredient(null, "UnlimitedGrenade").AddTile(18)
				.Register();
			CreateRecipe().AddIngredient(1130, 396).AddTile(18).Register();
		}
	}
}
