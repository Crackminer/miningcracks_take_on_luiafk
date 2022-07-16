using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedBasics : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Basic Buffs");
			base.Tooltip.SetDefault("Food, regen, ironskin, and speed.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Basics");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedIronskin").AddIngredient(null, "UnlimitedSwiftness").AddIngredient(null, "UnlimitedRegeneration")
				.AddIngredient(null, "UnlimitedWellFed")
				.AddTile(13)
				.Register();
		}
	}
}
