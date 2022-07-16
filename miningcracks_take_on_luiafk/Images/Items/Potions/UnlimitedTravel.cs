using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedTravel : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Travel Potion");
			base.Tooltip.SetDefault("Never miss your friends again.\nSet hotkeys to use Recall.\nRecall teleports you to your spawn point.\nRecall Back teleports you to the last location you used Recall.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Travel");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedWormhole").AddIngredient(null, "UnlimitedRecall").AddTile(13)
				.Register();
		}
	}
}
