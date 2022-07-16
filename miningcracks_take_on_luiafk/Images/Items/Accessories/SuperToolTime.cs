using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Accessories
{
	public class SuperToolTime : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Home Improvement");
			base.Tooltip.SetDefault("Tool, painting, tile, and wall speed massively increased.\nAuto-paint.\nRange massively increased.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.accessory = true;
			base.Item.value = 1200000;
		}

		public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
		{
			Item[] miscEquips = player.miscEquips;
			foreach (Item item in miscEquips)
			{
				if (item.active && item.accessory && (item.type == ModContent.Find<ModItem>("ToolTime").Type || item.type == ModContent.Find<ModItem>("FasterMining").Type))
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
					player.itemTime = 1;
				}
				Player.tileRangeX = 50;
				Player.tileRangeY = 50;
			}
			player.autoPaint = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("ToolTime").Type).AddIngredient(base.Mod.Find<ModItem>("UnlimitedMining").Type).AddIngredient(base.Mod.Find<ModItem>("UnlimitedBuilder").Type)
				.AddIngredient(3061)
				.AddIngredient(3467, 15)
				.AddIngredient(3456, 20)
				.AddIngredient(3458, 20)
				.AddIngredient(3459, 20)
				.AddIngredient(3457, 20)
				.AddTile(114)
				.Register();
		}
	}
}
