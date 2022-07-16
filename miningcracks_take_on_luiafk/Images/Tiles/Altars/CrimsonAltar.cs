using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Tiles.Altars
{
	public class CrimsonAltar : ModTile
	{
		public override void SetStaticDefaults()
		{
			Defaults.AltarTile(this, "Crimson Altar");
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			float num = (float)Main.rand.Next(-5, 6) * 0.0025f;
			r = 0.5f + num * 2f;
			g = 0.2f + num;
			b = 0.1f;
		}

		public override void NearbyEffects(int i, int j, bool closer)
		{
																					if (Main.rand.NextBool(20))
			{
				Dust obj = Main.dust[Dust.NewDust(new Vector2((float)(i << 4), (float)(j << 4)), 16, 16, 5, 0f, 0f, 100)];
				obj.scale = 1.5f;
				obj.noGravity = true;
				obj.velocity *= 0.75f;
			}
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			type = 5;
			return true;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = 20;
		}
	}
}
