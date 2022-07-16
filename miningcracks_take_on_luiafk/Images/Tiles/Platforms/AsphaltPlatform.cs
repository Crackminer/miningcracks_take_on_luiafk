using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace miningcracks_take_on_luiafk.Images.Tiles.Platforms
{
	public class AsphaltPlatform : ModTile
	{
		public override void SetStaticDefaults()
		{
						Main.tileLighted[base.Type] = true;
			Main.tileFrameImportant[base.Type] = true;
			Main.tileSolidTop[base.Type] = true;
			Main.tileSolid[base.Type] = true;
			Main.tileNoAttach[base.Type] = true;
			Main.tileTable[base.Type] = true;
			Main.tileLavaDeath[base.Type] = false;
			TileID.Sets.Platforms[base.Type] = true;
			TileObjectData.newTile.CoordinateHeights = new int[1] { 16 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleMultiplier = 27;
			TileObjectData.newTile.StyleWrapLimit = 27;
			TileObjectData.newTile.UsesCustomCanPlace = false;
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.addTile(base.Type);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			ModTranslation modTranslation = CreateMapEntryName();
			modTranslation.SetDefault("Asphalt Platform");
			AddMapEntry(new Color(0, 0, 0), modTranslation);
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			type = 109;
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 10;
		}

		public override bool HasWalkDust()
		{
			return true;
		}

		public override void WalkDust(ref int dustType, ref bool makeDust, ref Color color)
		{
			dustType = 109;
		}

		public override void FloorVisuals(Player player)
		{
			player.powerrun = true;
		}
	}
}
