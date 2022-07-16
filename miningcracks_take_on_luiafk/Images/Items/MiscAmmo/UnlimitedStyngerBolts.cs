using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedStyngerBolts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Stynger Bolts");
			base.Tooltip.SetDefault("Never run out of Stynger Bolts.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1261);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1261, 3996).AddTile(18).Register();
		}
	}
}
