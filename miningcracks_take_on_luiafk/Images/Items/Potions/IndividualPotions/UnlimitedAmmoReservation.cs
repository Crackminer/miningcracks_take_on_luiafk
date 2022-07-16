using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions.IndividualPotions
{
	public class UnlimitedAmmoReservation : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ammo Reservation Potion");
			base.Tooltip.SetDefault("Save some ammo.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("AmmoReservation");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2344, 30).AddTile(13).Register();
		}
	}
}
