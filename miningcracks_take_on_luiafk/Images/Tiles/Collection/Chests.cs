using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

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
			Player player = Main.LocalPlayer;
			Tile tile = Main.tile[x, y];
			Main.mouseRightRelease = false;
			int left = x;
			int top = y;
			if (tile.TileFrameX % 36 != 0)
			{
				left--;
			}

			if (tile.TileFrameY != 0)
			{
				top--;
			}

			player.CloseSign();
			player.SetTalkNPC(-1);
			Main.npcChatCornerItem = 0;
			Main.npcChatText = "";
			if (Main.editChest)
			{
				SoundEngine.PlaySound(SoundID.MenuTick);
				Main.editChest = false;
				Main.npcChatText = string.Empty;
			}

			if (player.editedChestName)
			{
				NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
				player.editedChestName = false;
			}

			bool isLocked = Chest.IsLocked(left, top);
			if (Main.netMode == NetmodeID.MultiplayerClient && !isLocked)
			{
				if (left == player.chestX && top == player.chestY && player.chest >= 0)
				{
					player.chest = -1;
					Recipe.FindRecipes();
					SoundEngine.PlaySound(SoundID.MenuClose);
				}
				else
				{
					NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
					Main.stackSplit = 600;
				}
			}
			else
			{
				
				int chest = Chest.FindChest(left, top);
				if (chest >= 0)
				{
					Main.stackSplit = 600;
					if (chest == player.chest)
					{
						player.chest = -1;
						SoundEngine.PlaySound(SoundID.MenuClose);
					}
					else
					{
						SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
						player.OpenChest(left, top, chest);
					}

					Recipe.FindRecipes();
				}
				
			}
		}
	}
}
