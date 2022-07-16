using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualCandles
{
	public class UnlimitedPeaceCandle : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Peace Candle");
			base.Tooltip.SetDefault("Nice and quiet.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("PeaceCandle");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3117, 15).AddTile(13).Register();
		}
	}
}
