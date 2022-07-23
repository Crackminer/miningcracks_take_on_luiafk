using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedLadybug : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ladybugs");
			base.Tooltip.SetDefault("You feel the luck buzzing in your hands.\nNo critter!");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[76] = true;
			player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(4361, 95).AddIngredient(4362, 5).AddTile(13).Register();
		}
	}
}