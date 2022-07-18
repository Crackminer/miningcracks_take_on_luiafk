using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	public class GemCornHarvester : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Gemcorn Tree Harvester");
			base.Tooltip.SetDefault("When placed will collect nearby gemcorn trees.\nWill collect gemcorn trees within 50 tiles each direction.\nWill collect gemcorn acorns.\nWill currently not replant the gemcorn trees :/\nExpert");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Storage(base.Item, ModContent.TileType<GemCornHarvesterTile>());
			Item.expertOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Chests").AddRecipeGroup("Luiafk:Axes").AddIngredient(ItemID.Diamond, 5)
				.AddIngredient(ItemID.Sapphire, 5)
				.AddIngredient(ItemID.Amber, 5)
				.AddIngredient(ItemID.Topaz, 5)
				.AddIngredient(ItemID.Amethyst, 5)
				.AddIngredient(ItemID.Ruby, 5)
				.AddIngredient(ItemID.Emerald, 5)
				.AddIngredient(base.Mod.Find<ModItem>("Piping").Type, 7)
				.AddIngredient(base.Mod.Find<ModItem>("HarvesterParts").Type, 3)
				.AddTile(16)
				.AddCondition(Terraria.Localization.NetworkText.FromLiteral("Luiafk:Expert Only"), ((Recipe _) => Main.expertMode || Main.masterMode))
				.Register();
		}
	}
}