using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	public class CactusHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Cactus Harvester");
			base.Tooltip.SetDefault("When placed will collect nearby cactus.\nWill collect cactus within 50 tiles each direction.\nExpert");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Storage(base.Item, ModContent.TileType<CactusHarvesterTile>());
			Item.expertOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Chests").AddRecipeGroup("Luiafk:Axes").AddIngredient(206, 5)
				.AddIngredient(base.Mod.Find<ModItem>("Piping").Type, 7)
				.AddIngredient(base.Mod.Find<ModItem>("HarvesterParts").Type, 3)
				.AddTile(16)
				.AddCondition(Terraria.Localization.NetworkText.FromLiteral("Luiafk:Expert Only"), ((Recipe _) => Main.expertMode || Main.masterMode))
				.Register();
		}
	}
}
