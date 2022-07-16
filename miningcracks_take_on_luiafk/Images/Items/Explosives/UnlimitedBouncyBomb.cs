using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedBouncyBomb : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bouncy Bomb");
			base.Tooltip.SetDefault("Never run out of Bouncy Bombs.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3115, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3115, 396).AddTile(16).Register();
		}
	}
}
