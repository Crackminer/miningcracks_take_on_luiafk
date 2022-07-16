using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedFlares : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Flares");
			base.Tooltip.SetDefault("Never run out of Flares.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 931);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Flare", 3996).AddTile(18).Register();
		}
	}
}
