using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedSwimming : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Aquatic Buffs");
			base.Tooltip.SetDefault("You love the water.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Swimming");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedGills").AddIngredient(null, "UnlimitedWaterWalking").AddIngredient(null, "UnlimitedFlipper")
				.AddTile(13)
				.Register();
		}
	}
}
