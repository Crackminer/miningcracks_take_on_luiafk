using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedExplorer : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Explorer Buffs");
			base.Tooltip.SetDefault("Makes it easier to get around.\nUse the Settings UI to toggle certain effects.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Explorer");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedDanger").AddIngredient(null, "UnlimitedGathering").AddIngredient(null, "UnlimitedSwimming")
				.AddIngredient(null, "UnlimitedBuilder")
				.AddTile(13)
				.Register();
		}
	}
}
