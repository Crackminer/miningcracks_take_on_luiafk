using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class Safe : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Mobile Safe");
			base.Tooltip.SetDefault("Summons a floating Safe.\nSmart cursor disabled while using bank.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3213);
			base.Item.shoot = base.Mod.Find<ModProjectile>("SafeProjectile").Type;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(346, 2).AddIngredient(154, 30).AddRecipeGroup("Luiafk:EvilMushroom", 10)
				.AddTile(18)
				.Register();
		}
	}
}
