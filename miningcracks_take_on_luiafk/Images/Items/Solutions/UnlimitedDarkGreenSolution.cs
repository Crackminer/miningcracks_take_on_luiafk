using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedDarkGreenSolution : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Dark Green Solution");
			base.Tooltip.SetDefault("Never run out of Dark Green Solution.\nSpreads the Jungle.\nConverts pretty much everything.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Solutions(base.Item, base.Mod.Find<ModProjectile>("DarkGreenSolutionProjectile").Type - 145);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "DarkGreenSolution", 999).AddTile(18).Register();
		}
	}
}
