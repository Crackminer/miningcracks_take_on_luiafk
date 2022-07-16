using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedGel : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Gel");
			base.Tooltip.SetDefault("Never run out of Gel.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 23);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(23, 1499).AddTile(18).Register();
		}
	}
}
