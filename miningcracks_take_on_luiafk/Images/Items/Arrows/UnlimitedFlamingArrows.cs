using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedFlamingArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Flaming Arrows");
			base.Tooltip.SetDefault("Never run out of Flaming Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 41);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(41, 3996).AddTile(18).Register();
		}
	}
}
