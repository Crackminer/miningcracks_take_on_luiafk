using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Rockets
{
	public class UnlimitedRocketIIIs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Rocket IIIs");
			base.Tooltip.SetDefault("Never run out of Rocket IIIs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 773);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(773, 3996).AddTile(18).Register();
		}
	}
}
