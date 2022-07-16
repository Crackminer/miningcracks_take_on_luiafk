using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedFrostburnArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Frostburn Arrows");
			base.Tooltip.SetDefault("Never run out of Frostburn Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 988);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(988, 3996).AddTile(18).Register();
		}
	}
}
