using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedPoisonKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Poison Knives");
			base.Tooltip.SetDefault("Never run out of Poison Knives.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 287, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:EvilPowder", 20).AddIngredient(null, "UnlimitedThrowingKnife").AddTile(18)
				.Register();
			CreateRecipe().AddIngredient(287, 999).AddTile(18).Register();
		}
	}
}
