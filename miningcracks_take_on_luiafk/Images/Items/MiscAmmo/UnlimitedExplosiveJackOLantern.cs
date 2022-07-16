using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MiscAmmo
{
	public class UnlimitedExplosiveJackOLantern : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Explosive Jack 'O Lanterns");
			base.Tooltip.SetDefault("Never run out of Explosive Jack 'O Lanterns.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 1785);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(1785, 3996).AddTile(18).Register();
		}
	}
}
