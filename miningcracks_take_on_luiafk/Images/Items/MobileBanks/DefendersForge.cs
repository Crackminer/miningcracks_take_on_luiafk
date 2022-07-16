using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class DefendersForge : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Mobile Defender's Forge");
			base.Tooltip.SetDefault("Summons a floating Defender's Forge.\nSmart cursor disabled while using bank.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3213);
			base.Item.shoot = base.Mod.Find<ModProjectile>("DefendersForgeProjectile").Type;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3813).AddIngredient(575, 20).AddIngredient(521, 15)
				.AddIngredient(520, 15)
				.AddTile(18)
				.Register();
		}
	}
}
