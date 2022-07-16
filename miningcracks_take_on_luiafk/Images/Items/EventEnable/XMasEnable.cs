using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.EventEnable
{
	public class XMasEnable : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Happy Christmas");
			base.Tooltip.SetDefault("Christmas is active while this is in your inventory.\nWhen removing it from your inventory it will take until morning to return to normal.");
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
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(593, 100).AddIngredient(501, 30).AddIngredient(521, 5)
				.AddIngredient(520, 5)
				.AddTile(18)
				.Register();
		}
	}
}
