using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedSnowballs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Snowballs");
			base.Tooltip.SetDefault("Never run out of Snowballs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 949, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(949, 3996).AddTile(18).Register();
		}
	}
}
