using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Ropes
{
	public class UnlimitedChain : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Chains");
			base.Tooltip.SetDefault("Never run out of Chains.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 85);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(85, 999).AddTile(18).Register();
		}
	}
}
