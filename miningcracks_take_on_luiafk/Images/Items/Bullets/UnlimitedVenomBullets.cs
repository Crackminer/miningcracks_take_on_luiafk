using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Bullets
{
	public class UnlimitedVenomBullets : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Venom Bullets");
			base.Tooltip.SetDefault("Never run out of Venom Bullets.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1342);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1342, 3996).AddTile(18).Register();
		}
	}
}
