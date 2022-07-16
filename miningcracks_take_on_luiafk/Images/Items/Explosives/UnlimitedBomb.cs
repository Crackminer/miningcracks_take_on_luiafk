using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bombs");
			base.Tooltip.SetDefault("Never run out of Bombs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 166, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(166, 396).AddTile(16).Register();
		}
	}
}
