using System;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Projectiles
{
	public class DarkGreenSolutionProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dark Green Solution");
		}

		public override void SetDefaults()
		{
			base.Projectile.width = 6;
			base.Projectile.height = 6;
			base.Projectile.aiStyle = -1;
			base.Projectile.friendly = true;
			base.Projectile.alpha = 255;
			base.Projectile.penetrate = -1;
			base.Projectile.extraUpdates = 2;
			base.Projectile.tileCollide = false;
			base.Projectile.ignoreWater = true;
		}

		public override void AI()
		{
																		if (base.Projectile.owner == Main.myPlayer)
			{
				Convert((int)(base.Projectile.position.X + (float)(base.Projectile.width / 2)) / 16, (int)(base.Projectile.position.Y + (float)(base.Projectile.height / 2)) / 16, 2);
			}
			if (base.Projectile.timeLeft > 133)
			{
				base.Projectile.timeLeft = 133;
			}
			if (base.Projectile.ai[0] > 7f)
			{
				float num = 1f;
				if (base.Projectile.ai[0] == 8f)
				{
					num = 0.2f;
				}
				else if (base.Projectile.ai[0] == 9f)
				{
					num = 0.4f;
				}
				else if (base.Projectile.ai[0] == 10f)
				{
					num = 0.6f;
				}
				else if (base.Projectile.ai[0] == 11f)
				{
					num = 0.8f;
				}
				base.Projectile.ai[0] += 1f;
				int num2 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, 111, base.Projectile.velocity.X * 0.2f, base.Projectile.velocity.Y * 0.2f, 100, new Color(50, 255, 0));
				Main.dust[num2].noGravity = true;
				Main.dust[num2].scale *= 1.75f;
				Dust obj = Main.dust[num2];
				obj.velocity *= 2f;
				Main.dust[num2].scale *= num;
			}
			else
			{
				base.Projectile.ai[0] += 1f;
			}
			base.Projectile.rotation += 0.3f * (float)base.Projectile.direction;
		}

		private static void Convert(int x, int y, int size)
		{
			for (int i = x - size; i <= x + size; i++)
			{
				for (int j = y - size; j <= y + size; j++)
				{
					if (!WorldGen.InWorld(i, j, 1) || Math.Abs(i - x) + Math.Abs(j - y) >= 6)
					{
						continue;
					}
					Tile tile = Main.tile[i, j];
					int tileType = tile.TileType;
					int wallType = tile.WallType;
					if (wallType != 0)
					{
						if (wallType != 64 && wallType != 71 && ((wallType >= 63 && wallType < 82) || wallType == 40 || wallType == 14 || wallType == 2))
						{
							tile.WallType = 64;
							WorldGen.SquareWallFrame(i, j);
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else if (wallType != 64 && (wallType == 1 || wallType == 3 || wallType == 28 || wallType == 83 || wallType == 64 || wallType == 71))
						{
							tile.WallType = 64;
							WorldGen.SquareWallFrame(i, j);
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else
						{
							switch (wallType)
							{
							case 216:
							case 217:
							case 218:
							case 219:
								tile.WallType = 64;
								WorldGen.SquareWallFrame(i, j);
								NetMessage.SendTileSquare(-1, i, j, 1);
								break;
							case 187:
							case 220:
							case 221:
							case 222:
								tile.WallType = 64;
								WorldGen.SquareWallFrame(i, j);
								NetMessage.SendTileSquare(-1, i, j, 1);
								break;
							}
						}
					}
					if ((tileType != 59 || tileType != 60) && (tileType == 1 || (tileType >= 179 && tileType < 184) || tileType == 381 || tileType == 25 || tileType == 117 || tileType == 203 || tileType == 57 || tileType == 189))
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if ((tileType != 59 || tileType != 60) && (tileType == 2 || tileType == 23 || tileType == 60 || tileType == 199 || tileType == 109 || tileType == 70 || tileType == 196))
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if ((tileType != 59 || tileType != 60) && (tileType == 161 || tileType == 163 || tileType == 200 || tileType == 164))
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if ((tileType != 59 || tileType != 60) && (tileType == 53 || tileType == 112 || tileType == 234 || tileType == 116))
					{
						if (Main.tile[i, j - 1].TileType != 80)
						{
							tile.TileType = 59;
							if (TileChecks.PlaceGrassTileCheck(i, j))
							{
								tile.TileType = 60;
							}
							WorldGen.SquareTileFrame(i, j);
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else
						{
							tile.TileType = 53;
							WorldGen.SquareTileFrame(i, j);
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
					}
					else if ((tileType != 59 || tileType != 60) && (tileType == 397 || tileType == 398 || tileType == 399 || tileType == 402))
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if ((tileType != 59 || tileType != 60) && (tileType == 396 || tileType == 400 || tileType == 403 || tileType == 401))
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType == 70)
					{
						tile.TileType = 59;
						tile.TileType = 60;
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (TileID.Sets.Conversion.Thorn[tileType] && tileType != 69)
					{
						tile.TileType = 69;
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					if (tileType == 0 || tileType == 59 || tileType == 147)
					{
						tile.TileType = 59;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = 60;
						}
						WorldGen.SquareTileFrame(i, j);
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
				}
			}
		}
	}
}
