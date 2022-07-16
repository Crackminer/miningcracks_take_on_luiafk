using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class FishHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
						Defaults.ChestTile(this, "Fish Harvester", base.Mod.Find<ModTile>("FishHarvesterTile").Type, new Color(0, 255, 0));
		}
	}
}
