using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class TreeHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
						Defaults.ChestTile(this, "Tree Harvester", base.Mod.Find<ModTile>("TreeHarvesterTile").Type, new Color(255, 0, 255));
		}
	}
}
