using System;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Audio;
using Terraria.GameInput;
using Terraria.ID;

namespace miningcracks_take_on_luiafk.Images.Projectiles
{
	internal static class ProjAIs
	{
		internal static void WireProj(Projectile proj)
		{
																																																																																																																											Player player = Main.player[proj.owner];
			if (Main.myPlayer == proj.owner)
			{
				if (proj.localAI[1] > 0f)
				{
					proj.localAI[1] -= 1f;
				}
				if (player.noItems || player.CCed || player.dead)
				{
					proj.Kill();
				}
				else if (Main.mouseRight && Main.mouseRightRelease)
				{
					proj.Kill();
					player.mouseInterface = true;
					Main.blockMouse = true;
				}
				else if (!player.channel)
				{
					if (proj.localAI[0] == 0f)
					{
						proj.localAI[0] = 1f;
					}
					proj.Kill();
				}
				else if (proj.localAI[1] == 0f)
				{
					Vector2 val = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
					if (player.gravDir == -1f)
					{
						val.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y;
					}
					if (val != proj.Center)
					{
						proj.netUpdate = true;
						proj.Center = val;
						proj.localAI[1] = 1f;
					}
					if (proj.ai[0] == 0f && proj.ai[1] == 0f)
					{
						proj.ai[0] = (int)proj.Center.X / 16;
						proj.ai[1] = (int)proj.Center.Y / 16;
						proj.netUpdate = true;
						proj.velocity = Vector2.Zero;
					}
				}
				proj.velocity = Vector2.Zero;
				Point val2 = Utils.ToPoint(new Vector2(proj.ai[0], proj.ai[1]));
				Point val3 = proj.Center.ToTileCoordinates();
				Math.Abs(val2.X - val3.X);
				Math.Abs(val2.Y - val3.Y);
				int num = Math.Sign(val3.X - val2.X);
				int num2 = Math.Sign(val3.Y - val2.Y);
				Point val4 = default(Point);
				bool flag = false;
				bool flag2 = player.direction == 1;
				int num3;
				int num4;
				int num5;
				if (flag2)
				{
					val4.X = val2.X;
					num3 = val2.Y;
					num4 = val3.Y;
					num5 = num2;
				}
				else
				{
					val4.Y = val2.Y;
					num3 = val2.X;
					num4 = val3.X;
					num5 = num;
				}
				for (int i = num3; i != num4; i += num5)
				{
					if (flag)
					{
						break;
					}
					if (flag2)
					{
						val4.Y = i;
					}
					else
					{
						val4.X = i;
					}
				}
				if (flag2)
				{
					val4.Y = val3.Y;
					num3 = val2.X;
					num4 = val3.X;
					num5 = num;
				}
				else
				{
					val4.X = val3.X;
					num3 = val2.Y;
					num4 = val3.Y;
					num5 = num2;
				}
				for (int j = num3; j != num4; j += num5)
				{
					if (flag)
					{
						break;
					}
					if (!flag2)
					{
						val4.Y = j;
					}
					else
					{
						val4.X = j;
					}
				}
			}
			int num6 = Math.Sign(player.velocity.X);
			if (num6 != 0)
			{
				player.ChangeDir(num6);
			}
			player.heldProj = proj.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = 0f;
		}

		internal static void BankAI(Projectile proj, int itemType, int chestType, ref int playerBank, Player p, LuiafkPlayer luiP)
		{
			if (Main.gamePaused && !Main.gameMenu || Main.SmartCursorIsUsed)
			{
				return;
			}
			Vector2 val = proj.position - Main.screenPosition;
			int num = (int)((double)p.Center.X / 16.0);
			int num2 = (int)((double)p.Center.Y / 16.0);
			int num3 = (int)proj.Center.X / 16;
			int num4 = (int)proj.Center.Y / 16;
			int lastTileRangeX = p.lastTileRangeX;
			int lastTileRangeY = p.lastTileRangeY;
			if (num < num3 - lastTileRangeX || num > num3 + lastTileRangeX + 1 || num2 < num4 - lastTileRangeY || num2 > num4 + lastTileRangeY + 1)
			{
				if (playerBank == proj.whoAmI)
				{
					playerBank = -1;
					luiP.chests = false;
				}
			}
			else
			{
				if ((float)Main.mouseX <= val.X || (float)Main.mouseX >= val.X + (float)proj.width || (float)Main.mouseY <= val.Y || (float)Main.mouseY >= val.Y + (float)proj.height)
				{
					return;
				}
				p.noThrow = 2;
				p.cursorItemIconEnabled = true;
				p.cursorItemIconID = itemType;
				if (PlayerInput.UsingGamepad)
				{
					p.GamepadEnableGrappleCooldown();
				}
				if (!Main.mouseRight || !Main.mouseRightRelease || Player.BlockInteractionWithProjectiles != 0)
				{
					return;
				}
				Main.mouseRightRelease = false;
				if (p.chest == chestType)
				{
					SoundEngine.PlaySound(in SoundID.Item59, (Vector2?)new Vector2(-1f, -1f));
					p.chest = -1;
					Recipe.FindRecipes();
					return;
				}
				bool flag = false;
				num = ((p.SpawnX == -1) ? Main.spawnTileX : p.SpawnX);
				num2 = ((p.SpawnY == -1) ? Main.spawnTileY : p.SpawnY);
				int num5 = (int)proj.Center.X / 16;
				int num6 = (int)proj.Center.Y / 16;
				if (!TileChecks.SolidTile(num5, num6))
				{
					for (int i = 0; i < 5000; i++)
					{
						for (int j = 0; j < 2000; j++)
						{
							if (num - i > 40 && num2 + j < Main.maxTilesY - 40 && TileChecks.SolidTile(num - i, num2 + j))
							{
								num5 = num - i;
								num6 = num2 + j;
								flag = true;
								break;
							}
							if (num + i < Main.maxTilesX - 40 && num2 + j < Main.maxTilesY - 40 && TileChecks.SolidTile(num + i, num2 + j))
							{
								num5 = num + i;
								num6 = num2 + j;
								flag = true;
								break;
							}
							if (num + i < Main.maxTilesX - 40 && num2 - j > 40 && TileChecks.SolidTile(num + i, num2 - j))
							{
								num5 = num + i;
								num6 = num2 - j;
								flag = true;
								break;
							}
							if (num - i > 40 && num2 - j > 40 && TileChecks.SolidTile(num - i, num2 - j))
							{
								num5 = num - i;
								num6 = num2 - j;
								flag = true;
								break;
							}
						}
						if (flag)
						{
							break;
						}
					}
				}
				playerBank = proj.whoAmI;
				luiP.chests = true;
				p.chest = chestType;
				p.chestX = num5;
				p.chestY = num6;
				p.SetTalkNPC(playerBank);
				Main.oldNPCShop = 0;
				Main.playerInventory = true;
				SoundEngine.PlaySound(in SoundID.Item59, (Vector2?)new Vector2(-1f, -1f));
				Recipe.FindRecipes();
			}
		}
	}
}
