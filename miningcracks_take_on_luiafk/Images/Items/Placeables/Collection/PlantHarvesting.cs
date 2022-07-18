using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	internal static class PlantHarvesting
	{
		internal static List<Tuple<int, int, int, Func<int>>> modHerbs;

		internal static List<Tuple<int, Func<int, int, Point>, Harvesting.TileUpdate>> modHerbsFuncs;

		private static void UpdateTile(Tile t, int x, int y)
		{
			if (t.TileType >= 470)
			{
				t.TileFrameX = 0;
			}
			else
			{
				t.TileType = 82;
			}
			NetMessage.SendTileSquare(-1, x, y, 1);
		}

		internal static int Amount()
		{
			return Main.rand.Next(1, 3);
		}

		private static bool ModBloom(int chest, int x, int y, Tile t)
		{
			foreach (Tuple<int, int, int, Func<int>> modHerb in modHerbs)
			{
				if (modHerb.Item1 == t.TileType && modHerb.Item2 == t.TileFrameX)
				{
					return Harvesting.SingleFits(x, y, modHerb.Item3, t, chest, modHerb.Item4(), UpdateTile);
				}
			}
			foreach (Tuple<int, Func<int, int, Point>, Harvesting.TileUpdate> modHerbsFunc in modHerbsFuncs)
			{
				if (modHerbsFunc.Item1 == t.TileType)
				{
					Point val = modHerbsFunc.Item2(x, y);
					if (val.X < 0)
					{
						break;
					}
					return Harvesting.SingleFits(x, y, val.X, t, chest, val.Y, modHerbsFunc.Item3 ?? new Harvesting.TileUpdate(UpdateTile));
				}
			}
			return true;
		}

		private static bool VanillaBloom(Tile t, int chest, int x, int y)
		{
			int num = t.TileFrameX / 18;
			int drop = 313 + num;
			if (num == 6)
			{
				drop = 2358;
			}
			if (t.TileType == 84 || (num == 0 && Main.dayTime) || (num == 1 && !Main.dayTime) || (num == 3 && !Main.dayTime && (Main.bloodMoon || Main.moonPhase == 0)) || (num == 4 && (Main.raining || Main.cloudAlpha > 0f)) || (num == 5 && !Main.raining && Main.dayTime && Main.time > 40500.0))
			{
				return Harvesting.SingleFits(x, y, drop, t, chest, Amount(), UpdateTile);
			}
			return true;
		}

		internal static bool NearbyPlants(Tile t, int chest, int x, int y)
		{
			bool result = false;
			if (t.TileType >= 470)
			{
				if (!ModBloom(chest, x, y, t))
				{
					result = true;
				}
			}
			else if ((t.TileType == 83 || t.TileType == 84) && !VanillaBloom(t, chest, x, y))
			{
				result = true;
			}
			return result;
		}
	}
}
