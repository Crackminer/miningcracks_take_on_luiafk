using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using miningcracks_take_on_luiafk.Images.Items.Placeables.Collection;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Collection
{
	public class GemCornHarvesterTile : ChestTiles
	{
		public override void SetStaticDefaults()
		{
			Defaults.ChestTile(this, "Gemcorn Tree Harvester", ModContent.ItemType<GemCornHarvester>(), new Color(37, 36, 36));
		}
	}
}
