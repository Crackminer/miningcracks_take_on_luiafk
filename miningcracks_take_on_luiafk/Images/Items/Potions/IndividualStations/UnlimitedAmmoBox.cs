using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualStations
{
	public class UnlimitedAmmoBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ammo Box");
			base.Tooltip.SetDefault("Reduced ammo usage.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("AmmoBox");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2177, 5).AddTile(13).Register();
		}
	}
}
