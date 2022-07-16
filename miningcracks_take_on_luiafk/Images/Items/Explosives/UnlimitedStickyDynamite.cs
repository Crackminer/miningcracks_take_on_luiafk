using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedStickyDynamite : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Sticky Dynamite");
			base.Tooltip.SetDefault("Never run out of Sticky Dynamite.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 2896, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2896, 198).AddTile(16).Register();
		}
	}
}
