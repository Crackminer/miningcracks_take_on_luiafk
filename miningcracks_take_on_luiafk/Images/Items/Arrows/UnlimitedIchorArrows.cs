using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Arrows
{
	public class UnlimitedIchorArrows : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ichor Arrows");
			base.Tooltip.SetDefault("Never run out of Ichor Arrows.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1334);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1334, 3996).AddTile(18).Register();
		}
	}
}
