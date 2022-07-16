using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedInferno : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Inferno Potion");
			base.Tooltip.SetDefault("Sets nearby enemies on fire.\nUse the Settings hotkey to toggle the visual effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Inferno");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2348, 30).AddTile(13).Register();
		}
	}
}
