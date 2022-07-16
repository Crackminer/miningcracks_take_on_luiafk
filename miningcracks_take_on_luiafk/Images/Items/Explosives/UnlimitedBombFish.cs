using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedBombFish : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bomb Fish");
			base.Tooltip.SetDefault("Never run out of Bomb Fish.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 3196, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3196, 396).AddTile(16).Register();
		}
	}
}
