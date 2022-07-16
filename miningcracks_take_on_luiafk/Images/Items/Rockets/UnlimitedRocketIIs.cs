using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Rockets
{
	public class UnlimitedRocketIIs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Rocket IIs");
			base.Tooltip.SetDefault("Never run out of Rocket IIs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 772);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(772, 3996).AddTile(18).Register();
		}
	}
}
