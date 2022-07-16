using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.House
{
	public class HouseEnabler : ModTile
	{
		public override void SetStaticDefaults()
		{
						Main.tileSolid[base.Type] = false;
			Main.tileLighted[base.Type] = true;
			TileID.Sets.DisableSmartCursor[1] = false;
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsDoor);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			ModTranslation modTranslation = CreateMapEntryName();
			modTranslation.SetDefault("House Enabler");
			AddMapEntry(new Color(0, 115, 255), modTranslation);
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			if (LuiafkWorld.lightSwitch)
			{
				r = 1.3f;
				g = 1.3f;
				b = 1.3f;
			}
			else
			{
				r = 0f;
				g = 0f;
				b = 0f;
			}
		}
	}
}
