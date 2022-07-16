using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables
{
	public class AsphaltPlatform : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Asphalt Platforms");
			base.Tooltip.SetDefault("Allows you to run super fast.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 94);
			base.Item.createTile = base.Mod.Find<ModTile>("AsphaltPlatform").Type;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(775, 1998).AddTile(18).Register();
		}
	}
}
