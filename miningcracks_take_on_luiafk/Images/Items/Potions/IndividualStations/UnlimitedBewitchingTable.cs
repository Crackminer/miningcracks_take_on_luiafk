using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualStations
{
	public class UnlimitedBewitchingTable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Bewitching Table");
			base.Tooltip.SetDefault("Have an extra friend around.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Bewitching");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2999, 5).AddTile(13).Register();
		}
	}
}
