using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Rockets
{
	public class UnlimitedRocketIs : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Rocket Is");
			base.Tooltip.SetDefault("Never run out of Rocket Is.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 771);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(771, 3996).AddTile(18).Register();
		}
	}
}
