using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class ToolTime : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Tool Time");
			base.Tooltip.SetDefault("Tool, painting, tile, and wall speed increased.\nRange increased.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 200000;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			Item[] miscEquips = player.miscEquips;
			foreach (Item item in miscEquips)
			{
				if (item.active && item.accessory && (item.type == ModContent.Find<ModItem>("FasterMining").Type || item.type == ModContent.Find<ModItem>("SuperToolTime").Type))
				{
					return false;
				}
			}
			return true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Item item = player.inventory[player.selectedItem];
				if ((item.hammer > 0 || item.axe > 0 || item.pick > 0 || item.createTile >= 0 || item.createWall >= 0 || item.type == 1071 || item.type == 1072 || item.type == 1100 || item.type == 1543 || item.type == 1544 || item.type == 1545) && !item.channel && (ItemID.Sets.ExtractinatorMode[item.type] < 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].TileType != 219))
				{
					player.itemTime /= 2;
				}
				Player.tileRangeX = 8;
				Player.tileRangeY = 8;
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("FasterMining").Type).AddIngredient(154, 30).AddIngredient(175, 10)
				.AddIngredient(2325, 5)
				.AddTile(114)
				.Register();
		}
	}
}
