using System;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.Localization;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class MiscMethods
	{
		internal static void WriteText(string text)
		{
						WriteText(text, new Color(255, 0, 0));
		}

		internal static void WriteText(string text, Color c)
		{
									if (Main.netMode == 2)
			{
				ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text), c);
			}
			else
			{
				Main.NewText(text, c);
			}
		}

		internal static void StressChange(Player p, int amount)
		{
			ModPlayer modPlayer = p.GetModPlayer<ModPlayer>();
			modPlayer.GetType().GetField("stress").SetValue(modPlayer, amount);
		}

		internal static void DrawRectangleOutline(SpriteBatch sb, Rectangle rect, Color c)
		{
																																																																					rect.X -= (int)Main.screenPosition.X;
			rect.Y -= (int)Main.screenPosition.Y;
			sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y, rect.Width, 2), c);
			sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y + rect.Height - 2, rect.Width, 2), c);
			sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X, rect.Y, 2, rect.Height), c);
			sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle(rect.X + rect.Width - 2, rect.Y, 2, rect.Height), c);
		}

		private static void NPCLookAtTarget(NPC npc, Player p, ref SpriteEffects sE, ref float rot, int textureType = -1)
		{
												rot = (npc.Center - p.Center).ToRotation() + (float)Math.PI / 2f;
			CheckRotation(ref rot);
			switch (textureType)
			{
			case 262:
				sE = (SpriteEffects)2;
				break;
			case 370:
				rot += (float)Math.PI / 2f;
				CheckRotation(ref rot);
				if (rot >= (float)Math.PI / 2f && rot < 4.712389f)
				{
					sE = (SpriteEffects)2;
				}
				break;
			case 113:
				rot -= (float)Math.PI / 2f;
				CheckRotation(ref rot);
				break;
			}
		}

		private static void CheckRotation(ref float rot)
		{
			if (rot < 0f)
			{
				rot += (float)Math.PI * 2f;
			}
			else if (rot >= (float)Math.PI * 2f)
			{
				rot -= (float)Math.PI * 2f;
			}
		}

		internal static void DrawNPCCenteredOnHitbox(SpriteBatch sb, NPC npc, Player p = null, int textureType = 0)
		{
			SpriteEffects sE = (SpriteEffects)0;
			float rot = npc.rotation;
			if (npc.type == ModContent.NPCType<NPCs.Deeps>())
			{
				NPCLookAtTarget(npc, Main.player[Main.myPlayer], ref sE, ref rot, textureType);
			}
			Rectangle hitbox = npc.Hitbox;
			Rectangle val = hitbox;
			float autoAddX = val.Center.X - (int)Main.screenPosition.X;
			hitbox = npc.Hitbox;
			Vector2 val2 = default(Vector2);
			val = hitbox;
			val2 = new(autoAddX, val.Center.Y - (int)Main.screenPosition.Y);
			Vector2 val3 = (val2 - new Vector2((float)(TextureAssets.Npc[textureType].Value.Width / 2), (float)(TextureAssets.Npc[textureType].Value.Height / Main.npcFrameCount[textureType] / 2))).RotatedBy(rot, val2);
			sb.Draw(TextureAssets.Npc[textureType].Value, new Rectangle((int)val3.X, (int)val3.Y, TextureAssets.Npc[textureType].Value.Width, TextureAssets.Npc[textureType].Value.Height / Main.npcFrameCount[textureType]), (Rectangle?)npc.frame, new Color(255, 255, 255), rot, Vector2.Zero, sE, 0f);
		}

		internal static void DrawProjCenteredOnHitbox(SpriteBatch sb, Projectile proj)
		{
																																																																																																						float rotation = proj.rotation;
			Rectangle hitbox = proj.Hitbox;
			Rectangle val = hitbox;
			float num = val.Center.X - (int)Main.screenPosition.X - TextureAssets.Projectile[proj.type].Value.Width / 2;
			hitbox = proj.Hitbox;
			val = hitbox;
			Vector2 spinningpoint = new Vector2(num, val.Center.Y - (int)Main.screenPosition.Y - TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type] / 2);
			hitbox = proj.Hitbox;
			val = hitbox;
			float autoAddX = val.Center.X - (int)Main.screenPosition.X;
			hitbox = proj.Hitbox;
			Vector2 val2 = default(Vector2);
			val = hitbox;
			val2.ToWorldCoordinates(autoAddX, val.Center.Y - (int)Main.screenPosition.Y);
			Vector2 val3 = Utils.RotatedBy(spinningpoint, rotation, val2);
			sb.Draw(TextureAssets.Projectile[proj.type].Value, new Rectangle((int)val3.X, (int)val3.Y, TextureAssets.Projectile[proj.type].Value.Width, TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type]), (Rectangle?)new Rectangle(0, proj.frame * TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type], TextureAssets.Projectile[proj.type].Value.Width, TextureAssets.Projectile[proj.type].Value.Height / Main.projFrames[proj.type]), new Color(255, 255, 255), proj.rotation, Vector2.Zero, (SpriteEffects)((proj.direction == 1) ? 1 : 0), 0f);
		}

		internal static void Despawn(int npc)
		{
			Main.npc[npc] = new NPC
			{
				whoAmI = npc
			};
			if (Main.netMode == 2)
			{
				NetMessage.SendData(23, -1, -1, null, npc);
			}
		}

		internal static bool AnyBoss(bool despawn)
		{
						bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < 200; i++)
			{
				NPC nPC = Main.npc[i];
				if (nPC.active && (nPC.boss || LuiafkMod.NotTaggedBoss.Contains(nPC.type)))
				{
					flag = true;
					if (!despawn)
					{
						return flag;
					}
					Despawn(nPC.whoAmI);
				}
			}
			if (DD2Event.Ongoing)
			{
				flag2 = true;
				if (!despawn)
				{
					return flag2;
				}
				DD2Event.StopInvasion();
			}
			if (flag || flag2)
			{
				WriteText((flag ? "All bosses despawned! " : "") + (flag2 ? "DD2 event failed!" : ""), Color.Red);
			}
			return flag || flag2;
		}

		internal static void DespawnPacket()
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(14);
			packet.Send();
		}

		internal static void ThisItemIcon(Player player, Item item)
		{
			if (!Main.GamepadDisableCursorItemIcon && !player.mouseInterface && !Main.mouseText && player.whoAmI == Main.myPlayer)
			{
				player.cursorItemIconEnabled = true;
				Main.ItemIconCacheUpdate(item.type);
				player.cursorItemIconID = item.type;
			}
		}

		internal static void PaintHoldItem(Player player, PaintToolUI ui)
		{
									ui.target = Point16.NegativeOne;
			if (Main.SmartCursorIsUsed)
			{
				ui.target = SmartCursor.FindClosestToPosition(FindType.Smart, player, Main.MouseWorld / 16f);
			}
			UILearning.BoxPlaceUI.Update(BoxType.Paint);
		}

		internal static void WallRodHoldItem(Player player)
		{
			if (!player.inventory[48].IsAir && player.inventory[48].createWall != -1)
			{
				UILearning.BoxPlaceUI.Update(BoxType.Wall);
			}
		}
	}
}
