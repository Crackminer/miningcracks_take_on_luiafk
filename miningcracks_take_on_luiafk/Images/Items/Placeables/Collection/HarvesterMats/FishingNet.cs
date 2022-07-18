using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection.HarvesterMats
{
	public class FishingNet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.Tooltip.SetDefault("Expert");
			base.SacrificeTotal = 25;
		}

		public override void SetDefaults()
		{
			Defaults.ChestMaterials(base.Item);
			Item.expertOnly = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(225, 25).AddTile(18).AddCondition(Terraria.Localization.NetworkText.FromLiteral("Luiafk:Expert Only"), ((Recipe _) => Main.expertMode || Main.masterMode)).Register();
		}
	}
}
