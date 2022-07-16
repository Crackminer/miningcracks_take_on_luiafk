using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedCandyCorn : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Candy Corn");
			base.Tooltip.SetDefault("Never run out of Candy Corn.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1783);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1783, 3996).AddTile(18).Register();
		}
	}
}
