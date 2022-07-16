using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedShuriken : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Shuriken");
			base.Tooltip.SetDefault("Never run out of Shuriken.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 42, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(42, 999).AddTile(16).Register();
		}
	}
}
