using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedHunter : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Hunter Potion");
			base.Tooltip.SetDefault("Spot the enemy before they spot you.\nUse the Settings UI to toggle the effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Hunter");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(304, 30).AddTile(13).Register();
		}
	}
}
