using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Potions
{
	public class UnlimitedRange : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Ranged Buffs");
			base.Tooltip.SetDefault("Reservation and archery.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			player.GetModPlayer<LuiafkPlayer>().buffs.Add("Range");
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedAmmoReservation").AddIngredient(null, "UnlimitedArchery").AddTile(13)
				.Register();
		}
	}
}
