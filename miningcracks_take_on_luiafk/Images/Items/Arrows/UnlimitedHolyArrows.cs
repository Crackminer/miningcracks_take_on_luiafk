using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedHolyArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Holy Arrows");
			base.Tooltip.SetDefault("Never run out of Holy Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 516);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(516, 3996).AddTile(18).Register();
		}
	}
}
