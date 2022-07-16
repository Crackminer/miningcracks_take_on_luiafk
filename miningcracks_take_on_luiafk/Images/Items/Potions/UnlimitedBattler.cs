using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedBattler : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Battler Buffs");
			base.Tooltip.SetDefault("Greatly increased spawns.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Battler");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedBattle").AddIngredient(null, "UnlimitedWaterCandle").AddTile(13)
				.Register();
		}
	}
}
