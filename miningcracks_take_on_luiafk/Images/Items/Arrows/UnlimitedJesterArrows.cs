using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedJesterArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Jester's Arrows");
			base.Tooltip.SetDefault("Never run out of Jester's Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 51);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(51, 3996).AddTile(18).Register();
		}
	}
}
