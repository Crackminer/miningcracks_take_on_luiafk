using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Fishing;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Placeables.Collection
{
	internal static class Harvesting
	{
		private class HarvesterInfo
		{
			internal readonly int tileType;

			internal readonly List<int> chests;

			internal readonly string type;

			internal readonly UpdateFunc initial;

			internal readonly NearbyFunc following;

			internal HarvesterInfo(int tileType, string type, UpdateFunc initial, NearbyFunc following = null)
			{
				this.tileType = tileType;
				this.type = type + " Harvester";
				chests = new List<int>();
				this.initial = initial;
				this.following = following;
			}

			internal void Update()
			{
				for (int i = 0; i < chests.Count; i++)
				{
					int num = chests[i];
					if (Main.chest[num] == null || Main.tile[Main.chest[num].x, Main.chest[num].y].TileType != tileType)
					{
						chests.RemoveAt(i);
						i--;
						continue;
					}
					bool full = false;
					initial(num, this, ref full);
					if (full)
					{
						string text = type;
						if (Main.chest[num].name != "")
						{
							text = text + ": \"" + Main.chest[num].name + "\"";
						}
						text = text + " is full! It's located at: " + TileChecks.CoordsString(Main.chest[num].x, Main.chest[num].y);
						MiscMethods.WriteText(text, Color.Red);
					}
				}
			}
		}

		private delegate void UpdateFunc(int chest, HarvesterInfo harvInfo, ref bool full);

		private delegate bool NearbyFunc(Tile t, int chest, int x, int y);

		internal delegate void TileUpdate(Tile t, int x, int y);

		private static bool crappyPackets;

		private static List<HarvesterInfo> harvInfo;

		internal static int frame;

		private static void CheckLarge(int chest, HarvesterInfo harvInfo, ref bool full)
		{
			Point16 p = default(Point16);
			p.ToWorldCoordinates(Main.chest[chest].x, Main.chest[chest].y);
			for (int i = p.X - 50; i < p.X + 52; i++)
			{
				for (int j = p.Y - 50; j < p.Y + 52; j++)
				{
					if (TileChecks.InGameWorld(i, j))
					{
						Tile tileSafely = Framing.GetTileSafely(i, j);
						if (harvInfo.following(tileSafely, chest, i, j))
						{
							full = true;
						}
					}
				}
			}
		}

		private static void CheckWater(int chest, HarvesterInfo harvInfo, ref bool full)
		{
			CatchFish.FishStuff(ref full, chest);
		}

		internal static void Load()
		{
			PlantHarvesting.modHerbs = new List<Tuple<int, int, int, Func<int>>>();
			PlantHarvesting.modHerbsFuncs = new List<Tuple<int, Func<int, int, Point>, TileUpdate>>();
		}

		internal static void Unload()
		{
			PlantHarvesting.modHerbs = null;
			PlantHarvesting.modHerbsFuncs = null;
			crappyPackets = false;
			harvInfo = null;
		}

		private static void UnbreakChests()
		{
			for (int i = 0; i < Main.maxTilesX; i += 2)
			{
				for (int j = 0; j < Main.maxTilesY; j += 2)
				{
					Tile tileSafely = Framing.GetTileSafely(i, j);
					foreach (HarvesterInfo item in harvInfo)
					{
						if (item.tileType == tileSafely.TileType)
						{
							Point16 point = TileChecks.FindChestTopLeft(i, j, destroy: false);
							if (Chest.FindChest(point.X, point.Y) == -1)
							{
								Chest.CreateChest(point.X, point.Y);
							}
							break;
						}
					}
				}
			}
		}

		internal static void Init(bool unbreak = true)      //TODO: Check if Harvester are working now
		{
			crappyPackets = false;
			harvInfo = new List<HarvesterInfo>
			{
				new HarvesterInfo(((Mod)LuiafkMod.Instance).Find<ModTile>("PlantHarvesterTile").Type, "Plant", CheckLarge, PlantHarvesting.NearbyPlants),
				new HarvesterInfo(((Mod)LuiafkMod.Instance).Find<ModTile>("TreeHarvesterTile").Type, "Tree", CheckLarge, TreeHarvesting.NearbyTrees),
				new HarvesterInfo(((Mod)LuiafkMod.Instance).Find<ModTile>("CactusHarvesterTile").Type, "Cactus", CheckLarge, CactusHarvesting.NearbyCactus),
				new HarvesterInfo(((Mod)LuiafkMod.Instance).Find<ModTile>("FishHarvesterTile").Type, "Fish", CheckWater)
			};
			if (unbreak)
			{
				UnbreakChests();
			}
			frame++;
			if (frame != 60) return;
			frame = 0;
			for (int i = 0; i < Main.chest.Length; i++)
			{
				if (Main.chest[i] == null)
				{
					continue;
				}
				int type = Main.tile[Main.chest[i].x, Main.chest[i].y].TileType;	
				foreach (HarvesterInfo item in harvInfo)
				{
					if (item.tileType == type)
					{
						item.chests.Add(i);
						break;
					}
				}
			}
		}

		internal static void UpdateChests()
		{
			if (crappyPackets)
			{
				Init(unbreak: false);
			}
			foreach (HarvesterInfo item in harvInfo)
			{
				item.Update();
			}
			if (Main.netMode != NetmodeID.Server)
			{
				return;
			}
			for (int i = 0; i < 255; i++)
			{
				Player p = Main.player[i];
				if (((Entity)p).active && !p.dead && p.chest >= 0 && harvInfo.Exists((HarvesterInfo x) => x.chests.Contains(p.chest)))
				{
					ForceUpdateChest(p);
				}
			}
		}

		private static void ForceUpdateChest(Player p)
		{
			int chest = p.chest;
			for (int i = 0; i < 40; i++)
			{
				NetMessage.SendData(32, p.whoAmI, -1, null, chest, i);
			}
			NetMessage.SendData(33, p.whoAmI, -1, null, chest);
			Main.player[p.whoAmI].chest = chest;
			NetMessage.SendData(80, -1, p.whoAmI, null, p.whoAmI, chest);
		}

		internal static int MultiTiles(int x, int y, bool kill, int[] types)
		{
			int count = 0;
			while ((Main.tile[x, y] != null && types.Contains(Main.tile[x, y].TileType)) || (Main.tile[x - 1, y] != null && types.Contains(Main.tile[x - 1, y].TileType)) || (Main.tile[x + 1, y] != null && types.Contains(Main.tile[x + 1, y].TileType)))
			{
				if (Main.tile[x, y] != null && types.Contains(Main.tile[x, y].TileType))
				{
					RemoveOrCountTiles(x, y, kill, ref count);
				}
				if (Main.tile[x - 1, y] != null && types.Contains(Main.tile[x - 1, y].TileType))
				{
					RemoveOrCountTiles(x - 1, y, kill, ref count);
				}
				if (Main.tile[x + 1, y] != null && types.Contains(Main.tile[x + 1, y].TileType))
				{
					RemoveOrCountTiles(x + 1, y, kill, ref count);
				}
				y--;
			}
			return count;
		}

		internal static void RemoveOrCountTiles(int x, int y, bool kill, ref int count)
		{
			if (!kill)
			{
				count++;
			}
			else
			{
				TileChecks.ClearTileWithNet(x, y);
			}
		}

		internal static void MultiFits(int x, int y, int drop, int[] types, int chest, Tile t, TileUpdate updateTile, ref bool full)
		{
			int num = MultiTiles(x, y, kill: false, types);
			int num2 = PutInChest(chest, drop, num);
			if (num2 < num)
			{
				updateTile(t, x, y);
			}
			if (num2 > 0)
			{
				full = true;
			}
		}

		internal static bool SingleFits(int x, int y, int drop, Tile t, int chest, int amount, TileUpdate updateTile)
		{
			int num = PutInChest(chest, drop, amount);
			if (num == amount)
			{
				return false;
			}
			if (num > 0 && num < amount)
			{
				updateTile(t, x, y);
				return false;
			}
			updateTile(t, x, y);
			return true;
		}

		internal static int PutInChest(int chest, int toPlace, int amount)
		{
			for (int i = 0; i < 40; i++)
			{
				Item item = Main.chest[chest].item[i];
				if (item.type == toPlace)
				{
					if (item.stack + amount <= item.maxStack)
					{
						item.stack += amount;
						return 0;
					}
					amount -= item.maxStack - item.stack;
					item.stack = item.maxStack;
				}
			}
			for (int j = 0; j < 40; j++)
			{
				Item item2 = Main.chest[chest].item[j];
				if (item2.IsAir)
				{
					item2.SetDefaults(toPlace);
					item2.stack = amount;
					return 0;
				}
			}
			return amount;
		}

		internal static void HarvestingPacket(int x, int y, Packet type)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write((int)type);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			packet.Send();
		}

		internal static void HandleHarvesting(int x, int y)
		{
			Point16 point = TileChecks.FindChestTopLeft(x, y, destroy: false);
			if (point != Point16.NegativeOne)
			{
				int tileType = Main.tile[point.X, point.Y].TileType;
				foreach (HarvesterInfo item in harvInfo)
				{
					if (item.tileType == tileType)
					{
						item.chests.Add(Chest.FindChest(point.X, point.Y));
						break;
					}
				}
			}
			else
			{
				crappyPackets = true;
			}
		}
	}
}
