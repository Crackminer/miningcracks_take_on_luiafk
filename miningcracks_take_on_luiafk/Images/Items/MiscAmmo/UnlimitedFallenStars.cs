using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedFallenStars : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Fallen Stars");
			base.Tooltip.SetDefault("Never run out of Fallen Stars.");
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 75);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(75, 297).AddTile(18).Register();
		}
	}
}
