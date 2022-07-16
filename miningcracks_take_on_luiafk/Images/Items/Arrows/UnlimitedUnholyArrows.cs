using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedUnholyArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Unholy Arrows");
			base.Tooltip.SetDefault("Never run out of Unholy Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 47);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(47, 3996).AddTile(18).Register();
		}
	}
}
