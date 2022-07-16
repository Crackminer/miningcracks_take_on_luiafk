using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedVenomArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Venom Arrows");
			base.Tooltip.SetDefault("Never run out of Venom Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1341);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1341, 3996).AddTile(18).Register();
		}
	}
}
