using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedStakes : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Stakes");
			base.Tooltip.SetDefault("Never run out of Stakes.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1836);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1836, 3996).AddTile(18).Register();
		}
	}
}
