using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.House
{
	public class HouseEnablerDark : ModTile
	{
		public override void SetStaticDefaults()
		{
						Main.tileSolid[base.Type] = false;
			Main.tileLighted[base.Type] = false;
			TileID.Sets.DisableSmartCursor[1] = false;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation modTranslation = CreateMapEntryName();
			modTranslation.SetDefault("House Enabler (No Light)");
			AddMapEntry(new Color(0, 115, 255), modTranslation);
		}
	}
}
