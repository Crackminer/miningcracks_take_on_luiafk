using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Altars
{
	public class CorruptionAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Defaults.AltarTile(this, "Demon Altar");
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			float num = (float)Main.rand.Next(-5, 6) * 0.0025f;
			r = 0.31f + num;
			g = 0.1f;
			b = 0.44f + num * 2f;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
												if (Main.rand.NextBool(20))
			{
				Dust.NewDust(new Vector2((float)(i << 4), (float)(j << 4)), 16, 16, 14, 0f, 0f, 100);
			}
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			type = 14;
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 20;
		}
	}
}
