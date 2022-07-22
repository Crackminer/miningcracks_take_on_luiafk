using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	internal static class GemCornHarvesting
	{
		private static readonly int[] treeTypes = new int[7] { 583, 584, 585, 586, 587, 588, 589 };

		private static void UpdateTile(Tile t, int x, int y)
		{
			int tt = Main.tile[x, y].TileType;
			if (tt == 590) return;
			Harvesting.MultiTilesTrees(x, y, kill: true, treeTypes);
			tt = Main.tile[x, y].TileType;
			int tt2 = Main.tile[x, y + 1].TileType;
			if (tt2 == TileID.Stone)
			{
				int rnd;
				switch (tt)
				{
					case 583:
						rnd = Main.rand.Next(0, 2);
						break;
					case 584:
						rnd = Main.rand.Next(3, 5);
						break;
					case 585:
						rnd = Main.rand.Next(6, 8);
						break;
					case 586:
						rnd = Main.rand.Next(9, 11);
						break;
					case 587:
						rnd = Main.rand.Next(12, 14);
						break;
					case 588:
						rnd = Main.rand.Next(15, 17);
						break;
					case 589:
						rnd = Main.rand.Next(18, 20);
						break;
					default:	return;
				}
				WorldGen.Place1x2(x, y, 590, 0);
				Main.tile[x, y].TileFrameX += (short)(rnd * 18);
				Main.tile[x, y - 1].TileFrameX += (short)(rnd * 18);
				if (Main.netMode != 0) NetMessage.SendObjectPlacment(-1, x, y, 590, 0, rnd, 0, 0);
			}
		}

		internal static bool NearbyGemTrees(Tile t, int chest, int x, int y)
		{
			bool full = false;
			int drop = -1;
			if (treeTypes.Contains(t.TileType))
			{
				StoneTreeType(ref x, ref y, ref drop);
			}
			if (drop != -1)
			{
				Harvesting.MultiFits(x, y - 1, drop, treeTypes, chest, t, UpdateTile, ref full, true);
			}
			return full;
		}

		internal static void StoneTreeType(ref int x, ref int y, ref int drop)
        {
			while (!Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType])
			{
				y++;
				TileChecks.TileSafe(x, y);
			}
			if(Main.tile[x, y].HasTile)
            {
				drop = 1;
            }
		}
	}
}
