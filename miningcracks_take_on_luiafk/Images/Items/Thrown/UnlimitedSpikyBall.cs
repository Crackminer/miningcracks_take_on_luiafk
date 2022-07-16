using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedSpikyBall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Spiky Balls");
			base.Tooltip.SetDefault("Never run out of Spiky Balls.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.CloneAmmoThrown(base.Item, 161, usable: true);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(161, 999).AddTile(18).Register();
		}
	}
}
