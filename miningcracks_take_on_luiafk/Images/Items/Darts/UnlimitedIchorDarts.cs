using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Darts
{
	public class UnlimitedIchorDarts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ichor Darts");
			base.Tooltip.SetDefault("Never run out of Ichor Darts.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3011);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3011, 3996).AddTile(18).Register();
		}
	}
}
