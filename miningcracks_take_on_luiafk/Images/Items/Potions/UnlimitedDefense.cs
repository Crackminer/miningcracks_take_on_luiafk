using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedDefense : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Defense Buffs");
			base.Tooltip.SetDefault("More HP, damage reduction, and heart range.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Defense");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedHeartreach").AddIngredient(null, "UnlimitedLifeforce").AddIngredient(null, "UnlimitedWarmth")
				.AddIngredient(null, "UnlimitedEndurance")
				.AddTile(13)
				.Register();
		}
	}
}
