using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	public class PlantHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Plant Harvester");
			base.Tooltip.SetDefault("When placed will collect and replant nearby plants.\nWill collect plants blooming within 50 tiles each direction.\nWill replant anything harvested.\nNo seeds will be collected.\nExpert");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Storage(base.Item, ModContent.TileType<PlantHarvesterTile>());
			Item.expertOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Chests").AddIngredient(213).AddIngredient(206, 5)
				.AddIngredient(base.Mod.Find<ModItem>("Piping").Type, 7)
				.AddIngredient(base.Mod.Find<ModItem>("HarvesterParts").Type, 3)
				.AddTile(16)
				.AddCondition(Terraria.Localization.NetworkText.FromLiteral("Luiafk:Expert Only"), ((Recipe _) => Main.expertMode || Main.masterMode))
				.Register();
		}
	}
}
