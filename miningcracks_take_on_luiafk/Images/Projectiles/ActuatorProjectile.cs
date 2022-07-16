using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Projectiles
{
	public class ActuatorProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Actuators");
		}

		public override void SetDefaults()
		{
			base.Projectile.width = 10;
			base.Projectile.height = 10;
			base.Projectile.aiStyle = -1;
			base.Projectile.friendly = true;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.penetrate = -1;
		}

		public override bool? CanDamage()
		{
			return false;
		}

		public override void AI()
		{
			ProjAIs.WireProj(base.Projectile);
		}

		public override void Kill(int timeLeft)
		{
																											if (base.Projectile.localAI[0] == 1f && base.Projectile.owner == Main.myPlayer)
			{
				Player player = Main.player[base.Projectile.owner];
				Point ps = Utils.ToPoint(new Vector2(base.Projectile.ai[0], base.Projectile.ai[1]));
				Point pe = base.Projectile.Center.ToTileCoordinates();
				WirePlace.MassActuatorOperation(player, ps, pe, player.direction == 1);
			}
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverPlayers, List<int> drawCacheProjsOverWiresUI)
		{
			drawCacheProjsOverWiresUI.Add(base.Projectile.whoAmI);
		}

		public override bool PreDraw(ref Color lightColor)
		{
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																			Player player = Main.player[base.Projectile.owner];
			Point val = Utils.ToPoint(new Vector2(base.Projectile.ai[0], base.Projectile.ai[1]));
			Point val2 = base.Projectile.Center.ToTileCoordinates();
			Color val3 = default(Color);
			val3 = new(128, 128, 128, 0);
			int num = 1;
			if (val == val2)
			{
				Vector2 val4 = val2.ToVector2() * 16f - Main.screenPosition;
				Rectangle value = default(Rectangle);
				value = new(0, 0, 16, 16);
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val4, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val4, (Rectangle?)value, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else if (val.X == val2.X)
			{
				int num2 = val2.Y - val.Y;
				int num3 = Math.Sign(num2);
				Vector2 val5 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value2 = default(Rectangle);
				value2 = new((num2 * num > 0) ? 72 : 18, 0, 16, 16);
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val5, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val5, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int i = val.Y + num3; i != val2.Y; i += num3)
				{
					val5 = new Vector2((float)(val.X << 4), (float)(i << 4)) - Main.screenPosition;
					value2.Y = 0;
					value2.X = 90;
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val5, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val5, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				val5 = val2.ToVector2() * 16f - Main.screenPosition;
				value2 = new((num2 * num > 0) ? 18 : 72, 0, 16, 16);
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val5, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val5, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else if (val.Y == val2.Y)
			{
				int num4 = val2.X - val.X;
				int num5 = Math.Sign(num4);
				Vector2 val6 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value3 = default(Rectangle);
				value3 = new((num4 > 0) ? 36 : 144, 0, 16, 16);
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int j = val.X + num5; j != val2.X; j += num5)
				{
					val6 = new Vector2((float)(j << 4), (float)(val.Y << 4)) - Main.screenPosition;
					value3.Y = 0;
					value3.X = 180;
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				val6 = val2.ToVector2() * 16f - Main.screenPosition;
				value3 = new((num4 > 0) ? 144 : 36, 0, 16, 16);
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else
			{
				Math.Abs(val.X - val2.X);
				Math.Abs(val.Y - val2.Y);
				int num6 = Math.Sign(val2.X - val.X);
				int num7 = Math.Sign(val2.Y - val.Y);
				Point val7 = default(Point);
				bool flag = false;
				bool flag2 = player.direction == 1;
				int num8;
				int num9;
				int num10;
				if (flag2)
				{
					val7.X = val.X;
					num8 = val.Y;
					num9 = val2.Y;
					num10 = num7;
				}
				else
				{
					val7.Y = val.Y;
					num8 = val.X;
					num9 = val2.X;
					num10 = num6;
				}
				Vector2 val8 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value4 = default(Rectangle);
				value4 = new(0, 0, 16, 16);
				if (!flag2)
				{
					value4.X = ((num10 > 0) ? 36 : 144);
				}
				else
				{
					value4.X = ((num10 > 0) ? 72 : 18);
				}
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val8, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val8, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int k = num8 + num10; k != num9; k += num10)
				{
					if (flag)
					{
						break;
					}
					if (flag2)
					{
						val7.Y = k;
					}
					else
					{
						val7.X = k;
					}
					if (WorldGen.InWorld(val7.X, val7.Y, 1) && Main.tile[val7.X, val7.Y] != null)
					{
						val8 = val7.ToVector2() * 16f - Main.screenPosition;
						value4.Y = 0;
						if (!flag2)
						{
							value4.X = 180;
						}
						else
						{
							value4.X = 90;
						}
						Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val8, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val8, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
				}
				if (flag2)
				{
					val7.Y = val2.Y;
					num8 = val.X;
					num9 = val2.X;
					num10 = num6;
				}
				else
				{
					val7.X = val2.X;
					num8 = val.Y;
					num9 = val2.Y;
					num10 = num7;
				}
				val8 = val7.ToVector2() * 16f - Main.screenPosition;
				value4 = new(0, 0, 16, 16);
				if (!flag2)
				{
					value4.X += ((num6 > 0) ? 144 : 36);
					value4.X += ((num7 * num > 0) ? 72 : 18);
				}
				else
				{
					value4.X += ((num6 > 0) ? 36 : 144);
					value4.X += ((num7 * num > 0) ? 18 : 72);
				}
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val8, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val8, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int l = num8 + num10; l != num9; l += num10)
				{
					if (flag)
					{
						break;
					}
					if (!flag2)
					{
						val7.Y = l;
					}
					else
					{
						val7.X = l;
					}
					if (WorldGen.InWorld(val7.X, val7.Y, 1) && Main.tile[val7.X, val7.Y] != null)
					{
						val8 = val7.ToVector2() * 16f - Main.screenPosition;
						value4.Y = 0;
						if (!flag2)
						{
							value4.X = 90;
						}
						else
						{
							value4.X = 180;
						}
						Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val8, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val8, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
				}
				val8 = val2.ToVector2() * 16f - Main.screenPosition;
				value4 = new(0, 0, 16, 16);
				if (!flag2)
				{
					value4.X += ((num7 * num > 0) ? 18 : 72);
				}
				else
				{
					value4.X += ((num6 > 0) ? 144 : 36);
				}
				Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val8, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val8, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			return false;
		}
	}
}
