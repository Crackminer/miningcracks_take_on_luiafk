using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedFishing : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Fishing Buffs");
			base.Tooltip.SetDefault("Catch all the fish you'll ever need.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[65] = true;
player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedFishingPotion").AddIngredient(null, "UnlimitedSonar").AddIngredient(null, "UnlimitedCrates")
				.AddTile(13)
				.Register();
		}
	}
}
