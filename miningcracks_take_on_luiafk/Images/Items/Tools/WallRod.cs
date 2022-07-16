using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class WallRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Wall Rod");
			base.Tooltip.SetDefault("Places the wall that is in your second to last inventory slot.\nBottom row, second from the right.\nDisable smart-cursor to use.\nBox placement like Paint Tool.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.tileBoost += 6;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				MiscMethods.WallRodHoldItem(player);
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(2325, 2).AddRecipeGroup("Luiafk:CopperTinBar", 10).AddRecipeGroup("Luiafk:FallenStar", 3)
				.AddRecipeGroup("Luiafk:Gems", 5)
				.AddTile(16)
				.Register();
		}
	}
}
