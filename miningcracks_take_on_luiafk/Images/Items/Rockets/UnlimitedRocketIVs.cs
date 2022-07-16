using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Rockets
{
	public class UnlimitedRocketIVs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Rocket IVs");
			base.Tooltip.SetDefault("Never run out of Rocket IVs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 774);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(774, 3996).AddTile(18).Register();
		}
	}
}
