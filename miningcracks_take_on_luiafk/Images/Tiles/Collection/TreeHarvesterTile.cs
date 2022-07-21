using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class TreeHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
			Defaults.ChestTile(this, "Tree Harvester", ModContent.ItemType<TreeHarvester>(), new Color(255, 0, 255));
		}		
	}
}
