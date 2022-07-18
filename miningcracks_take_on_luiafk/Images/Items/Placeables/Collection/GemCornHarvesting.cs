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
			Harvesting.MultiTilesTrees(x, y, kill: true, treeTypes);
			WorldGen.PlaceTile(x, y, TileID.GemSaplings, false, false, -1, (Main.tile[x, y].TileType - 583) * 3);
		}

		internal static int Amount()
        {
			int rand = Main.rand.Next(0, 15);
			return rand;
        }

		internal static bool NearbyGemTrees(Tile t, int chest, int x, int y)
		{
			bool full = false;
			int drop = -1;
			if (treeTypes.Contains(t.TileType))
			{
				drop = ItemID.StoneBlock;
			}
			if (drop != -1)
			{
				Harvesting.MultiFits(x, y - 1, drop, treeTypes, chest, t, UpdateTile, ref full, true);
			}
			return full;
		}
	}
}
