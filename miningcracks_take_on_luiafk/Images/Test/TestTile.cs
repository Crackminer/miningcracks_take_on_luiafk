using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace miningcracks_take_on_luiafk.Images.Test
{
	public class TestTile : ModTile
	{
		public override void SetStaticDefaults()
		{
						Main.tileFrameImportant[base.Type] = true;
			Main.tileNoAttach[base.Type] = true;
			Main.tileLavaDeath[base.Type] = true;
			Main.tileOreFinderPriority[base.Type] = 9000;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.CoordinateHeights = new int[5] { 16, 16, 16, 16, 18 };
			TileObjectData.addTile(base.Type);
			ModTranslation modTranslation = CreateMapEntryName();
			modTranslation.SetDefault("Test Tile");
			AddMapEntry(new Color(200, 200, 200), modTranslation);
			base.AdjTiles = new int[3] { 18, 16, 247 };
		}
	}
}
