using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedRecall : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Recall Potion");
			base.Tooltip.SetDefault("Teleports you home.\nSet hotkeys in controls to use.\nRecall teleports you to your spawn point.\nRecall Back teleports you to the last location you used Recall.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Recall");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2350, 30).AddTile(13).Register();
		}
	}
}
