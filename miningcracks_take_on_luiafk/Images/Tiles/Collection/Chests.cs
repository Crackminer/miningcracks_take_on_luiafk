using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	internal static class Chests
	{
		internal static void PlaceHarvester(int x, int y)
		{
			if (Main.netMode == 0)
			{
				Harvesting.HandleHarvesting(x, y);
			}
			else
			{
				Harvesting.HarvestingPacket(x, y, Packet.Harvesting);
			}
		}

		internal static void Kill(int x, int y, int drop)
		{
									Item.NewItem(new EntitySource_TileBreak(x, y), new Vector2((float)(x << 4), (float)(y << 4)), new Vector2(32f, 32f), drop);
			Chest.DestroyChest(x, y);
		}

		internal static string MapChestName(string name, int x, int y)
		{
			int num = TileChecks.FindChestSafe(x, y);
			if (num != -1 && Main.chest[num].name != "")
			{
				return name + ": " + Main.chest[num].name;
			}
			return name;
		}

		internal static void MouseOver(string name, int itemType, int x, int y)
		{
			Player player = Main.player[Main.myPlayer];
			int num = TileChecks.FindChestSafe(x, y);
			player.cursorItemIconID = -1;
			if (num < 0)
			{
				player.cursorItemIconText = Lang.chestType[0].Value;
			}
			else
			{
				player.cursorItemIconText = ((Main.chest[num].name.Length > 0) ? Main.chest[num].name : name);
				if (player.cursorItemIconText == name)
				{
					player.cursorItemIconID = itemType;
					player.cursorItemIconText = "";
				}
			}
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
		}

		internal static void MouseOverFar(string name, int itemType, int x, int y)
		{
			MouseOver(name, itemType, x, y);
			Player player = Main.player[Main.myPlayer];
			if (player.cursorItemIconText == "")
			{
				player.cursorItemIconEnabled = false;
				player.cursorItemIconID = 0;
			}
		}

		internal static void ChestRightClick(int x, int y)
		{
																																	Player player = Main.player[Main.myPlayer];
			Main.mouseRightRelease = false;
			Point16 point = TileChecks.FindChestTopLeft(x, y, destroy: false);
			if (player.sign >= 0)
			{
				player.sign = -1;
				Main.editSign = false;
				Main.npcChatText = "";
				SoundEngine.PlaySound(in SoundID.Item11, (Vector2?)new Vector2(-1f, -1f));
			}
			if (Main.editChest)
			{
				Main.editChest = false;
				Main.npcChatText = "";
				SoundEngine.PlaySound(in SoundID.Item12, (Vector2?)new Vector2(-1f, -1f));
			}
			if (player.editedChestName)
			{
				player.editedChestName = false;
				NetMessage.SendData(33, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
			}
			if (Main.netMode == 1)
			{
				if (point.X == player.chestX && point.Y == player.chestY && player.chest >= 0)
				{
					player.chest = -1;
					Recipe.FindRecipes();
					SoundEngine.PlaySound(in SoundID.Item11, (Vector2?)new Vector2(-1f, -1f));
				}
				else
				{
					Main.stackSplit = 600;
					NetMessage.SendData(31, -1, -1, null, point.X, point.Y);
				}
				return;
			}
			int num = Chest.FindChest(point.X, point.Y);
			if (num >= 0)
			{
				Main.stackSplit = 600;
				if (num == player.chest)
				{
					player.chest = -1;
					SoundEngine.PlaySound(in SoundID.Item11, (Vector2?)new Vector2(-1f, -1f));
				}
				else
				{
					player.chest = num;
					player.chestX = point.X;
					player.chestY = point.Y;
					Main.playerInventory = true;
					Main.recBigList = false;
					SoundStyle style = ((player.chest < 0) ? SoundID.Item10 : SoundID.Item12);
					SoundEngine.PlaySound(in style, (Vector2?)new Vector2(-1f, -1f));
				}
				Recipe.FindRecipes();
			}
		}
	}
}
