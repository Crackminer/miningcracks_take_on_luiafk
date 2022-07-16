using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class TileChecks
	{
		internal static Point16 PlayerCenterTile(Player player)
		{
									return new Point16((int)(player.Center.X / 16f), (int)(player.Center.Y / 16f));
		}

		internal static int PlayerCenterTileX(Player player)
		{
						return (int)(player.Center.X / 16f);
		}

		internal static int PlayerCenterTileY(Player player)
		{
						return (int)(player.Center.Y / 16f);
		}

		internal static bool InGameWorldLeft(int x)
		{
			return x > 39;
		}

		internal static bool InGameWorldRight(int x)
		{
			return x < Main.maxTilesX - 39;
		}

		internal static bool InGameWorldTop(int y)
		{
			return y > 39;
		}

		internal static bool InGameWorldBottom(int y)
		{
			return y < Main.maxTilesY - 39;
		}

		internal static bool InGameWorld(int x, int y)
		{
			if (x > 39 && x < Main.maxTilesX - 39 && y > 39)
			{
				return y < Main.maxTilesY - 39;
			}
			return false;
		}

		internal static bool InWorldLeft(int x)
		{
			return x >= 0;
		}

		internal static bool InWorldRight(int x)
		{
			return x < Main.maxTilesX;
		}

		internal static bool InWorldTop(int y)
		{
			return y >= 0;
		}

		internal static bool InWorldBottom(int y)
		{
			return y < Main.maxTilesY;
		}

		internal static bool InWorld(int x, int y)
		{
			if (x >= 0 && x < Main.maxTilesX && y >= 0)
			{
				return y < Main.maxTilesY;
			}
			return false;
		}

		internal static bool PlaceGrassTileCheck(int x, int y)
		{
			if ((y <= 0 || WorldGen.SolidTile(x, y - 1)) && (x <= 0 || WorldGen.SolidTile(x - 1, y)))
			{
				if (x < Main.maxTilesX - 1)
				{
					return !WorldGen.SolidTile(x + 1, y);
				}
				return false;
			}
			return true;
		}

		internal static void DestroyChest(int x, int y)
		{
			int num = Chest.FindChest(x, y);
			int number = 1;
			if (num != -1)
			{
				for (int i = 0; i < 40; i++)
				{
					Main.chest[num].item[i] = new Item();
				}
				Main.chest[num] = null;
				if (Main.tile[x, y].TileType == 467)
				{
					number = 5;
				}
				if (Main.tile[x, y].TileType >= 470)
				{
					number = 101;
				}
			}
			for (int j = x; j < x + 2; j++)
			{
				for (int k = y; k < y + 2; k++)
				{
					ClearTile(j, k);
				}
			}
			if (Main.netMode != 0)
			{
				if (num != -1)
				{
					NetMessage.SendData(34, -1, -1, null, number, x, y, 0f, num, Main.tile[x, y].TileType);
				}
				NetMessage.SendTileSquare(-1, x, y, 3);
			}
		}

		internal static int FindChestSafe(int x, int y)
		{
			if (Main.tile[x, y] != null)
			{
				Point16 point = FindChestTopLeft(x, y, destroy: false);
				return Chest.FindChest(point.X, point.Y);
			}
			return Chest.FindChestByGuessing(x, y);
		}

		internal static Point16 FindChestTopLeft(int x, int y, bool destroy)
		{
			if (TileID.Sets.BasicChest[Main.tile[x, y].TileType])
			{
				if (Main.tile[x, y].TileFrameX % 36 != 0)
				{
					x--;
				}
				if (Main.tile[x, y].TileFrameY % 36 != 0)
				{
					y--;
				}
				if (!destroy)
				{
					return new Point16(x, y);
				}
				DestroyChest(x, y);
				return new Point16(x, y);
			}
			return Point16.NegativeOne;
		}

		internal static void ClearLiquid(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			tile.LiquidAmount = 0;
			tile.LiquidType = 3;
			if (Main.netMode == 2)
			{
				NetMessage.sendWater(x, y);
			}
		}

		internal static void ClearTile(int x, int y)
		{
			Main.tile[x, y].ClearTile();
		}

		internal static void ClearWall(int x, int y)
		{
			Main.tile[x, y].Clear(TileDataType.Wall);
		}

		internal static void ClearEverything(int x, int y)
		{
			Main.tile[x, y].ClearEverything();
		}

		internal static void ClearTileWithNet(int x, int y)
		{
			ClearTile(x, y);
			SquareUpdate(x, y);
		}

		internal static void ClearWallWithNet(int x, int y)
		{
			ClearWall(x, y);
			SquareUpdate(x, y);
		}

		internal static void ClearEverythingWithNet(int x, int y)
		{
			ClearEverything(x, y);
			SquareUpdate(x, y);
		}

		internal static void SquareUpdate(int x, int y)
		{
			if (Main.netMode != 0)
			{
				NetMessage.SendTileSquare(-1, x, y, 1);
			}
		}

		internal static bool NoDungeon(int x, int y)
		{
			if (NoBlueDungeon(x, y) && NoGreenDungeon(x, y))
			{
				return NoPinkDungeon(x, y);
			}
			return false;
		}

		internal static bool NoBlueDungeon(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (tile.TileType != 41 && tile.WallType != 94 && tile.WallType != 95)
			{
				return tile.WallType != 7;
			}
			return false;
		}

		internal static bool NoGreenDungeon(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (tile.TileType != 43 && tile.WallType != 98 && tile.WallType != 99)
			{
				return tile.WallType != 8;
			}
			return false;
		}

		internal static bool NoPinkDungeon(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (tile.TileType != 44 && tile.WallType != 96 && tile.WallType != 97)
			{
				return tile.WallType != 9;
			}
			return false;
		}

		internal static bool NoUndergroundDesert(int x, int y)
		{
			int wallType = Main.tile[x, y].WallType;
			if (wallType != 187 && wallType != 220 && wallType != 221)
			{
				return wallType != 222;
			}
			return false;
		}

		internal static bool PlanteraBulb(int x, int y)
		{
			return Main.tile[x, y].TileType == 238;
		}

		internal static bool NoTemple(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (tile.WallType != 87 && tile.TileType != 226)
			{
				if (tile.TileType == 10 && tile.TileFrameY >= 594)
				{
					return tile.TileFrameY > 646;
				}
				return true;
			}
			return false;
		}

		internal static bool Temple(int x, int y)
		{
			return !NoTemple(x, y);
		}

		internal static bool TempleAndGolemIsDead(int x, int y)
		{
			if (!NoTemple(x, y))
			{
				return NPC.downedGolemBoss;
			}
			return false;
		}

		internal static bool NoTempleOrGolemIsDead(int x, int y)
		{
			if (!NoTemple(x, y))
			{
				return NPC.downedGolemBoss;
			}
			return true;
		}

		internal static bool NoOrbOrAltar(int x, int y)
		{
			if (Main.tile[x, y].TileType != 31)
			{
				return Main.tile[x, y].TileType != 26;
			}
			return false;
		}

		internal static int CoordsX(int x)
		{
			return x * 2 - Main.maxTilesX;
		}

		internal static int CoordsY(int y)
		{
			return y * 2 - (int)Main.worldSurface * 2;
		}

		internal static string CoordsString(int x, int y)
		{
			x = x * 2 - Main.maxTilesX;
			y = y * 2 - (int)Main.worldSurface * 2;
			string text = ((x < 0) ? " west, " : " east, ");
			string text2 = ((y < 0) ? " surface." : " underground.");
			x = ((x < 0) ? (x * -1) : x);
			y = ((y < 0) ? (y * -1) : y);
			return x + text + y + text2;
		}

		internal static void PrintCoords(int x, int y, Color color, string location)
		{
									MiscMethods.WriteText(location, color);
			MiscMethods.WriteText(CoordsString(x, y), color);
		}

		internal static void TileSafe(int x, int y)
		{
			if (Main.tile[x, y] == null)
			{
				Main.tile[x, y].ResetToType(0);
			}
		}

		internal static bool TileNull(int x, int y)
		{
			return Main.tile[x, y] == null;
		}

		internal static bool SolidTile(int x, int y)
		{
			Tile tile = Main.tile[x, y];
			if (!TileNull(x, y) && tile.HasTile && Main.tileSolid[tile.TileType] && !Main.tileSolidTop[tile.TileType] && !tile.IsHalfBlock && tile.Slope == SlopeType.Solid)
			{
				return !tile.IsActuated;
			}
			return false;
		}

		internal static bool SearchBelow(Player player, Func<int, int, bool> toSearch, Color color, string located, int gap)
		{
									int num = PlayerCenterTileX(player);
			int num2 = PlayerCenterTileY(player);
			for (int i = 0; InGameWorldLeft(num - i) || InGameWorldRight(num + i); i += gap)
			{
				for (int j = num2; InGameWorldBottom(j); j += gap)
				{
					int num3 = num - i;
					int num4 = num + i;
					if (InGameWorldLeft(num3))
					{
						TileSafe(num3, j);
						if (toSearch(num3, j))
						{
							PrintCoords(num3, j, color, located);
							return true;
						}
					}
					if (InGameWorldRight(num4))
					{
						TileSafe(num4, j);
						if (toSearch(num4, j))
						{
							PrintCoords(num4, j, color, located);
							return true;
						}
					}
				}
			}
			return false;
		}
	}
}
