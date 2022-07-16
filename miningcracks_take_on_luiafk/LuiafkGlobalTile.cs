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
	}
}
