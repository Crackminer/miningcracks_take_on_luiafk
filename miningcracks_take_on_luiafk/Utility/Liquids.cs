using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Utility
{
	internal static class Liquids
	{
		internal static void SendBox(int x, int xx, int y, int yy, int liquid)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(24);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(xx);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(yy);
			((BinaryWriter)packet).Write(liquid);
			packet.Send();
		}

		internal static void HandleBox(int x, int xx, int y, int yy, int liquid)
		{
			LiquidTypes type = (LiquidTypes)((byte)liquid - 1);
			for (int i = x; i <= xx; i++)
			{
				for (int j = y; j <= yy; j++)
				{
					if (liquid == 0)
					{
						Sponge(i, j);
					}
					else
					{
						PlaceLiquid(i, j, type);
					}
				}
			}
		}

		internal static bool UseBucket(Player player, LiquidTypes type)
		{
									if (player.whoAmI == Main.myPlayer && !player.noBuilding && PlaceLiquid(Player.tileTargetX, Player.tileTargetY, type))
			{
				SoundEngine.PlaySound(in SoundID.Item19, (Vector2?)new Vector2((float)(int)player.position.X, (float)(int)player.position.Y));
			}
			return true;
		}

		internal static bool UseUltBucket(Player player)
		{
			if (player.whoAmI != Main.myPlayer || player.noBuilding)
			{
				return true;
			}
			return UseUltBucket(player, player.GetModPlayer<LuiafkPlayer>());
		}

		internal static bool UseUltBucket(Player player, LuiafkPlayer luiP)
		{
									if ((luiP.uiBucketType == 1 && PlaceLiquid(Player.tileTargetX, Player.tileTargetY, LiquidTypes.Water)) || (luiP.uiBucketType == 2 && PlaceLiquid(Player.tileTargetX, Player.tileTargetY, LiquidTypes.Lava)) || (luiP.uiBucketType == 3 && PlaceLiquid(Player.tileTargetX, Player.tileTargetY, LiquidTypes.Honey)) || (luiP.uiBucketType == 0 && Sponge(Player.tileTargetX, Player.tileTargetY)))
			{
				SoundEngine.PlaySound(in SoundID.Item19, (Vector2?)new Vector2((float)(int)player.position.X, (float)(int)player.position.Y));
			}
			return true;
		}

		internal static void HoldBucket(Player player)
		{
			if (!Main.GamepadDisableCursorItemIcon && !player.mouseInterface && !Main.mouseText)
			{
				player.cursorItemIconEnabled = true;
				switch (player.GetModPlayer<LuiafkPlayer>().uiBucketType)
				{
				case 0:
					Main.ItemIconCacheUpdate(LuiafkMod.Instance.Find<ModItem>("MultiPurposeSponge").Type);
					player.cursorItemIconID = LuiafkMod.Instance.Find<ModItem>("MultiPurposeSponge").Type;
					break;
				case 1:
					Main.ItemIconCacheUpdate(LuiafkMod.Instance.Find<ModItem>("UnlimitedWater").Type);
					player.cursorItemIconID = LuiafkMod.Instance.Find<ModItem>("UnlimitedWater").Type;
					break;
				case 2:
					Main.ItemIconCacheUpdate(LuiafkMod.Instance.Find<ModItem>("UnlimitedLava").Type);
					player.cursorItemIconID = LuiafkMod.Instance.Find<ModItem>("UnlimitedLava").Type;
					break;
				default:
					Main.ItemIconCacheUpdate(LuiafkMod.Instance.Find<ModItem>("UnlimitedHoney").Type);
					player.cursorItemIconID = LuiafkMod.Instance.Find<ModItem>("UnlimitedHoney").Type;
					break;
				}
			}
		}

		internal static bool PlaceLiquid(int x, int y, LiquidTypes type)
		{
			Tile tileSafely = Framing.GetTileSafely(x, y);
			if (tileSafely.LiquidAmount < 230 && (!tileSafely.HasUnactuatedTile || !Main.tileSolid[tileSafely.TileType] || Main.tileSolidTop[tileSafely.TileType]) && (tileSafely.LiquidAmount == 0 || tileSafely.LiquidType == (int)type))
			{
				tileSafely.LiquidType = (int)type;
				tileSafely.LiquidAmount = byte.MaxValue;
				WorldGen.SquareTileFrame(x, y);
				if (Main.netMode != 0)
				{
					NetMessage.sendWater(x, y);
				}
				return true;
			}
			return false;
		}

		internal static bool Sponge(int x, int y)
		{
			Tile tileSafely = Framing.GetTileSafely(x, y);
			if (tileSafely.LiquidType == 0 || tileSafely.LiquidType == 1 || tileSafely.LiquidType == 2)
			{
				int liquidType = tileSafely.LiquidType;
				int num = 0;
				for (int i = x - 1; i <= x + 1; i++)
				{
					for (int j = y - 1; j <= y + 1; j++)
					{
						TileChecks.TileSafe(i, j);
						if (Main.tile[i, j].LiquidType == liquidType)
						{
							num += Main.tile[i, j].LiquidAmount;
						}
					}
				}
				if (tileSafely.LiquidAmount > 0)
				{
					int liquidType2 = tileSafely.LiquidType;
					int num2 = tileSafely.LiquidAmount;
					tileSafely.LiquidAmount = 0;
					tileSafely.LiquidType = 3;
					tileSafely.LiquidType = 3;
					WorldGen.SquareTileFrame(x, y, resetFrame: false);
					if (Main.netMode != 0)
					{
						NetMessage.sendWater(x, y);
					}
					else
					{
						Liquid.AddWater(x, y);
					}
					for (int k = x - 1; k <= x + 1; k++)
					{
						for (int l = y - 1; l <= y + 1; l++)
						{
							Tile tileSafely2 = Framing.GetTileSafely(k, l);
							if (num2 < 256 && tileSafely2.LiquidType == liquidType)
							{
								int num3 = tileSafely2.LiquidAmount;
								if (num3 + num2 > 255)
								{
									num3 = 255 - num2;
								}
								num2 += num3;
								tileSafely2.LiquidAmount = (byte)(tileSafely2.LiquidAmount - (byte)num3);
								tileSafely2.LiquidType = liquidType2;
								if (tileSafely2.LiquidAmount == 0)
								{
									tileSafely2.LiquidType = 3;
									tileSafely2.LiquidType = 3;
								}
								WorldGen.SquareTileFrame(k, l, resetFrame: false);
								if (Main.netMode != 0)
								{
									NetMessage.sendWater(k, l);
								}
								else
								{
									Liquid.AddWater(k, l);
								}
							}
						}
					}
					return true;
				}
			}
			return false;
		}
	}
}
