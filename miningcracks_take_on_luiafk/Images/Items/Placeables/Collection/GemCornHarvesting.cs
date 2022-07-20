using miningcracks_take_on_luiafk.Images.Tiles.Gemcorns;
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
            if (Main.tile[x, y + 2].TileType == 1)
            {
                switch(Main.tile[x, y + 1].TileType)
                {
					case 583: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<TopazCorn>(), mute: true, forced: true); break;
					case 584: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<AmethystCorn>(), mute: true, forced: true); break;
					case 585: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<SapphireCorn>(), mute: true, forced: true); break;
					case 586: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<EmeraldCorn>(), mute: true, forced: true); break;
					case 587: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<RubyCorn>(), mute: true, forced: true); break;
					case 588: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<DiamondCorn>(), mute: true, forced: true); break;
					case 589: WorldGen.PlaceTile(x, y + 1, ModContent.TileType<AmberCorn>(), mute: true, forced: true); break;
				}
				//WorldGen.PlaceTile(x, y + 1, 590, mute: true, forced: true, plr: 5);
			}
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
