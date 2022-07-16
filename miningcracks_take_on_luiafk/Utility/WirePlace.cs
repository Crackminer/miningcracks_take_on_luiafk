using System;
using System.Linq;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class WirePlace
	{
		private static byte currentGap;

		internal static void MassWireOperation(Player p, Point ps, Point pe, Vector2 dropPoint, bool dir)
		{
																																																																																							int num = Math.Sign(pe.X - ps.X);
			int num2 = Math.Sign(pe.Y - ps.Y);
			MultiToolMode uiWireMode = p.GetModPlayer<LuiafkPlayer>().uiWireMode;
			Point pt = default(Point);
			bool flag = false;
			Item.StartCachingType(530);
			Item.StartCachingType(849);
			int num3;
			int num4;
			int num5;
			if (dir)
			{
				pt.X = ps.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			else
			{
				pt.Y = ps.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			for (int i = num3; i != num4; i += num5)
			{
				if (flag)
				{
					break;
				}
				if (dir)
				{
					pt.Y = i;
				}
				else
				{
					pt.X = i;
				}
				if (!MassWireOperationStep(pt, uiWireMode))
				{
					flag = true;
					break;
				}
			}
			if (dir)
			{
				pt.Y = pe.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			else
			{
				pt.X = pe.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			for (int j = num3; j != num4; j += num5)
			{
				if (flag)
				{
					break;
				}
				if (!dir)
				{
					pt.Y = j;
				}
				else
				{
					pt.X = j;
				}
				if (!MassWireOperationStep(pt, uiWireMode))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MassWireOperationStep(pe, uiWireMode);
			}
			Item.DropCache(new EntitySource_Wiring((int)dropPoint.X, (int)dropPoint.Y), dropPoint, Vector2.Zero, 530);
			Item.DropCache(new EntitySource_Wiring((int)dropPoint.X, (int)dropPoint.Y), dropPoint, Vector2.Zero, 849);
		}

		private static bool MassWireOperationStep(Point pt, MultiToolMode mode)
		{
																																																																																																																																													if (!WorldGen.InWorld(pt.X, pt.Y, 1))
			{
				return false;
			}
			Tile tileSafely = Framing.GetTileSafely(pt.X, pt.Y);
			Lighting.AddLight(pt.X, pt.Y, 1.3f, 1.3f, 1.3f);
			if ((mode & MultiToolMode.Cutter) == 0)
			{
				if ((mode & MultiToolMode.Red) != 0 && !tileSafely.RedWire)
				{
					WorldGen.PlaceWire(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 5, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Blue) != 0 && !tileSafely.BlueWire)
				{
					WorldGen.PlaceWire2(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 10, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Green) != 0 && !tileSafely.GreenWire)
				{
					WorldGen.PlaceWire3(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 12, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Yellow) != 0 && !tileSafely.YellowWire)
				{
					WorldGen.PlaceWire4(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 16, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Actuator) != 0 && !tileSafely.HasActuator)
				{
					WorldGen.PlaceActuator(pt.X, pt.Y);
					NetMessage.SendData(17, -1, -1, null, 8, pt.X, pt.Y);
				}
			}
			else
			{
				if ((mode & MultiToolMode.Red) != 0 && tileSafely.RedWire && WorldGen.KillWire(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 6, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Blue) != 0 && tileSafely.BlueWire && WorldGen.KillWire2(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 11, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Green) != 0 && tileSafely.GreenWire && WorldGen.KillWire3(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 13, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Yellow) != 0 && tileSafely.YellowWire && WorldGen.KillWire4(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 17, pt.X, pt.Y);
				}
				if ((mode & MultiToolMode.Actuator) != 0 && tileSafely.HasActuator && WorldGen.KillActuator(pt.X, pt.Y))
				{
					NetMessage.SendData(17, -1, -1, null, 9, pt.X, pt.Y);
				}
			}
			return true;
		}

		internal static void MassActuatorOperation(Player p, Point ps, Point pe, bool dir)
		{
																																																															LuiafkPlayer modPlayer = p.GetModPlayer<LuiafkPlayer>();
			bool holding = UILearning.RightClickUIs<HoikRodUI>().holding;
			bool holding2 = UILearning.RightClickUIs<ComboRodUI>().holding;
			currentGap = (byte)((holding || holding2) ? modPlayer.uiHoikRodGap : 0);
			int num = Math.Sign(pe.X - ps.X);
			int num2 = Math.Sign(pe.Y - ps.Y);
			Point pt = default(Point);
			bool flag = false;
			int num3;
			int num4;
			int num5;
			if (dir)
			{
				pt.X = ps.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			else
			{
				pt.Y = ps.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			for (int i = num3; i != num4; i += num5)
			{
				if (flag)
				{
					break;
				}
				if (dir)
				{
					pt.Y = i;
				}
				else
				{
					pt.X = i;
				}
				if (!ActuatorOperationStep(pt, p, modPlayer, holding, holding2))
				{
					flag = true;
					break;
				}
			}
			if (dir)
			{
				pt.Y = pe.Y;
				num3 = ps.X;
				num4 = pe.X;
				num5 = num;
			}
			else
			{
				pt.X = pe.X;
				num3 = ps.Y;
				num4 = pe.Y;
				num5 = num2;
			}
			for (int j = num3; j != num4; j += num5)
			{
				if (flag)
				{
					break;
				}
				if (!dir)
				{
					pt.Y = j;
				}
				else
				{
					pt.X = j;
				}
				if (!ActuatorOperationStep(pt, p, modPlayer, holding, holding2))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				ActuatorOperationStep(pe, p, modPlayer, holding, holding2);
			}
		}

		private static bool ActuatorOperationStep(Point pt, Player player, LuiafkPlayer luiP, bool holdingHoik, bool holdingCombo)
		{
																																																																																																																																	int uiHoikRodSelected = luiP.uiHoikRodSelected;
			bool uiHoikRodActive = luiP.uiHoikRodActive;
			bool flag = !(holdingHoik || holdingCombo) || luiP.uiHoikRodReverse;
			byte b = (byte)((holdingHoik || holdingCombo) ? luiP.uiHoikRodGap : 0);
			if (!WorldGen.InWorld(pt.X, pt.Y, 1))
			{
				return false;
			}
			Tile tileSafely = Framing.GetTileSafely(pt.X, pt.Y);
			int num = -1;
			if (currentGap == b)
			{
				if (holdingHoik || holdingCombo)
				{
					if (!player.inventory[49].IsAir)
					{
						if (player.inventory[49].createTile >= 0)
						{
							num = player.inventory[49].createTile;
						}
						if (holdingCombo)
						{
							if (player.inventory[49].type == 154 || player.inventory[49].type == LuiafkMod.Instance.Find<ModItem>("UnlimitedBones").Type)
							{
								num = 194;
							}
							else if (player.inventory[49].type == 1124)
							{
								num = 225;
							}
							else
							{
								switch (num)
								{
								case 30:
									if (luiP.uiComboExtras == 6)
									{
										num = 191;
									}
									else if (luiP.uiComboExtras == 7)
									{
										num = 192;
									}
									break;
								case 158:
									if (luiP.uiComboExtras == 6)
									{
										num = 383;
									}
									else if (luiP.uiComboExtras == 7)
									{
										num = 384;
									}
									break;
								}
							}
						}
					}
					Tile tile;
					if (num != -1)
					{
						tile = Main.tile[pt.X, pt.Y];
						if (!tile.HasTile && Main.tileSolid[num] && (!TileID.Sets.RoomNeeds.CountsAsDoor.Contains(num) || TileID.Sets.Platforms[num]))
						{
							WorldGen.PlaceTile(pt.X, pt.Y, (ushort)num, mute: true);
							tile = Main.tile[pt.X, pt.Y];
							if (tile.TileType == num && player.inventory[49].consumable)
							{
								player.inventory[49].stack--;
								if (player.inventory[49].stack <= 0)
								{
									player.inventory[49] = new Item();
								}
							}
						}
					}
					if (holdingCombo && (luiP.uiComboExtras <= 5 || luiP.uiComboExtras >= 9))
					{
						tile = Main.tile[pt.X, pt.Y];
						if (tile.HasTile)
						{
							tile = Main.tile[pt.X, pt.Y];
							switch (tile.TileType)
							{
							case 1:
								if (luiP.uiComboExtras >= 9 && luiP.uiComboExtras < 14)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = (ushort)(luiP.uiComboExtras - 9 + 179);
								}
								else if (luiP.uiComboExtras == 14)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 381;
								}
								break;
							case 0:
								if (luiP.uiComboExtras == 0)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 2;
								}
								else if (luiP.uiComboExtras == 1)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 23;
								}
								else if (luiP.uiComboExtras == 2)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 199;
								}
								else if (luiP.uiComboExtras == 3)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 109;
								}
								break;
							case 59:
								if (luiP.uiComboExtras == 4)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 70;
								}
								else if (luiP.uiComboExtras == 5)
								{
									tile = Main.tile[pt.X, pt.Y];
									tile.TileType = 60;
								}
								break;
							}
						}
					}
				}
				tileSafely = Main.tile[pt.X, pt.Y];
				if (tileSafely.HasTile && ((tileSafely.TileType != 226 && tileSafely.WallType != 87) || NPC.downedGolemBoss) && Main.tileSolid[tileSafely.TileType] && (!TileID.Sets.RoomNeeds.CountsAsDoor.Contains(tileSafely.TileType) || TileID.Sets.Platforms[tileSafely.TileType]))
				{
					if (holdingHoik || holdingCombo)
					{
						switch (uiHoikRodSelected)
						{
						case 0:
							tileSafely.Slope = SlopeType.Solid;
							tileSafely.IsHalfBlock = false;
							break;
						case 1:
							tileSafely.Slope = SlopeType.Solid;
							tileSafely.IsHalfBlock = true;
							break;
						case 2:
						case 3:
						case 4:
						case 5:
							tileSafely.Slope = (SlopeType)(uiHoikRodSelected - 1);
							tileSafely.IsHalfBlock = false;
							break;
						}
					}
					if (!flag && uiHoikRodActive)
					{
						Wiring.ReActive(pt.X, pt.Y);
					}
					else if (!flag && !uiHoikRodActive)
					{
						Wiring.DeActive(pt.X, pt.Y);
					}
					else
					{
						Wiring.ActuateForced(pt.X, pt.Y);
					}
					WorldGen.SquareTileFrame(pt.X, pt.Y);
				}
			}
			if (++currentGap > b)
			{
				currentGap = 0;
			}
			NetMessage.SendTileSquare(-1, pt.X, pt.Y, 1);
			return true;
		}
	}
}
