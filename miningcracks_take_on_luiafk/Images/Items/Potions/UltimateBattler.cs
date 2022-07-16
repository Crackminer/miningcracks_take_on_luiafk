using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UltimateBattler : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Ultimate Battler");
			base.Tooltip.SetDefault("Are you sure you can handle this?\nMassively increased spawns.\nUse the settings hotkey to toggle the effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("UltimateBattler");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedBattler").AddRecipeGroup("Luiafk:EvilOreMat", 30).AddRecipeGroup("Luiafk:EvilMushroom", 30)
				.AddTile(13)
				.Register();
		}
	}
}
