using System;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class SmartCursor
	{
		internal static Point16 FindLine(Player player, LuiafkPlayer luiP, Drilling.DrillData data = null)
		{
																																																												Vector2 center = player.Center;
			Vector2 val = Main.MouseWorld - center;
			Vector2 val2 = val;
			float num = val2.Length();
			float num2 = num;
			float num3 = 1000f;
			if (num > num3)
			{
				num = num3;
			}
			num += 32f;
			val = ((num2 > 0f) ? (val / num2) : Vector2.Zero);
			Vector2 end = center + val * num;
			Point16 point = Point16.NegativeOne;
			if (!Utils.PlotTileLine(center, end, 65.6f, delegate(int x, int y)
			{
				point = new Point16(x, y);
				for (int i = 0; i < data.beams.Length; i++)
				{
					if (data.beams[i].curTileTarget == point)
					{
						return true;
					}
				}
				Tile tileSafely = Framing.GetTileSafely(x, y);
				if (luiP.drillMode == DrillMode.Both)
				{
					if (tileSafely.WallType == 0)
					{
						if (WorldGen.CanKillTile(x, y) && !tileSafely.IsActuated)
						{
							return !tileSafely.HasTile;
						}
						return true;
					}
					return false;
				}
				if (luiP.drillMode == DrillMode.Walls)
				{
					return tileSafely.WallType == 0;
				}
				return luiP.drillMode != DrillMode.Tiles || !WorldGen.CanKillTile(x, y) || tileSafely.IsActuated || !tileSafely.HasTile;
			}))
			{
				return point;
			}
			return Point16.NegativeOne;
		}

		internal static Point16 FindClosestToPosition(FindType findType, Player player, Vector2 pos)
		{
									LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			UILearning.RightClickUIs<PaintToolUI>();
			int tileBoost = player.inventory[player.selectedItem].tileBoost;
			int num = (int)MathHelper.Clamp(player.position.X / 16f - (float)Player.tileRangeX - (float)tileBoost + 1f, 10f, (float)(Main.maxTilesX - 10));
			int num2 = (int)MathHelper.Clamp((player.position.X + (float)player.width) / 16f + (float)Player.tileRangeX + (float)tileBoost, 10f, (float)(Main.maxTilesX - 10));
			int num3 = (int)MathHelper.Clamp(player.position.Y / 16f - (float)Player.tileRangeY - (float)tileBoost + 1f, 10f, (float)(Main.maxTilesY - 10));
			int num4 = (int)MathHelper.Clamp((player.position.Y + (float)player.height) / 16f + (float)Player.tileRangeY + (float)tileBoost, 10f, (float)(Main.maxTilesY - 10));
			Point16 closestMatch = Point16.NegativeOne;
			float closestMatchDistance = float.MaxValue;
			int uiPaintType = modPlayer.uiPaintType;
			for (int i = num; i < num2; i++)
			{
				for (int j = num3; j < num4; j++)
				{
					if (findType == FindType.Box)
					{
						ChangeClosest(ref closestMatch, i, j, pos, ref closestMatchDistance);
						continue;
					}
					Tile tile = Main.tile[i, j];
					if (tile != null && (((modPlayer.uiPaintMode & PaintType.Tile) != 0 && (modPlayer.uiPaintMode & PaintType.Remove) == 0 && tile.HasTile && tile.TileColor != uiPaintType) || ((modPlayer.uiPaintMode & PaintType.Wall) != 0 && (modPlayer.uiPaintMode & PaintType.Remove) == 0 && tile.WallType != 0 && tile.WallColor != uiPaintType) || ((modPlayer.uiPaintMode & PaintType.Remove) != 0 && (((modPlayer.uiPaintMode & PaintType.Tile) != 0 && tile.HasTile && tile.TileColor != 0) || ((modPlayer.uiPaintMode & PaintType.Wall) != 0 && tile.WallType != 0 && tile.WallColor != 0)))))
					{
						ChangeClosest(ref closestMatch, i, j, pos, ref closestMatchDistance);
					}
				}
			}
			return closestMatch;
		}

		private static void ChangeClosest(ref Point16 closestMatch, int i, int j, Vector2 closestTo, ref float closestMatchDistance)
		{
									float num = Vector2.DistanceSquared(new Vector2((float)i, (float)j), closestTo);
			if (num < closestMatchDistance)
			{
				closestMatch = new Point16(i, j);
				closestMatchDistance = num;
			}
		}

		internal static bool OutOfRange(Player p, Item item, int x, int y)
		{
			if (item.type == LuiafkMod.Instance.Find<ModItem>("ComboRod").Type)
			{
				return false;
			}
			if (!OutOfRangeX(p, item, x, y))
			{
				return OutOfRangeY(p, item, x, y);
			}
			return true;
		}

		internal static bool OutOfRangeX(Player p, Item item, int x, int y)
		{
			if (!((float)x <= p.position.X / 16f - (float)Player.tileRangeX - (float)item.tileBoost))
			{
				return (float)x >= (p.position.X + (float)p.width) / 16f + (float)Player.tileRangeX + (float)item.tileBoost - 1f;
			}
			return true;
		}

		internal static bool OutOfRangeY(Player p, Item item, int x, int y)
		{
			if (!((float)y <= p.position.Y / 16f - (float)Player.tileRangeY - (float)item.tileBoost))
			{
				return (float)y >= (p.position.Y + (float)p.height) / 16f + (float)Player.tileRangeY + (float)item.tileBoost - 1f;
			}
			return true;
		}

		internal static void BoxPlace(Player player, BoxPlace info, BoxType bt)
		{
			int num = Math.Min(info.Start.X, info.End.X);
			int num2 = Math.Max(info.Start.X, info.End.X);
			int num3 = Math.Min(info.Start.Y, info.End.Y);
			int num4 = Math.Max(info.Start.Y, info.End.Y);
			PaintToolUI ui = UILearning.RightClickUIs<PaintToolUI>();
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (bt == BoxType.Liquid)
			{
				if (Main.netMode == 0)
				{
					Liquids.HandleBox(num, num2, num3, num4, modPlayer.uiBucketType);
				}
				else
				{
					Liquids.SendBox(num, num2, num3, num4, modPlayer.uiBucketType);
				}
				return;
			}
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					switch (bt)
					{
					case BoxType.Paint:
						PaintStuff(player, modPlayer, ui, i, j);
						break;
					case BoxType.Wall:
						if (Framing.GetTileSafely(i, j).WallType == 0)
						{
							WorldGen.PlaceWall(i, j, player.inventory[48].createWall, mute: true);
							TileChecks.SquareUpdate(i, j);
							player.inventory[48].stack--;
							if (player.inventory[48].stack <= 0)
							{
								player.inventory[48] = new Item();
								return;
							}
						}
						break;
					}
				}
			}
		}

		internal static bool PaintUseItem(Player p)
		{
			if (p.whoAmI != Main.myPlayer || !p.controlUseItem)
			{
				return true;
			}
			PaintToolUI paintToolUI = UILearning.RightClickUIs<PaintToolUI>();
			if (paintToolUI.target == Point16.NegativeOne)
			{
				return true;
			}
			PaintStuff(p, p.GetModPlayer<LuiafkPlayer>(), paintToolUI, paintToolUI.target.X, paintToolUI.target.Y);
			return true;
		}

		internal static void PaintStuff(Player p, LuiafkPlayer luiP, PaintToolUI ui, int i, int j)
		{
			TileChecks.TileSafe(i, j);
			Tile tile = Main.tile[i, j];
			if ((luiP.uiPaintMode & PaintType.Tile) != 0)
			{
				if ((luiP.uiPaintMode & PaintType.Remove) != 0)
				{
					tile.TileColor = 0;
				}
				else
				{
					tile.TileColor = (byte)luiP.uiPaintType;
				}
				if (Main.netMode == 1)
				{
					NetMessage.SendData(63, -1, -1, null, i, j, ((luiP.uiPaintMode & PaintType.Remove) != 0) ? 0f : ((float)luiP.uiPaintType));
				}
			}
			if ((luiP.uiPaintMode & PaintType.Wall) != 0)
			{
				if ((luiP.uiPaintMode & PaintType.Remove) != 0)
				{
					tile.WallColor = 0;
				}
				else
				{
					tile.WallColor = (byte)luiP.uiPaintType;
				}
				if (Main.netMode == 1)
				{
					NetMessage.SendData(64, -1, -1, null, i, j, ((luiP.uiPaintMode & PaintType.Remove) != 0) ? 0f : ((float)luiP.uiPaintType));
				}
			}
		}
	}
}
