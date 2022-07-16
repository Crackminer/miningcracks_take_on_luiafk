using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Ropes
{
	public class UnlimitedSilkRopeCoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Silk Rope Coils");
			base.Tooltip.SetDefault("Never run out of Silk Rope Coils.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3079);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:WebSilkRope", 999).AddTile(18).Register();
		}
	}
}
