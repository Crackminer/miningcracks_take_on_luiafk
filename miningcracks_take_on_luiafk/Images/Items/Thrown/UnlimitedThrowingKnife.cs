using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedThrowingKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Throwing Knives");
			base.Tooltip.SetDefault("Never run out of Throwing Knives.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 279, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(279, 999).AddTile(16).Register();
		}
	}
}
