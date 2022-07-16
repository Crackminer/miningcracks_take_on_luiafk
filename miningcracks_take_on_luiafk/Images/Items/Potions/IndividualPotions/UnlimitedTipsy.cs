using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedTipsy : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Tipsy Potion");
			base.Tooltip.SetDefault("Increased damage, less defense.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Tipsy");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Luiafk:Tipsy", 30).AddTile(13).Register();
		}
	}
}
