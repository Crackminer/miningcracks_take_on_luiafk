using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedLuminiteArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Luminite Arrows");
			base.Tooltip.SetDefault("Never run out of Luminite Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3568);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3568, 3996).AddTile(18).Register();
		}
	}
}
