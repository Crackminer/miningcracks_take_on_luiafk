using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedSonar : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Sonar Potion");
			base.Tooltip.SetDefault("You somehow sense what you're about to reel in.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Sonar");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2355, 30).AddTile(13).Register();
		}
	}
}
