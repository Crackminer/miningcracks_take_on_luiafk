using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class CactusHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
						Defaults.ChestTile(this, "Cactus Harvester", base.Mod.Find<ModTile>("CactusHarvesterTile").Type, new Color(255, 255, 0));
		}
	}
}
