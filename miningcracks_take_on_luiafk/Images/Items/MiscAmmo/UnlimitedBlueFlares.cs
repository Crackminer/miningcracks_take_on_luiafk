using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedBlueFlares : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Blue Flares");
			base.Tooltip.SetDefault("Never run out of Blue Flares.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1614);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Flare", 3996).AddTile(18).Register();
		}
	}
}
