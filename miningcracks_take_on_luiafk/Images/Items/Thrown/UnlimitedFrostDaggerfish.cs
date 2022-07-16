using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedFrostDaggerfish : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Frost Daggerfish");
			base.Tooltip.SetDefault("Never run out of Frost Daggerfish.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3197, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3197, 999).AddTile(18).Register();
		}
	}
}
