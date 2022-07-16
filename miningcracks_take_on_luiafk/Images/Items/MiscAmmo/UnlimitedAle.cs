using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedAle : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ale");
			base.Tooltip.SetDefault("Never run out of Ale.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 353);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(353, 3996).AddTile(18).Register();
		}
	}
}
