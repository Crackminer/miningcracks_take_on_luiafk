using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedWoodenArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Wooden Arrows");
			base.Tooltip.SetDefault("Never run out of Wooden Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 40);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(40, 3996).AddTile(18).Register();
		}
	}
}
