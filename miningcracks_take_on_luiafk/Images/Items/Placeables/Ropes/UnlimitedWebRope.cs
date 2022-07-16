using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Ropes
{
	public class UnlimitedWebRope : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Web Rope");
			base.Tooltip.SetDefault("Never run out of Web Rope.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3078);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:WebSilkRope", 999).AddTile(18).Register();
		}
	}
}
