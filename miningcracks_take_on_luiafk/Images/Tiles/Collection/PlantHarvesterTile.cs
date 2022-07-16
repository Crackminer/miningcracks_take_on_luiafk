using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class PlantHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
						Defaults.ChestTile(this, "Plant Harvester", base.Mod.Find<ModTile>("PlantHarvesterTile").Type, new Color(255, 255, 255));
		}
	}
}
