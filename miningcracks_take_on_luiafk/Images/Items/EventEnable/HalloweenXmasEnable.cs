using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.EventEnable
{
	public class HalloweenXmasEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Happy Holidays");
			base.Tooltip.SetDefault("Christmas is active while this is in your inventory.\nHalloween is active while this is in your inventory.\nWhen removing it from your inventory it will take until morning to return to normal.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
			if (Main.netMode != 1)
			{
				Main.xMas = true;
				Main.halloween = true;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "HalloweenEnable").AddIngredient(null, "XMasEnable").AddTile(18)
				.Register();
		}
	}
}
