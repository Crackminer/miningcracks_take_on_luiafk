using Microsoft.Xna.Framework;
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
            //if (Main.tile[x, y + 1].TileType == TileID.Stone)
            //{
				int tt = Main.tile[x, y].TileType;
				int tt2 = Main.tile[x, y + 1].TileType;
				//Main.NewText("TileID: " + tt + " at Coordinates: " + x + ", " + y, Color.Yellow);
				//Main.NewText("This is one below: TileID: " + tt2 + " at Coordinates: " + x + ", " + (y + 1), Color.Yellow);
			//WorldGen.KillTile(x, y, noItem: true);
			if (tt2 == TileID.Stone)
			{
				bool temp;
				switch (tt)
				{
					case 583:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<TopazCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting TopazCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 584:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<AmethystCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting AmethystCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 585:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<SapphireCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting SapphireCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 586:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<EmeraldCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting EmeraldCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 587:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<RubyCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting RubyCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 588:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<DiamondCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting DiamondCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
					case 589:
						temp = WorldGen.PlaceTile(x, y, ModContent.TileType<AmberCorn>(), mute: true, forced: true);
						//Main.NewText("Tried planting AmberCorn: " + (temp ? "Successful" : "Unsuccessful"), Color.Yellow);
						break;
				}
			}
				//WorldGen.PlaceTile(x, y + 1, 590, mute: true, forced: true, plr: 5);
			//}
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
