using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedChlorophyteArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Chlorophyte Arrows");
			base.Tooltip.SetDefault("Never run out of Chlorophyte Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1235);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1235, 3996).AddTile(18).Register();
		}
	}
}
