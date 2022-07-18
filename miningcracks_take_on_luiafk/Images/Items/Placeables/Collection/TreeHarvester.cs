using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	public class TreeHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Tree Harvester");
			base.Tooltip.SetDefault("When placed will collect and replant nearby trees.\nWill collect wood within 50 tiles each direction.\nWill replant anything harvested.\nNo acorns will be collected.\nStone/Gemcorn Trees will not be harvested.\nExpert");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Storage(base.Item, ModContent.TileType<TreeHarvesterTile>());
		}

		public override void AddRecipes()
		{
			if (Main.expertMode || Main.masterMode)
			{
				CreateRecipe().AddRecipeGroup("Luiafk:Chests").AddRecipeGroup("Luiafk:Axes").AddIngredient(206, 5)
					.AddIngredient(base.Mod.Find<ModItem>("Piping").Type, 7)
					.AddIngredient(base.Mod.Find<ModItem>("HarvesterParts").Type, 3)
					.AddTile(16)
					.Register();
			}
		}
	}
}
