using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedNails : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Nails");
			base.Tooltip.SetDefault("Never run out of Nails.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3108);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3108, 3996).AddTile(18).Register();
		}
	}
}
