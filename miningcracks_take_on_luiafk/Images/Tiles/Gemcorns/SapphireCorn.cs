using Microsoft.Xna.Framework;
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
    public class SapphireCorn : ModTile
	{
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
			TileObjectData.newTile.RandomStyleRange = 2;


			//TileObjectData.newSubTile.CopyFrom(TileObjectData.newTile);
			//TileObjectData.newSubTile.AnchorValidTiles = new int[] { TileType<ExampleSand>() };
			//TileObjectData.addSubTile(1);

			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Sappphire GemSapling");
			AddMapEntry(new Color(0, 0, 255), name);


			TileID.Sets.BreakableWhenPlacing[Type] = false;
			TileID.Sets.CountsAsGemTree[Type] = true;
			TileID.Sets.CommonSapling[Type] = true;
			TileID.Sets.SwaysInWindBasic[Type] = false;
			TileMaterials.SetForTileId(Type, TileMaterials._materialsByName["Plant"]); // Make this tile interact with golf balls in the same way other plants do

			AdjTiles = new int[] { TileID.GemSaplings };
		}

		public override bool CanPlace(int i, int j)
		{
			if (Main.tile[i, j + 1].TileType == TileID.Stone) return true;

			return false;
		}

		public override void RandomUpdate(int i, int j)
		{
			// A random chance to slow down growth
			if (!WorldGen.genRand.NextBool(20))
			{
				return;
			}

			bool growSuccess = WorldGen.GrowTreeWithSettings(i, j, GrowTreeSettings.Profiles.GemTree_Sappphire);
			// A bool to see if the tree growing was sucessful.

			// A flag to check if a player is near the sapling
			bool isPlayerNear = WorldGen.PlayerLOS(i, j);

			//If growing the tree was a sucess and the player is near, show growing effects
			if (growSuccess && isPlayerNear)
			{
				WorldGen.TreeGrowFXCheck(i, j);
			}
		}

		public override void SetSpriteEffects(int i, int j, ref SpriteEffects effects)
		{
			if (i % 2 == 1)
			{
				effects = SpriteEffects.FlipHorizontally;
			}
		}
	}
}
