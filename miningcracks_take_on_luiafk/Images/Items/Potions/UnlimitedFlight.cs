using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedFlight : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Flight");
			base.Tooltip.SetDefault("Go find all those sky islands.\nNo need to worry about falling to your death.\nUse the settings hotkey to toggle Featherfall and Gravity Control.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[66] = true;
player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedFeatherfall").AddIngredient(null, "UnlimitedGravitation").AddTile(13)
				.Register();
		}
	}
}
