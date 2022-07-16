using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;

namespace miningcracks_take_on_luiafk.Images.Items.Glowsticks
{
	public class UnlimitedSpelunkerGlowstick : Glowstick
	{
		public UnlimitedSpelunkerGlowstick()
			: base("Spelunker ", 473, new Vector3(1.05f, 0.95f, 0.55f), 3002)
		{
		}

		protected override void HoldingItem(Player player)
		{
																																				base.HoldingItem(player);
			player.spelunkerTimer++;
			if (player.spelunkerTimer < 10)
			{
				return;
			}
			player.spelunkerTimer = 0;
			int num = 30;
			int num2 = (int)player.Center.X >> 4;
			int num3 = (int)player.Center.Y >> 4;
			Vector2 v = default(Vector2);
			for (int i = num2 - num; i <= num2 + num; i++)
			{
				for (int j = num3 - num; j <= num3 + num; j++)
				{
					if (!Main.rand.NextBool(4))
					{
						continue;
					}
					v.ToWorldCoordinates(num2 - i, num3 - j);
					if (!TileChecks.InWorld(i, j) || Main.tile[i, j] == null || !Main.tile[i, j].HasTile || !(((Vector2)(v)).LengthSquared() < 900f))
					{
						continue;
					}
					Tile tile = Main.tile[i, j];
					bool flag = false;
					if (tile.TileType == 185 && tile.TileFrameY == 18)
					{
						if (tile.TileFrameX >= 576 && tile.TileFrameX <= 882)
						{
							flag = true;
						}
					}
					else if (tile.TileType == 186 && tile.TileFrameX >= 864 && tile.TileFrameX <= 1170)
					{
						flag = true;
					}
					if (flag || Main.tileSpelunker[tile.TileType] || (Main.tileAlch[tile.TileType] && tile.TileType != 82))
					{
						Dust obj = Main.dust[Dust.NewDust(new Vector2((float)(i << 4), (float)(j << 4)), 16, 16, 204, 0f, 0f, 150, default(Color), 0.3f)];
						obj.fadeIn = 0.75f;
						obj.velocity *= 0.1f;
						obj.noLight = true;
					}
				}
			}
		}
	}
}
