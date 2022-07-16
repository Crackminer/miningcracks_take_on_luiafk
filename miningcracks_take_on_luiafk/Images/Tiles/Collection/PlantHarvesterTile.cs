using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class PlantHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
			Defaults.ChestTile(this, "Plant Harvester", ModContent.ItemType<PlantHarvester>(), new Color(255, 255, 255));
		}
	}
}
