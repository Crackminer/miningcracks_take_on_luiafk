using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedCursedArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Cursed Arrows");
			base.Tooltip.SetDefault("Never run out of Cursed Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 545);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(545, 3996).AddTile(18).Register();
		}
	}
}
