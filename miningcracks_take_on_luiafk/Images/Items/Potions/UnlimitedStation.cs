using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedStation : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Station Buffs");
			base.Tooltip.SetDefault("All 4 buff stations.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[72] = true;
player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedCrystalBall").AddIngredient(null, "UnlimitedAmmoBox").AddIngredient(null, "UnlimitedSharpeningStation")
				.AddIngredient(null, "UnlimitedBewitchingTable")
				.AddTile(13)
				.Register();
		}
	}
}
