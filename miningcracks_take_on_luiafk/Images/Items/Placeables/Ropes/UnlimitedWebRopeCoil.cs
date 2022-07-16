using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Ropes
{
	public class UnlimitedWebRopeCoil : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Web Rope Coils");
			base.Tooltip.SetDefault("Never run out of Web Rope Coils.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3080);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:WebSilkRope", 999).AddTile(18).Register();
		}
	}
}
