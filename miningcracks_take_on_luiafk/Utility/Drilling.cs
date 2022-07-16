using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.UI;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class Drilling
	{
		internal class DrillBeam
		{
			internal Point16 curTileTarget;

			internal DrillBeam()
			{
				curTileTarget = Point16.NegativeOne;
			}
		}

		internal class DrillData
		{
			internal DrillBeam[] beams;

			internal DrillData()
			{
				beams = new DrillBeam[30];
				for (int i = 0; i < beams.Length; i++)
				{
					beams[i] = new DrillBeam();
				}
			}
		}

		internal static void DrillStuff(Player p, LuiafkPlayer luiP)
		{
						if (Main.myPlayer != p.whoAmI || luiP.noDrill)
			{
				return;
			}
			DrillUI.mountData = new DrillData();
			if (Main.mouseLeft && !Main.gamePaused && !Main.ingameOptionsWindow && !p.mouseInterface && p.itemAnimation == 0 && p.itemTime == 0)
			{
				UseDrill(p, luiP);
			}
			if (Main.gamePaused || Main.ingameOptionsWindow || p.mouseInterface)
			{
				return;
			}
			p.controlUseTile = false;
			p.altFunctionUse = 0;
			Main.blockMouse = true;
			if (Main.mouseRight && Main.mouseRightRelease)
			{
				Main.mouseRightRelease = false;
				luiP.drillMode++;
				if (luiP.drillMode == DrillMode.Reset)
				{
					luiP.drillMode = DrillMode.Both;
				}
				Main.NewText((object)("Drill will destroy " + ((luiP.drillMode == DrillMode.Both) ? "[C/48C600:tiles] and [C/48C600:walls]." : ((luiP.drillMode == DrillMode.Tiles) ? "[C/48C600:tiles]." : "[C/48C600:walls]."))), (Color?)new Color(255, 85, 0));
			}
		}

		private static void BeamPacket(byte player, List<Point16> multiBeams, bool server)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(13);
			((BinaryWriter)packet).Write((byte)multiBeams.Count);
			((BinaryWriter)packet).Write(player);
			foreach (Point16 multiBeam in multiBeams)
			{
				((BinaryWriter)packet).Write(multiBeam.X);
				((BinaryWriter)packet).Write(multiBeam.Y);
			}
			if (!server)
			{
				packet.Send();
			}
			else
			{
				packet.Send(-1, player);
			}
		}

		internal static void HandleBeamPacket(BinaryReader reader)
		{
						List<Point16> list = new List<Point16>();
			byte b = reader.ReadByte();
			byte b2 = reader.ReadByte();
			for (int i = 0; i < b; i++)
			{
				list.Add(new Point16(reader.ReadInt16(), reader.ReadInt16()));
			}
			if (Main.netMode == 2)
			{
				BeamPacket(b2, list, server: true);
				return;
			}
			foreach (Point16 item in list)
			{
				DrillUI.multiDrillPositions.Add(new Vector3((float)item.X, (float)item.Y, (float)(int)b2));
			}
		}

		private static void DrawDust(Player player, Vector2 target)
		{
																																																			Vector2 val = default(Vector2);
			val.ToWorldCoordinates(target.X * 16f + 8f, target.Y * 16f + 8f);
			float num = (val - player.Center).ToRotation();
			Vector2 val2 = default(Vector2);
			for (int i = 0; i < 2; i++)
			{
				float num2 = num + (Main.rand.NextBool(2) ? (-1f) : 1f) * ((float)Math.PI / 2f);
				float num3 = (float)Main.rand.NextDouble() * 2f + 2f;
				val2.ToWorldCoordinates((float)Math.Cos(num2) * num3, (float)Math.Sin(num2) * num3);
				int num4 = Dust.NewDust(val, 0, 0, 230, val2.X, val2.Y);
				Main.dust[num4].noGravity = true;
				Main.dust[num4].customData = player;
			}
		}

		private static void DrawLines(Player player, Vector2 target)
		{
																																																																																																															Vector2 val = default(Vector2);
			val = new(target.X * 16f + 8f, target.Y * 16f + 8f);
			Vector2 v = val - player.position;
			Vector2 scale = default(Vector2);
			scale = new(2f, Vector2.Distance(val, player.position));
			Vector2 val2 = default(Vector2);
			val2 = new((float)((player.direction == 1) ? 4 : (-6)), -9f);
			DrawData drawData = default(DrawData);
			for (int i = 0; i < 2; i++)
			{
				Vector2 val3 = val2 + new Vector2((float)Main.rand.Next(-5, 6), 0f);
				Vector2 val4;
				Color val5;
				if (i == 0)
				{
					val4 = val3;
					val5 = Color.Red;
				}
				else
				{
					val4 = val3;
					val5 = Color.DarkRed;
				}
				val5.A = ((byte)128);
				val5 *= 0.5f;
				drawData = new DrawData(TextureAssets.MagicPixel.Value, val4 + player.Center - Main.screenPosition, (Rectangle?)new Rectangle(0, 0, 1, 1), val5, v.ToRotation() - (float)Math.PI / 2f, Vector2.Zero, scale, (SpriteEffects)0, 0);
				drawData.ignorePlayerRotation = true;
				DrawData drawData2 = drawData;
				drawData2.Draw(Main.spriteBatch);
			}
		}

		internal static void DrawLinesAndDustMulti(Player player, Vector2 position)
		{
									DrawDust(player, position);
			DrawLines(player, position);
		}

		internal static void DrawDrill(Player player)
		{
						DrillData mountData = DrillUI.mountData;
			for (int i = 0; i < mountData.beams.Length; i++)
			{
				DrillBeam drillBeam = mountData.beams[i];
				if (drillBeam.curTileTarget != Point16.NegativeOne)
				{
					DrawLines(player, drillBeam.curTileTarget.ToVector2());
				}
			}
		}

		private static void UseDrill(Player player, LuiafkPlayer luiP)
		{
						DrillData mountData = DrillUI.mountData;
			List<Point16> list = new List<Point16>();
			for (int i = 0; i < mountData.beams.Length; i++)
			{
				Point16 point = (mountData.beams[i].curTileTarget = SmartCursor.FindLine(player, luiP, mountData));
				if (!(point != Point16.NegativeOne))
				{
					continue;
				}
				int pickPower = 15000;
				bool flag = true;
				if (WorldGen.InWorld(point.X, point.Y) && Main.tile[point.X, point.Y] != null && Main.tile[point.X, point.Y].TileType == 26 && !Main.hardMode)
				{
					flag = false;
					player.Hurt(PlayerDeathReason.ByOther(4), player.statLife / 2, -player.direction);
				}
				if (player.noBuilding)
				{
					flag = false;
				}
				if (flag)
				{
					if (luiP.drillMode == DrillMode.Tiles || luiP.drillMode == DrillMode.Both)
					{
						player.PickTile(point.X, point.Y, pickPower);
						Tile.SmoothSlope(point.X, point.Y);
					}
					if (luiP.drillMode == DrillMode.Walls || luiP.drillMode == DrillMode.Both)
					{
						WorldGen.KillWall(point.X, point.Y);
						NetMessage.SendData(17, -1, -1, null, 2, point.X, point.Y);
					}
					DrawDust(player, point.ToVector2());
					if (Main.netMode == 1)
					{
						list.Add(point);
					}
				}
			}
			if (list.Count > 0)
			{
				BeamPacket((byte)player.whoAmI, list, server: false);
			}
		}
	}
}
