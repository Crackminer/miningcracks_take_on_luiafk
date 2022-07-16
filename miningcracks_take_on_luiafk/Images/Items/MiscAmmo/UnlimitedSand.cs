using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedSand : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Sand");
			base.Tooltip.SetDefault("Never run out of Sand.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 169);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:SandBlock", 3996).AddTile(18).Register();
		}
	}
}
