using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualCandles
{
	public class UnlimitedWaterCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Water Candle");
			base.Tooltip.SetDefault("Increased spawns.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("WaterCandle");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(148, 15).AddTile(13).Register();
		}
	}
}
