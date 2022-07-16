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
	public class UnlimitedGrandDesignProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Wiring");
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
				WirePlace.MassWireOperation(player, ps, pe, player.Center, player.direction == 1);
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
			val3 = new(255, 255, 255, 0);
			Color val4 = default(Color);
			val4 = new(127, 127, 127, 0);
			int num = 1;
			float num2 = 0f;
			MultiToolMode uiWireMode = player.GetModPlayer<LuiafkPlayer>().uiWireMode;
			bool flag = (uiWireMode & MultiToolMode.Actuator) != 0;
			if ((uiWireMode & MultiToolMode.Red) != 0)
			{
				num2 += 1f;
				val4 = Color.Lerp(val4, Color.Red, 1f / num2);
			}
			if ((uiWireMode & MultiToolMode.Blue) != 0)
			{
				num2 += 1f;
				val4 = Color.Lerp(val4, Color.Blue, 1f / num2);
			}
			if ((uiWireMode & MultiToolMode.Green) != 0)
			{
				num2 += 1f;
				val4 = Color.Lerp(val4, new Color(0, 255, 0), 1f / num2);
			}
			if ((uiWireMode & MultiToolMode.Yellow) != 0)
			{
				num2 += 1f;
				val4 = Color.Lerp(val4, new Color(255, 255, 0), 1f / num2);
			}
			if ((uiWireMode & MultiToolMode.Cutter) != 0)
			{
				val3 = new(50, 50, 50, 255);
			}
			val4.A = ((byte)0);
			if (val == val2)
			{
				Vector2 val5 = val2.ToVector2() * 16f - Main.screenPosition;
				Rectangle value = default(Rectangle);
				value = new(0, 0, 16, 16);
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val5, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val5, (Rectangle?)value, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val5, (Rectangle?)value, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else if (val.X == val2.X)
			{
				int num3 = val2.Y - val.Y;
				int num4 = Math.Sign(num3);
				Vector2 val6 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value2 = default(Rectangle);
				value2 = new((num3 * num > 0) ? 72 : 18, 0, 16, 16);
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value2.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int i = val.Y + num4; i != val2.Y; i += num4)
				{
					val6 = new Vector2((float)(val.X << 4), (float)(i << 4)) - Main.screenPosition;
					value2.Y = 0;
					value2.X = 90;
					if (flag)
					{
						Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					value2.Y = 18;
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				val6 = val2.ToVector2() * 16f - Main.screenPosition;
				value2 = new((num3 * num > 0) ? 18 : 72, 0, 16, 16);
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val6, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value2.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val6, (Rectangle?)value2, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else if (val.Y == val2.Y)
			{
				int num5 = val2.X - val.X;
				int num6 = Math.Sign(num5);
				Vector2 val7 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value3 = default(Rectangle);
				value3 = new((num5 > 0) ? 36 : 144, 0, 16, 16);
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val7, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value3.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int j = val.X + num6; j != val2.X; j += num6)
				{
					val7 = new Vector2((float)(j << 4), (float)(val.Y << 4)) - Main.screenPosition;
					value3.Y = 0;
					value3.X = 180;
					if (flag)
					{
						Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val7, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					value3.Y = 18;
					Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				val7 = val2.ToVector2() * 16f - Main.screenPosition;
				value3 = new((num5 > 0) ? 144 : 36, 0, 16, 16);
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val7, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value3.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val7, (Rectangle?)value3, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			else
			{
				Math.Abs(val.X - val2.X);
				Math.Abs(val.Y - val2.Y);
				int num7 = Math.Sign(val2.X - val.X);
				int num8 = Math.Sign(val2.Y - val.Y);
				Point val8 = default(Point);
				bool flag2 = false;
				bool flag3 = player.direction == 1;
				int num9;
				int num10;
				int num11;
				if (flag3)
				{
					val8.X = val.X;
					num9 = val.Y;
					num10 = val2.Y;
					num11 = num8;
				}
				else
				{
					val8.Y = val.Y;
					num9 = val.X;
					num10 = val2.X;
					num11 = num7;
				}
				Vector2 val9 = val.ToVector2() * 16f - Main.screenPosition;
				Rectangle value4 = default(Rectangle);
				value4 = new(0, 0, 16, 16);
				if (!flag3)
				{
					value4.X = ((num11 > 0) ? 36 : 144);
				}
				else
				{
					value4.X = ((num11 > 0) ? 72 : 18);
				}
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val9, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value4.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int k = num9 + num11; k != num10; k += num11)
				{
					if (flag2)
					{
						break;
					}
					if (flag3)
					{
						val8.Y = k;
					}
					else
					{
						val8.X = k;
					}
					if (WorldGen.InWorld(val8.X, val8.Y, 1) && Main.tile[val8.X, val8.Y] != null)
					{
						val9 = val8.ToVector2() * 16f - Main.screenPosition;
						value4.Y = 0;
						if (!flag3)
						{
							value4.X = 180;
						}
						else
						{
							value4.X = 90;
						}
						if (flag)
						{
							Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val9, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						}
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						value4.Y = 18;
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
				}
				if (flag3)
				{
					val8.Y = val2.Y;
					num9 = val.X;
					num10 = val2.X;
					num11 = num7;
				}
				else
				{
					val8.X = val2.X;
					num9 = val.Y;
					num10 = val2.Y;
					num11 = num8;
				}
				val9 = val8.ToVector2() * 16f - Main.screenPosition;
				value4 = new(0, 0, 16, 16);
				if (!flag3)
				{
					value4.X += ((num7 > 0) ? 144 : 36);
					value4.X += ((num8 * num > 0) ? 72 : 18);
				}
				else
				{
					value4.X += ((num7 > 0) ? 36 : 144);
					value4.X += ((num8 * num > 0) ? 18 : 72);
				}
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val9, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value4.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				for (int l = num9 + num11; l != num10; l += num11)
				{
					if (flag2)
					{
						break;
					}
					if (!flag3)
					{
						val8.Y = l;
					}
					else
					{
						val8.X = l;
					}
					if (WorldGen.InWorld(val8.X, val8.Y, 1) && Main.tile[val8.X, val8.Y] != null)
					{
						val9 = val8.ToVector2() * 16f - Main.screenPosition;
						value4.Y = 0;
						if (!flag3)
						{
							value4.X = 90;
						}
						else
						{
							value4.X = 180;
						}
						if (flag)
						{
							Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val9, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						}
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
						value4.Y = 18;
						Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
					}
				}
				val9 = val2.ToVector2() * 16f - Main.screenPosition;
				value4 = new(0, 0, 16, 16);
				if (!flag3)
				{
					value4.X += ((num8 * num > 0) ? 18 : 72);
				}
				else
				{
					value4.X += ((num7 > 0) ? 144 : 36);
				}
				if (flag)
				{
					Main.spriteBatch.Draw(TextureAssets.WireUi[11].Value, val9, (Rectangle?)null, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				}
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val4, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
				value4.Y = 18;
				Main.spriteBatch.Draw(TextureAssets.Projectile[base.Projectile.type].Value, val9, (Rectangle?)value4, val3, 0f, Vector2.Zero, 1f, (SpriteEffects)0, 0f);
			}
			return false;
		}
	}
}
