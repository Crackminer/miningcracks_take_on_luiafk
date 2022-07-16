using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class PiggyBank : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Mobile Piggy Bank");
			base.Tooltip.SetDefault("Summons a floating Piggy Bank.\nSmart cursor disabled while using bank.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3213);
			base.Item.shoot = base.Mod.Find<ModProjectile>("PiggyBankProjectile").Type;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(87, 2).AddIngredient(216).AddIngredient(751, 20)
				.AddTile(18)
				.Register();
		}
	}
}
