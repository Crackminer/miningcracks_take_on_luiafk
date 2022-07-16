using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Darts
{
	public class UnlimitedCursedDarts : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Cursed Darts");
			base.Tooltip.SetDefault("Never run out of Cursed Darts.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3010);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3010, 3996).AddTile(18).Register();
		}
	}
}
