/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.Metadata;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.WorldGen;

namespace miningcracks_take_on_luiafk.Images.Tiles.Gemcorns
{
    public class GemcornTile : ModTile
    {
		private readonly int type;

		public GemcornTile(int type)
        {
            this.type = type;
        }

        public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;

			TileObjectData.newTile.Width = 1;
			TileObjectData.newTile.Height = 2;
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
			TileObjectData.newTile.CoordinateWidth = 16;
			TileObjectData.newTile.CoordinatePadding = 2;
			TileObjectData.newTile.AnchorValidTiles = new[] { (int)TileID.Stone };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.DrawFlipHorizontal = true;
			TileObjectData.newTile.WaterPlacement = LiquidPlacement.NotAllowed;
			TileObjectData.newTile.LavaDeath = true;
			if(type != 7)	TileObjectData.newTile.RandomStyleRange = 3;
			else			TileObjectData.newTile.RandomStyleRange = 6;
			

			//TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			//TileObjectData.newSubTile.AnchorValidTiles = new int[] { TileType<ExampleSand>() };
			//TileObjectData.addSubTile(1);

			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			switch(type)
            {
				case 1:
					name.SetDefault("TopazGemSapling");
					AddMapEntry(new Color(255, 255, 0), name);
					break;
				case 2:
					name.SetDefault("AmethystGemSapling");
					AddMapEntry(new Color(255, 0, 255), name);
					break;
				case 3:
					name.SetDefault("SapphireGemSapling");
					AddMapEntry(new Color(0, 0, 255), name);
					break;
				case 4:
					name.SetDefault("EmeraldGemSapling");
					AddMapEntry(new Color(0, 204, 0), name);
					break;
				case 5:
					name.SetDefault("RubyGemSapling");
					AddMapEntry(new Color(255, 0, 0), name);
					break;
				case 6:
					name.SetDefault("DiamondGemSapling");
					AddMapEntry(new Color(0, 255, 255), name);
					break;
				case 7:
					name.SetDefault("AmberGemSapling");
					AddMapEntry(new Color(255, 153, 51), name);
					break;
				default:
					name.SetDefault("GemSapling");
					AddMapEntry(new Color(200, 200, 200), name);
					break;
			}
			

			TileID.Sets.TreeSapling[Type] = true;
			TileID.Sets.CommonSapling[Type] = true;
			TileID.Sets.SwaysInWindBasic[Type] = true;
			TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]); // Make this tile interact with golf balls in the same way other plants do

			AdjTiles = new int[] { TileID.GemSaplings };
		}

		public override void RandomUpdate(int i, int j)
		{
			// A random chance to slow down growth
			if (!WorldGen.genRand.NextBool(20))
			{
				return;
			}

			Tile tile = Framing.GetTileSafely(i, j); // Safely get the tile at the given coordinates
			bool growSuccess;
			switch(type)
            {
				case 1: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Topaz); break;
				case 2: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Amethyst); break;
				case 3: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Sappphire); break;
				case 4: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Emerald); break;
				case 5: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Ruby); break;
				case 6: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Diamond); break;
				case 7: growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Amber); break;
				default: growSuccess = false; break;
			}
			 // A bool to see if the tree growing was sucessful.

			// Style 0 is for the ExampleTree sapling, and style 1 is for ExamplePalmTree, so here we check frameX to call the correct method.
			// Any pixels before 54 on the tilesheet are for ExampleTree while any pixels above it are for ExamplePalmTree
			/*if (tile.TileFrameX < 54)
			{
				growSucess = WorldGen.GrowTree(i, j);
			}
			else
			{
				growSucess = WorldGen.GrowPalmTree(i, j);
			}*/

			// A flag to check if a player is near the sapling
			/*bool isPlayerNear = WorldGen.PlayerLOS(i, j);

			//If growing the tree was a sucess and the player is near, show growing effects
			if (growSuccess && isPlayerNear)
			{
				WorldGen.TreeGrowFXCheck(i, j);
			}
		}*/

		/*public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
		}*/
/*	}
}*/
