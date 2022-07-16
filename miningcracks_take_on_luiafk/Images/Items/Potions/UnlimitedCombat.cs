using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedCombat : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Combat Buffs");
			base.Tooltip.SetDefault("All the combat buffs.\nArmor debuff from tipsy only active while holding a melee weapon.\nUse the Settings hotkey to toggle Inferno's visual effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Combat");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedBasics").AddIngredient(null, "UnlimitedDamage").AddIngredient(null, "UnlimitedDefense")
				.AddIngredient(null, "UnlimitedMagic")
				.AddIngredient(null, "UnlimitedMelee")
				.AddIngredient(null, "UnlimitedRange")
				.AddIngredient(null, "UnlimitedStation")
				.AddIngredient(null, "UnlimitedArena")
				.AddTile(13)
				.Register();
		}
	}
}
