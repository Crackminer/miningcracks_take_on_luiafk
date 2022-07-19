using miningcracks_take_on_luiafk.Images.Tiles.Collection;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkGlobalTile : GlobalTile
	{
		public override int[] AdjTiles(int type)
		{
			if (LuiafkPlayer.UpdateAdjTiles)
			{
				LuiafkPlayer.UpdateAdjTiles = false;
				Player obj = Main.player[Main.myPlayer];
				obj.adjHoney = true;
				obj.adjLava = true;
				obj.adjWater = true;
				obj.alchemyTable = true;
				return LuiafkMod.TileList;
			}
			return new int[0];
		}

        public override bool CanPlace(int i, int j, int type)
        {
			if (type == ModContent.TileType<TreeHarvesterTile>() || type == ModContent.TileType<CactusHarvesterTile>() || type == ModContent.TileType<FishHarvesterTile>() || type == ModContent.TileType<GemCornHarvesterTile>() || type == ModContent.TileType<PlantHarvesterTile>())
			{
                if (Main.tile[i, j].TileType == ModContent.TileType<TreeHarvesterTile>())		return false;
                if (Main.tile[i, j].TileType == ModContent.TileType<CactusHarvesterTile>())		return false;
                if (Main.tile[i, j].TileType == ModContent.TileType<FishHarvesterTile>())		return false;
                if (Main.tile[i, j].TileType == ModContent.TileType<GemCornHarvesterTile>())	return false;
                if (Main.tile[i, j].TileType == ModContent.TileType<PlantHarvesterTile>())		return false;
			}
            return base.CanPlace(i, j, type);
        }
    }
}
