using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class Movement
	{
		private const float accel = 0.5f;

		private const float maxSpeed = 30f;

		internal static void GoodMove(Player p, LuiafkPlayer luiP)
		{
																														p.noFallDmg = true;
			p.armorEffectDrawShadowLokis = true;
			p.armorEffectDrawOutlines = true;
			p.accFlipper = false;
			p.ignoreWater = true;
			p.accMerman = false;
			ChangeVelocity(ref luiP.velocity.X, ref p.velocity.X, p.controlLeft, p.controlRight);
			ChangeVelocity(ref luiP.velocity.Y, ref p.velocity.Y, p.controlUp ? p.controlUp : p.controlJump, p.controlDown);
			p.fallStart = (int)p.position.Y >> 4;
			p.gfxOffY = 0f;
			if (!luiP.Teleported && p.teleportTime != 1f)
			{
				p.position = luiP.position;
			}
			if (!luiP.noClip)
			{
				DryCollision(p, fallThrough: true, ignorePlats: true);
				p.UpdateTouchingTiles();
				TryLandingOnDetonator(p);
				SlopingCollision(p, fallThrough: true);
				PressurePlateHelper.UpdatePlayerPosition(p);
			}
			else
			{
				p.position += luiP.velocity;
			}
			p.BordersMovement();
			luiP.position = p.position;
			p.gfxOffY = 0f;
			if (p.velocity.X == 0f || Main.mouseLeft || Main.mouseRight)
			{
				p.direction = ((p.position.X < Main.MouseWorld.X) ? 1 : (-1));
			}
			else
			{
				p.direction = ((p.velocity.X >= 0f) ? 1 : (-1));
			}
		}

		private static void ChangeVelocity(ref float luiSpeed, ref float playerSpeed, bool negativeKey, bool positiveKey)
		{
			if (negativeKey && luiSpeed <= 0f)
			{
				luiSpeed -= 0.5f;
			}
			else if (negativeKey && luiSpeed > 0f)
			{
				luiSpeed = -0.5f;
			}
			else if (positiveKey && luiSpeed >= 0f)
			{
				luiSpeed += 0.5f;
			}
			else if (positiveKey && luiSpeed < 0f)
			{
				luiSpeed = 0.5f;
			}
			if (luiSpeed < -30f)
			{
				luiSpeed = -30f;
			}
			else if (luiSpeed > 30f)
			{
				luiSpeed = 30f;
			}
			if (!negativeKey && !positiveKey)
			{
				luiSpeed = 0f;
			}
			playerSpeed = luiSpeed;
		}

		private static void DryCollision(Player p, bool fallThrough, bool ignorePlats)
		{
																																																																																																																																																						int height = p.height;
			if (p.velocity.LengthSquared() > 1f)
			{
				Vector2 val = Collision.TileCollision(p.position, p.velocity, p.width, height, fallThrough, ignorePlats, (int)p.gravDir);
				float num = p.velocity.Length();
				Vector2 val2 = Vector2.Normalize(p.velocity);
				if (val.Y == 0f)
				{
					val2.Y = 0f;
				}
				Vector2 val3 = Vector2.Zero;
				while (num > 0f)
				{
					float num2 = num;
					if (num2 > 16f)
					{
						num2 = 16f;
					}
					num -= num2;
					Vector2 val4 = (p.velocity = val2 * num2);
					p.SlopeDownMovement();
					val4 = p.velocity;
					Collision.StepUp(ref p.position, ref val4, p.width, p.height, ref p.stepSpeed, ref p.gfxOffY, (int)p.gravDir);
					Vector2 val5 = Collision.TileCollision(p.position, val4, p.width, height, fallThrough, ignorePlats, (int)p.gravDir);
					if (Collision.up && p.gravDir == 1f)
					{
						p.jump = 0;
					}
					if (p.waterWalk || p.waterWalk2)
					{
						Vector2 velocity = p.velocity;
						val5 = Collision.WaterCollision(p.position, val5, p.width, p.height, fallThrough, fall2: false, p.waterWalk);
						if (velocity != p.velocity)
						{
							p.fallStart = (int)(p.position.Y / 16f);
						}
					}
					p.position += val5;
					p.velocity = val5;
					p.UpdateTouchingTiles();
					TryLandingOnDetonator(p);
					SlopingCollision(p, fallThrough);
					Collision.StepConveyorBelt(p, p.gravDir);
					val5 = p.velocity;
					val3 += val5;
				}
				p.velocity = val3;
			}
			else
			{
				p.velocity = Collision.TileCollision(p.position, p.velocity, p.width, height, fallThrough, ignorePlats, (int)p.gravDir);
				if (Collision.up && p.gravDir == 1f)
				{
					p.jump = 0;
				}
				p.position += p.velocity;
			}
		}

		private static void SlopingCollision(Player p, bool fallThrough)
		{
																																	if (p.controlDown || p.grappling[0] >= 0 || p.gravDir == -1f)
			{
				p.stairFall = true;
			}
			Vector4 val = Collision.SlopeCollision(p.position, p.velocity, p.width, p.height, p.gravity, p.stairFall);
			if (Collision.stairFall)
			{
				p.stairFall = true;
			}
			else if (!fallThrough)
			{
				p.stairFall = false;
			}
			if (Collision.stair && Math.Abs(val.Y - p.position.Y) > 8f + Math.Abs(p.velocity.X))
			{
				p.gfxOffY -= val.Y - p.position.Y;
				p.stepSpeed = 4f;
			}
			p.position.X = val.X;
			p.position.Y = val.Y;
			p.velocity.X = val.Z;
			p.velocity.Y = val.W;
		}

		private static void TryLandingOnDetonator(Player p)
		{
																																				if (p.whoAmI == Main.myPlayer && p.velocity.Y >= 3f)
			{
				Point val = (p.Bottom + new Vector2(0f, 0.01f)).ToTileCoordinates();
				Tile tileSafely = Framing.GetTileSafely(val.X, val.Y);
				if (tileSafely.HasTile && tileSafely.TileType == 411 && tileSafely.TileFrameY == 0 && tileSafely.TileFrameX < 36)
				{
					Wiring.HitSwitch(val.X, val.Y);
					NetMessage.SendData(59, -1, -1, null, val.X, val.Y);
				}
			}
		}
	}
}
