using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedDamage : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Damage Buffs");
			base.Tooltip.SetDefault("Damage, crit, extra minion, knockback, and thorns.\nUse the Settings hotkey to toggle Inferno's visual effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[61] = true;
player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedRage").AddIngredient(null, "UnlimitedWrath").AddIngredient(null, "UnlimitedSummoning")
				.AddIngredient(null, "UnlimitedTitan")
				.AddIngredient(null, "UnlimitedThorns")
				.AddIngredient(null, "UnlimitedInferno")
				.AddTile(13)
				.Register();
		}
	}
}
