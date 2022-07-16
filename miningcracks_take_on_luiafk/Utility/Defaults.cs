using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class Defaults
	{
		internal static void Storage(Item item, int drop)
		{
			Base(item);
			item.maxStack = 9999;
			item.useStyle = 1;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useTurn = true;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = drop;
		}

		internal static void Solutions(Item item, int shoot, bool consumable = false)
		{
			item.shoot = shoot;
			item.consumable = consumable;
			item.ammo = AmmoID.Solution;
			Base(item);
		}

		internal static void CloneAmmoThrown(Item item, int type, bool usable = false)
		{
			Clone(item, type);
			item.createTile = -1;
			if (!usable)
			{
				item.useStyle = 0;
			}
		}

		internal static void Clone(Item item, int type)
		{
			item.CloneDefaults(type);
			Base(item);
			item.consumable = false;
		}

		internal static void UnlUse(Item item, int speed = 20)
		{
			item.useStyle = 4;
			item.useAnimation = speed;
			item.useTime = speed;
			item.autoReuse = false;
			Base(item);
		}

		internal static void ChestMaterials(Item item)
		{
			Base(item);
			item.maxStack = 9999;
			item.value = 10000;
		}

		internal static void Base(Item item)
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 1;
			item.value = 1;
			item.rare = 10;
		}

		internal static void AltarTile(ModTile tile, string tileName)
		{
						Main.tileLighted[tile.Type] = true;
			Main.tileFrameImportant[tile.Type] = true;
			Main.tileNoAttach[tile.Type] = true;
			Main.tileSolidTop[tile.Type] = false;
			Main.tileSolid[tile.Type] = false;
			Main.tileLavaDeath[tile.Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.CoordinateHeights = new int[2] { 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(tile.Type);
			ModTranslation modTranslation = tile.CreateMapEntryName();
			modTranslation.SetDefault(tileName);
			tile.AddMapEntry(new Color(175, 75, 255), modTranslation);
			tile.AdjTiles = new int[1] { 26 };
		}

		internal static void ChestTile(ModTile tile, string chestName, int drop, Color c)
		{
						Main.tileSpelunker[tile.Type] = true;
			Main.tileContainer[tile.Type] = true;
			Main.tileShine[tile.Type] = 1200;
			Main.tileShine2[tile.Type] = true;
			Main.tileFrameImportant[tile.Type] = true;
			Main.tileNoAttach[tile.Type] = true;
			TileID.Sets.BasicChest[tile.Type] = true;
			TileID.Sets.HasOutlines[tile.Type] = true;
			TileObjectData.newTile.FullCopyFrom(21);
			TileObjectData.addTile(tile.Type);
			tile.AdjTiles = new int[1] { 21 };
			tile.ContainerName.SetDefault(chestName);
			tile.ChestDrop = drop;
			ModTranslation modTranslation = tile.CreateMapEntryName();
			modTranslation.SetDefault(chestName);
			tile.AddMapEntry(c, modTranslation, Chests.MapChestName);
		}
	}
}
