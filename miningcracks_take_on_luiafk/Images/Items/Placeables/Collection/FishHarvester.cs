using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	public class FishHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fish Harvester");
			base.Tooltip.SetDefault("When placed will fish in nearby water.\nRequires Unlimited Rod or Normal Rod + Bait.\nCertain items can be placed in the chest for higher quality fish.\nCatches will be based on the chests location (biomes).\nPlace upto 10 tiles above water.\nBiome range is 30 tiles in each direction.\nExpert");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Storage(base.Item, ModContent.TileType<FishHarvesterTile>());
		}

		public override void AddRecipes()
		{
			if (Main.expertMode || Main.masterMode)
			{
				CreateRecipe().AddRecipeGroup("Luiafk:Chests").AddIngredient(base.Mod.Find<ModItem>("FishingNet").Type, 7).AddIngredient(base.Mod.Find<ModItem>("HarvesterParts").Type, 3)
					.AddTile(16)
					.Register();
			}
		}
	}
}
