using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	internal static class TreeHarvesting
	{
		private static readonly int[] treeTypes = new int[4] { 5, 323, 596, 616 };

		private static void UpdateTile(Tile t, int x, int y)
		{
			Harvesting.MultiTilesTrees(x, y, kill: true, treeTypes);
			if (Main.tile[x, y + 1].TileType != 60)
			{
				WorldGen.PlaceTile(x, y, 20);
				if (Main.netMode != 0) NetMessage.SendObjectPlacment(-1, x, y, 20, 0, 0, 0, 0);
			}
		}

		internal static bool NearbyTrees(Tile t, int chest, int x, int y)
		{
			bool full = false;
			int drop = -1;
			if (t.TileType == 5 || t.TileType == 596 || t.TileType == 616)
            {
                TreeType(ref x, ref y, ref drop);
            }
            else if (t.TileType == 323)
			{
				PalmTreeType(ref x, ref y, ref drop);
			}
			if (drop != -1)
			{
				Harvesting.MultiFits(x, y - 1, drop, treeTypes, chest, t, UpdateTile, ref full, true);
			}
			return full;
		}

		private static void PalmTreeType(ref int x, ref int y, ref int drop)
		{
			drop = 2504;
			while (!Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType])
			{
				y++;
				TileChecks.TileSafe(x, y);
			}
			if (Main.tile[x, y].HasTile)
			{
				ushort tileType = Main.tile[x, y].TileType;
				switch (tileType)
				{
				case 112:
					drop = 619;
					break;
				case 116:
					drop = 621;
					break;
				case 234:
					drop = 911;
					break;
				}
				TileLoader.DropPalmTreeWood(tileType, ref drop);
			}
		}

		private static void TreeType(ref int x, ref int y, ref int drop)
		{
			Tile tile = Main.tile[x, y];
			drop = 9;
			if (tile.TileFrameX == 66 && tile.TileFrameY <= 45)
			{
				x++;
			}
			if (tile.TileFrameX == 88 && tile.TileFrameY >= 66 && tile.TileFrameY <= 110)
			{
				x--;
			}
			if (tile.TileFrameX == 22 && tile.TileFrameY >= 132 && tile.TileFrameY <= 176)
			{
				x--;
			}
			if (tile.TileFrameX == 44 && tile.TileFrameY >= 132 && tile.TileFrameY <= 176)
			{
				x++;
			}
			if (tile.TileFrameX == 44 && tile.TileFrameY >= 198)
			{
				x++;
			}
			if (tile.TileFrameX == 66 && tile.TileFrameY >= 198)
			{
				x--;
			}
			while (!Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType])
			{
				y++;
				TileChecks.TileSafe(x, y);
			}
			if (Main.tile[x, y].HasTile)
			{
				ushort tileType = Main.tile[x, y].TileType;
				switch (tileType)
				{
				case 23:
					drop = 619;
					break;
				case 60:
					drop = 620;
					break;
				case 109:
					drop = 621;
					break;
				case 70:
					drop = 183;
					break;
				case 147:
					drop = 2503;
					break;
				case 199:
					drop = 911;
					break;
				}
				TileLoader.DropTreeWood(tileType, ref drop);
			}
		}
	}
}
