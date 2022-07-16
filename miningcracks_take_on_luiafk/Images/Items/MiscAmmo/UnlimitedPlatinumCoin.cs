using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedPlatinumCoin : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Platinum Coins");
			base.Tooltip.SetDefault("Never run out of Platimun Coins.\nCounts as Ammo, not Money!");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 74);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(74, 150).AddTile(18).Register();
		}
	}
}
