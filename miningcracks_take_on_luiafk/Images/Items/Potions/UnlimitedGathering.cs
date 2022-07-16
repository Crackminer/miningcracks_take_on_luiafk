using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedGathering : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Gathering Buffs");
			base.Tooltip.SetDefault("Go get all that ore.\nUse the Settings UI to toggle spelunker effect.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs[67] = true;
player.GetModPlayer<LuiafkPlayer>().buffs[0] = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedSpelunker").AddIngredient(null, "UnlimitedNightOwl").AddIngredient(null, "UnlimitedObsidianSkin")
				.AddIngredient(null, "UnlimitedMining")
				.AddIngredient(null, "UnlimitedShine")
				.AddTile(13)
				.Register();
		}
	}
}
