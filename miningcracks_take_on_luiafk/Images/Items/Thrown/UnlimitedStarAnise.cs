using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedStarAnise : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Star Anises");
			base.Tooltip.SetDefault("Never run out of Star Anises.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1913, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1913, 999).AddTile(18).Register();
		}
	}
}
