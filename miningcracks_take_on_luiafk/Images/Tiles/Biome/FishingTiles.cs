using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Biome
{
	public abstract class FishingTiles : ModTile
	{
		public override void SetStaticDefaults()
		{
						Main.tileSolid[base.Type] = true;
			Main.tileLighted[base.Type] = true;
			Main.tileMerge[base.Type][161] = true;
			Main.tileMerge[161][base.Type] = true;
			Main.tileMerge[base.Type][117] = true;
			Main.tileMerge[117][base.Type] = true;
			Main.tileMerge[base.Type][164] = true;
			Main.tileMerge[164][base.Type] = true;
			Main.tileMerge[base.Type][25] = true;
			Main.tileMerge[25][base.Type] = true;
			Main.tileMerge[base.Type][203] = true;
			Main.tileMerge[203][base.Type] = true;
			Main.tileMerge[base.Type][200] = true;
			Main.tileMerge[200][base.Type] = true;
			Main.tileMerge[base.Type][163] = true;
			Main.tileMerge[163][base.Type] = true;
			AddMapEntry(new Color(0, 115, 255));
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1.3f;
			g = 1.3f;
			b = 1.3f;
		}
	}
}
