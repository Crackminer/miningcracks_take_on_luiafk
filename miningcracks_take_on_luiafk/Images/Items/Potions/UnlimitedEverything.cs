using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedEverything : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Buffs");
			base.Tooltip.SetDefault("Almost everything.\nArmor debuff from tipsy only active while holding a melee weapon.\nUse to teleport to a random location.\nClick a friend on the map to travel to them.\nSet hotkeys to use Recall.\nRecall teleports you to your spawn point.\nRecall Back teleports you to the last location you used Recall.\nUse the Settings hotkey to toggle certain buffs and effects.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.UseSound = SoundID.Item6;
			base.Item.useStyle = 2;
			base.Item.useTurn = true;
			base.Item.useAnimation = 17;
			base.Item.useTime = 17;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				player.GetModPlayer<LuiafkPlayer>().timerNeeded = 3;
			}
			return true;
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[1] = true;
			player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedExplorer").AddIngredient(null, "UnlimitedCombat").AddIngredient(null, "UnlimitedFishing")
				.AddIngredient(null, "UnlimitedTravel")
				.AddIngredient(null, "UnlimitedFlight")
				.AddIngredient(null, "UnlimitedInvisibility")
				.AddIngredient(null, "UnlimitedTeleportation")
				.AddIngredient(null, "UltimateBattler")
				.AddIngredient(null, "UltimatePeaceful")
				.AddIngredient(null, "UnlimitedLucky")
				.AddTile(13)
				.Register();
		}
	}
}
