using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Fishing
{
	internal static class Fishing
	{
		public static bool currentlyFishing;

		internal static void FishronPacket(int proj)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(8);
			((BinaryWriter)packet).Write(proj);
			packet.Send();
		}

		private static void FishingDust(Projectile projectile)
		{
			if (!projectile.lavaWet && !projectile.honeyWet)
			{
				for (int i = 0; i < 100; i++)
				{
					int num = Dust.NewDust(new Vector2(projectile.position.X - 6f, projectile.position.Y - 10f), projectile.width + 12, 24, Dust.dustWater());
					Main.dust[num].velocity.Y -= 4f;
					Main.dust[num].velocity.X *= 2.5f;
					Main.dust[num].scale = 0.8f;
					Main.dust[num].alpha = 100;
					Main.dust[num].noGravity = true;
				}
				SoundEngine.PlaySound(in SoundID.Item19, (Vector2?)new Vector2((float)(int)projectile.position.X, (float)(int)projectile.position.Y));
			}
		}

		internal static void FishingBobber(Projectile projectile)
		{
			if (!currentlyFishing && projectile.WithinRange(Main.player[projectile.owner].Center, 5f))
			{
				projectile.Kill();
			}
			projectile.timeLeft = 60;
			Player player = Main.player[projectile.owner];
			if (!player.GetModPlayer<LuiafkPlayer>().holdingFishingRod || player.CCed || player.noItems || player.dead || player.pulley || player.inventory[player.selectedItem].shoot != projectile.type)
			{
				projectile.Kill();
			}
			if (projectile.ai[1] > 0f && projectile.localAI[1] >= 0f)
			{
				projectile.localAI[1] = -1f;
				FishingDust(projectile);
			}
			if (projectile.ai[0] >= 1f)
			{
				if (projectile.ai[0] == 2f)
				{
					projectile.ai[0] += 1f;
					SoundEngine.PlaySound(in SoundID.Item17, projectile.position);
					FishingDust(projectile);
				}
				if (projectile.localAI[0] < 100f)
				{
					projectile.localAI[0] += 1f;
				}
				projectile.tileCollide = false;
				Vector2 val = default(Vector2) + new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
				float num = player.position.X + (float)(player.width / 2) - val.X;
				float num2 = player.position.Y + (float)(player.height / 2) - val.Y;
				float num3 = (float)Math.Sqrt(num * num + num2 * num2);
				if (num3 > 3000f)
				{
					projectile.Kill();
				}
				num3 = 15.9f / num3;
				num *= num3;
				num2 *= num3;
				projectile.velocity.X = (projectile.velocity.X * 9f + num) / 10f;
				projectile.velocity.Y = (projectile.velocity.Y * 9f + num2) / 10f;
				if (Main.myPlayer == projectile.owner)
				{
					Rectangle val2 = default(Rectangle);
					Rectangle val3 = val2;
					val3.Modified((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height);
					Rectangle val4 = default(Rectangle);
					val4.Modified((int)player.position.X, (int)player.position.Y, player.width, player.height);
					val2 = val3;
					if (((Rectangle)(val2)).Intersects(val4))
					{
						if (projectile.ai[1] > 0f)
						{
							int num4 = (int)projectile.ai[1];
							Item item = new Item();
							item.SetDefaults(num4);
							if (num4 == 3196)
							{
								int num5 = (int)CatchFish.GetProjSkill(myPlayer: true);
								int minValue = (num5 / 20 + 3) / 2;
								int num6 = (num5 / 10 + 6) / 2;
								if (Main.rand.Next(50) < num5)
								{
									num6++;
								}
								if (Main.rand.Next(100) < num5)
								{
									num6++;
								}
								if (Main.rand.Next(150) < num5)
								{
									num6++;
								}
								if (Main.rand.Next(200) < num5)
								{
									num6++;
								}
								item.stack = Main.rand.Next(minValue, num6 + 1);
							}
							if (num4 == 3197)
							{
								int num7 = (int)CatchFish.GetProjSkill(myPlayer: true);
								int minValue2 = (num7 / 4 + 15) / 2;
								int num8 = (num7 / 2 + 30) / 2;
								if (Main.rand.Next(50) < num7)
								{
									num8 += 4;
								}
								if (Main.rand.Next(100) < num7)
								{
									num8 += 4;
								}
								if (Main.rand.Next(150) < num7)
								{
									num8 += 4;
								}
								if (Main.rand.Next(200) < num7)
								{
									num8 += 4;
								}
								item.stack = Main.rand.Next(minValue2, num8 + 1);
							}
							item.newAndShiny = true;
							if (player.GetItem(projectile.owner, item, default(GetItemSettings)).stack > 0)
							{
								int number = Item.NewItem(null, (int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, num4, 1, noBroadcast: false, 0, noGrabDelay: true);
								if (Main.netMode == 1)
								{
									NetMessage.SendData(21, -1, -1, null, number, 1f);
								}
							}
							else
							{
								item.position.X = projectile.Center.X - (float)(item.width / 2);
								item.position.Y = projectile.Center.Y - (float)(item.height / 2);
								item.active = true;
								PopupText.NewText(PopupTextContext.RegularItemPickup, item, 0);
							}
						}
						projectile.Kill();
					}
				}
				projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
				return;
			}
			bool flag = false;
			Vector2 val5 = default(Vector2) + new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
			float num9 = player.position.X + (float)(player.width / 2) - val5.X;
			float num10 = player.position.Y + (float)(player.height / 2) - val5.Y;
			projectile.rotation = (float)Math.Atan2(num10, num9) + 1.57f;
			if ((float)Math.Sqrt(num9 * num9 + num10 * num10) > 900f)
			{
				projectile.ai[0] = 1f;
			}
			if (projectile.wet)
			{
				projectile.rotation = 0f;
				projectile.velocity.X = projectile.velocity.X * 0.9f;
				int x = (int)(projectile.Center.X + (float)((projectile.width / 2 + 8) * projectile.direction)) / 16;
				int y = (int)(projectile.Center.Y / 16f);
				int y2 = (int)((projectile.position.Y + (float)projectile.height) / 16f);
				if (Main.tile[x, y] == null)
				{
					_ = Main.tile[x, y];
				}
				if (Main.tile[x, y2] == null)
				{
					_ = Main.tile[x, y2];
				}
				if (projectile.velocity.Y > 0f)
				{
					projectile.velocity.Y = projectile.velocity.Y * 0.5f;
				}
				x = (int)(projectile.Center.X / 16f);
				y = (int)(projectile.Center.Y / 16f);
				float num11 = projectile.position.Y + (float)projectile.height;
				if (Main.tile[x, y - 1] == null)
				{
					_ = Main.tile[x, y - 1];
				}
				if (Main.tile[x, y] == null)
				{
					_ = Main.tile[x, y];
				}
				if (Main.tile[x, y + 1] == null)
				{
					_ = Main.tile[x, y + 1];
				}
				if (Main.tile[x, y - 1].LiquidAmount > 0)
				{
					num11 = y << 4;
					num11 -= (float)((int)Main.tile[x, y - 1].LiquidAmount / 16);
				}
				else if (Main.tile[x, y].LiquidAmount > 0)
				{
					num11 = y + 1 << 4;
					num11 -= (float)((int)Main.tile[x, y].LiquidAmount / 16);
				}
				else if (Main.tile[x, y + 1].LiquidAmount > 0)
				{
					num11 = y + 2 << 4;
					num11 -= (float)((int)Main.tile[x, y + 1].LiquidAmount / 16);
				}
				if (projectile.Center.Y > num11)
				{
					projectile.velocity.Y = projectile.velocity.Y - 0.1f;
					if (projectile.velocity.Y < -8f)
					{
						projectile.velocity.Y = -8f;
					}
					if (projectile.Center.Y + projectile.velocity.Y < num11)
					{
						projectile.velocity.Y = num11 - projectile.Center.Y;
					}
				}
				else
				{
					projectile.velocity.Y = num11 - projectile.Center.Y;
				}
				if ((double)projectile.velocity.Y >= -0.01 && (double)projectile.velocity.Y <= 0.01)
				{
					flag = true;
				}
			}
			else
			{
				if (projectile.velocity.Y == 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.95f;
				}
				projectile.velocity.X = projectile.velocity.X * 0.98f;
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
				if (projectile.velocity.Y > 15.9f)
				{
					projectile.velocity.Y = 15.9f;
				}
			}
			if (Main.myPlayer == projectile.owner)
			{
				int num12 = (int)CatchFish.GetProjSkill(myPlayer: true);
				if (num12 < 0 && num12 == -1)
				{
					player.displayedFishingInfo = Language.GetTextValue("GameUI.FishingWarning");
				}
			}
			if (projectile.ai[1] != 0f)
			{
				flag = true;
			}
			if (!flag)
			{
				return;
			}
			if (projectile.ai[1] == 0f && Main.myPlayer == projectile.owner)
			{
				int num13 = (int)CatchFish.GetProjSkill(myPlayer: true);
				if (num13 == -9000)
				{
					projectile.localAI[1] += 5f;
					projectile.localAI[1] += Main.rand.Next(1, 3);
					if (projectile.localAI[1] > 660f)
					{
						projectile.localAI[1] = 0f;
						bool full = false;
						CatchFish.FishStuff(ref full, -1, projectile);
					}
					return;
				}
				if (Main.rand.Next(300) < num13)
				{
					projectile.localAI[1] += Main.rand.Next(1, 3);
				}
				projectile.localAI[1] += num13 / 30;
				projectile.localAI[1] += Main.rand.Next(1, 3);
				if (Main.rand.NextBool(60))
				{
					projectile.localAI[1] += 60f;
				}
				if (projectile.localAI[1] > 660f)
				{
					projectile.localAI[1] = 0f;
					bool full2 = false;
					CatchFish.FishStuff(ref full2, -1, projectile);
				}
			}
			else if (projectile.ai[1] < 0f)
			{
				if (projectile.velocity.Y == 0f || (projectile.honeyWet && (double)projectile.velocity.Y >= -0.01 && (double)projectile.velocity.Y <= 0.01))
				{
					projectile.velocity.Y = (float)Main.rand.Next(100, 500) * 0.015f;
					projectile.velocity.X = (float)Main.rand.Next(-100, 101) * 0.015f;
					projectile.wet = false;
					projectile.lavaWet = false;
					projectile.honeyWet = false;
				}
				projectile.ai[1] += Main.rand.Next(1, 5);
				if (projectile.ai[1] >= 0f)
				{
					projectile.ai[1] = 0f;
					projectile.localAI[1] = 0f;
					projectile.netUpdate = true;
				}
			}
		}

		internal static void HandleFishron(int proj)
		{
			int num = NPC.NewNPC(null, (int)Main.projectile[proj].Center.X, (int)Main.projectile[proj].Center.Y + 100, 370);
			if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromKey("Announcement.HasAwoken", Main.npc[num].GetTypeNetName()), new Color(175, 75, 255));
			}
		}

		internal static void ProjDrawing(Projectile projectile)
		{
			Player player = Main.player[projectile.owner];
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (!projectile.bobber || !modPlayer.holdingFishingRod)
			{
				return;
			}
			Main.instance.LoadProjectile(projectile.type);
			Vector2 mountedCenter = player.MountedCenter;
			float num = mountedCenter.X;
			float y = mountedCenter.Y;
			y += player.gfxOffY;
			int type = player.inventory[player.selectedItem].type;
			float gravDir = player.gravDir;
			if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedWoodFishingPole").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 36f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedReinforcedFishingPole").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 34f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedFiberglassFishingPole").Type)
			{
				num += (float)(46 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 34f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedFisherofSouls").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 34f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedGoldenFishingRod").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 30f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedMechanicsRod").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 30f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedSittingDucksFishingPole").Type)
			{
				num += (float)(43 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 30f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedFleshCatcher").Type)
			{
				num += (float)(47 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 36f * gravDir;
			}
			else if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedHotlineFishingHook").Type)
			{
				num += (float)(47 * player.direction);
				if (player.direction < 0)
				{
					num -= 13f;
				}
				y -= 32f * gravDir;
			}
			if (gravDir == -1f)
			{
				y -= 12f;
			}
			Vector2 val = default(Vector2);
			val += new Vector2(num, y);
			val = player.RotatedRelativePoint(val + new Vector2(8f), reverseRotation: true) - new Vector2(8f);
			float num2 = projectile.position.X + (float)projectile.width * 0.5f - val.X;
			float num3 = projectile.position.Y + (float)projectile.height * 0.5f - val.Y;
			Math.Sqrt(num2 * num2 + num3 * num3);
			float num4 = (float)Math.Atan2(num3, num2) - 1.57f;
			bool flag = true;
			if (num2 == 0f && num3 == 0f)
			{
				flag = false;
			}
			else
			{
				float num5 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				num5 = 12f / num5;
				num2 *= num5;
				num3 *= num5;
				val.X -= num2;
				val.Y -= num3;
				num2 = projectile.position.X + (float)projectile.width * 0.5f - val.X;
				num3 = projectile.position.Y + (float)projectile.height * 0.5f - val.Y;
			}
			while (flag)
			{
				float num6 = 12f;
				float num7 = (float)Math.Sqrt(num2 * num2 + num3 * num3);
				float num8 = num7;
				if (float.IsNaN(num7) || float.IsNaN(num8))
				{
					flag = false;
					continue;
				}
				if (num7 < 20f)
				{
					num6 = num7 - 8f;
					flag = false;
				}
				num7 = 12f / num7;
				num2 *= num7;
				num3 *= num7;
				val.X += num2;
				val.Y += num3;
				num2 = projectile.position.X + (float)projectile.width * 0.5f - val.X;
				num3 = projectile.position.Y + (float)projectile.height * 0.1f - val.Y;
				if (num8 > 12f)
				{
					float num9 = 0.3f;
					float num10 = Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y);
					if (num10 > 16f)
					{
						num10 = 16f;
					}
					num10 = 1f - num10 / 16f;
					num9 *= num10;
					num10 = num8 / 80f;
					if (num10 > 1f)
					{
						num10 = 1f;
					}
					num9 *= num10;
					if (num9 < 0f)
					{
						num9 = 0f;
					}
					num10 = 1f - projectile.localAI[0] / 100f;
					num9 *= num10;
					if (num3 > 0f)
					{
						num3 *= 1f + num9;
						num2 *= 1f - num9;
					}
					else
					{
						num10 = Math.Abs(projectile.velocity.X) / 3f;
						if (num10 > 1f)
						{
							num10 = 1f;
						}
						num10 -= 0.5f;
						num9 *= num10;
						if (num9 > 0f)
						{
							num9 *= 2f;
						}
						num3 *= 1f + num9;
						num2 *= 1f - num9;
					}
				}
				num4 = (float)Math.Atan2(num3, num2) - 1.57f;
				Color color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(200, 200, 200, 100));
				if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedGoldenFishingRod").Type)
				{
					color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(100, 180, 230, 100));
				}
				if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedMechanicsRod").Type)
				{
					color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(250, 90, 70, 100));
				}
				if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedFisherofSouls").Type)
				{
					color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(203, 190, 210, 100));
				}
				if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedFleshCatcher").Type)
				{
					color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(183, 77, 112, 100));
				}
				if (type == LuiafkMod.Instance.Find<ModItem>("UnlimitedHotlineFishingHook").Type)
				{
					color = Lighting.GetColor((int)val.X / 16, (int)(val.Y / 16f), new Color(255, 226, 116, 100));
				}
				Main.spriteBatch.Draw(TextureAssets.FishingLine.Value, new Vector2(val.X - Main.screenPosition.X + (float)TextureAssets.FishingLine.Value.Width * 0.5f, val.Y - Main.screenPosition.Y + (float)TextureAssets.FishingLine.Value.Height * 0.5f), (Rectangle?)new Rectangle(0, 0, TextureAssets.FishingLine.Value.Width, (int)num6), color, num4, new Vector2((float)TextureAssets.FishingLine.Value.Width * 0.5f, 0f), 1f, (SpriteEffects)0, 0f);
			}
			SpriteEffects val2 = (SpriteEffects)0;
			if (projectile.spriteDirection == -1)
			{
				val2 = (SpriteEffects)1;
			}
			Color color2 = Lighting.GetColor((int)((double)projectile.position.X + (double)projectile.width * 0.5) / 16, (int)(((double)projectile.position.Y + (double)projectile.height * 0.5) / 16.0));
			if (projectile.hide && !ProjectileID.Sets.DontAttachHideToAlpha[projectile.type])
			{
				color2 = Lighting.GetColor((int)mountedCenter.X / 16, (int)(mountedCenter.Y / 16f));
			}
			int num11 = 8;
			int num12 = 0;
			float num13 = (float)(TextureAssets.Projectile[projectile.type].Value.Width - projectile.width) * 0.5f + (float)projectile.width * 0.5f;
			if (projectile.ai[1] > 0f && projectile.ai[0] == 1f)
			{
				int num14 = (int)projectile.ai[1];
				Vector2 center = projectile.Center;
				float rotation = projectile.rotation;
				Vector2 val3 = center;
				float num15 = num - val3.X;
				float num16 = y - val3.Y;
				rotation = (float)Math.Atan2(num16, num15);
				if (projectile.velocity.X > 0f)
				{
					val2 = (SpriteEffects)0;
					rotation = (float)Math.Atan2(num16, num15);
					rotation += 0.785f;
					if (projectile.ai[1] == 2342f)
					{
						rotation -= 0.785f;
					}
				}
				else
				{
					val2 = (SpriteEffects)1;
					rotation = (float)Math.Atan2(0.0 - (double)num16, 0.0 - (double)num15);
					rotation -= 0.785f;
					if (projectile.ai[1] == 2342f)
					{
						rotation += 0.785f;
					}
				}
				Main.spriteBatch.Draw(TextureAssets.Item[num14].Value, new Vector2(center.X - Main.screenPosition.X, center.Y - Main.screenPosition.Y), (Rectangle?)new Rectangle(0, 0, TextureAssets.Item[num14].Value.Width, TextureAssets.Item[num14].Value.Height), color2, rotation, new Vector2((float)(TextureAssets.Item[num14].Value.Width / 2), (float)(TextureAssets.Item[num14].Value.Height / 2)), projectile.scale, val2, 0f);
			}
			else if (projectile.ai[0] <= 1f)
			{
				Main.spriteBatch.Draw(TextureAssets.Projectile[projectile.type].Value, new Vector2(projectile.position.X - Main.screenPosition.X + num13 + (float)num12, projectile.position.Y - Main.screenPosition.Y + (float)(projectile.height / 2) + projectile.gfxOffY), (Rectangle?)new Rectangle(0, 0, TextureAssets.Projectile[projectile.type].Value.Width, TextureAssets.Projectile[projectile.type].Value.Height), projectile.GetAlpha(color2), projectile.rotation, new Vector2(num13, (float)(projectile.height / 2 + num11)), projectile.scale, val2, 0f);
			}
		}
	}
}
