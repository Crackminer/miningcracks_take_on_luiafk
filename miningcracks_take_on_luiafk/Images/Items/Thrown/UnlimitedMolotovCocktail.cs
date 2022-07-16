using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedMolotovCocktail : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Molotov Cocktails");
			base.Tooltip.SetDefault("Never run out of Molotov Cocktails.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 2590, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2590, 396).AddTile(18).Register();
		}
	}
}
