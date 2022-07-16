using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedHellfireArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Hellfire Arrows");
			base.Tooltip.SetDefault("Never run out of Hellfire Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 265);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(265, 3996).AddTile(18).Register();
		}
	}
}
