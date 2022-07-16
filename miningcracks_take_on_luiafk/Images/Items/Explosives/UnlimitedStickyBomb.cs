using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedStickyBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Sticky Bombs");
			base.Tooltip.SetDefault("Never run out of Sticky Bombs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 235, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(235, 396).AddTile(16).Register();
		}
	}
}
