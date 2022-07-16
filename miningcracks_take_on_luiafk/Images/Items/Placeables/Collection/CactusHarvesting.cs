using miningcracks_take_on_luiafk.Utility;
using Terraria;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	internal static class CactusHarvesting
	{
		private static readonly int[] cactusType = new int[1] { 80 };

		private static void UpdateTile(Tile t, int x, int y)
		{
			Harvesting.MultiTiles(x, y, kill: true, cactusType);
		}

		internal static bool NearbyCactus(Tile t, int chest, int x, int y)
		{
			bool full = false;
			int num = -1;
			if (t.TileType == 80)
			{
				FindBase(ref x, ref y);
				num = 276;
			}
			else if (t.TileType == 227 && t.TileFrameX == 204)
			{
				TileChecks.ClearTileWithNet(x, y);
			}
			if (num != -1)
			{
				Harvesting.MultiFits(x, y, num, cactusType, chest, t, UpdateTile, ref full);
			}
			return full;
		}

		private static void FindBase(ref int x, ref int y)
		{
			if (Main.tile[x - 1, y] != null && Main.tile[x - 1, y].TileType == 80 && CenterFrame(Main.tile[x - 1, y]))
			{
				x--;
			}
			else if (Main.tile[x + 1, y] != null && Main.tile[x + 1, y].TileType == 80 && CenterFrame(Main.tile[x + 1, y]))
			{
				x++;
			}
			if (Main.tile[x, y] != null && CenterFrame(Main.tile[x, y]))
			{
				while (Main.tile[x, y + 1] != null && Main.tile[x, y + 1].TileType == 80)
				{
					y++;
				}
			}
		}

		private static bool CenterFrame(Tile t)
		{
			if (t.TileFrameX != 0 && t.TileFrameX != 18 && t.TileFrameX != 72)
			{
				return t.TileFrameX == 90;
			}
			return true;
		}
	}
}
