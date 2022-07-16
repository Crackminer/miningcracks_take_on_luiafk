using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Explosives
{
	public class UnlimitedDynamite : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Dynamite");
			base.Tooltip.SetDefault("Never run out of Dynamite.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 167, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(167, 198).AddTile(16).Register();
		}
	}
}
