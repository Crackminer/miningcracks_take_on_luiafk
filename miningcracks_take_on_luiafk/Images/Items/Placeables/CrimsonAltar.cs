using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables
{
	public class CrimsonAltar : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Crimson Altar");
			base.Tooltip.SetDefault("Places a Crimson Altar for crafting.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 94);
			base.Item.createTile = base.Mod.Find<ModTile>("CrimsonAltar").Type;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:EvilOreMat", 30).AddRecipeGroup("Luiafk:EvilBar", 15).AddRecipeGroup("Luiafk:EvilStoneBlock", 50)
				.AddTile(16)
				.Register();
		}
	}
}
