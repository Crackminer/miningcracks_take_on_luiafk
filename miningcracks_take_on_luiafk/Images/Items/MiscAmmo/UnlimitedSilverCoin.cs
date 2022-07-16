using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedSilverCoin : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Silver Coins");
			base.Tooltip.SetDefault("Never run out of Silver Coins.\nCounts as Ammo, not Money!");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 72);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(72, 499).AddTile(18).Register();
		}
	}
}
