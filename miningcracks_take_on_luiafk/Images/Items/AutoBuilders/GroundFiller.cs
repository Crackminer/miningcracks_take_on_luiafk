using System.IO;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class GroundFiller : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Dirt Rod 2.0");
			base.Tooltip.SetDefault("Right-click to change modes.\nMode 1: Levels and fills the ground beneath you, 300 wide, 50 deep.\nMode 2: Also clears 50 tiles up.\nMode 3: Also works on Dungeon, Temple, and Underground Desert, leaving background wall.\nModded tiles will be replaced with vanilla tiles.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item, 90);
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer && !player.noBuilding)
			{
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				Point16 point = TileChecks.PlayerCenterTile(player);
				if (player.altFunctionUse == 2)
				{
					modPlayer.fillerMode++;
					if (modPlayer.fillerMode == 3)
					{
						modPlayer.fillerMode = 0;
					}
					switch (modPlayer.fillerMode)
					{
					case 0:
						Main.NewText((object)"Fill below only.", (Color?)new Color(255, 0, 0, 0));
						break;
					case 1:
						Main.NewText((object)"Fill below and clear above.", (Color?)new Color(255, 255, 0, 0));
						break;
					case 2:
						Main.NewText((object)"Fill below and clear above. Leaves Dungeon, Underground Desert, and Temple walls in place.", (Color?)new Color(0, 255, 0, 0));
						break;
					}
					return true;
				}
				if (Main.netMode == 0)
				{
					HandleBuilding(point.X, point.Y, modPlayer.fillerMode);
					return true;
				}
				FillPacket(point.X, point.Y, modPlayer.fillerMode);
			}
			return true;
		}

		private static void FillPacket(int x, int y, int mode)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(11);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(mode);
			packet.Send();
		}

		internal static void HandleBuilding(int x, int y, int mode)
		{
			int type = 1;
			int type2 = 1;
			int[] array = new int[34]
			{
				0, 1, 2, 23, 25, 53, 57, 59, 109, 112,
				116, 117, 147, 151, 161, 163, 164, 189, 196, 199,
				200, 202, 203, 234, 367, 368, 396, 397, 398, 399,
				400, 401, 402, 403
			};
			for (int i = 0; i < 50; i++)
			{
				for (int j = 0; j < 150; j++)
				{
					int num = (int)MathHelper.Clamp((float)(x - j), 0f, (float)(Main.maxTilesX - 1));
					int num2 = (int)MathHelper.Clamp((float)(x + j), 0f, (float)(Main.maxTilesX - 1));
					int num3 = (int)MathHelper.Clamp((float)(y + 51 - i), 0f, (float)(Main.maxTilesY - 1));
					int y2 = (int)MathHelper.Clamp((float)(y - 48 + i), 0f, (float)(Main.maxTilesY - 1));
					TileChecks.TileSafe(num, num3);
					TileChecks.TileSafe(num2, num3);
					TileChecks.TileSafe(num, y2);
					TileChecks.TileSafe(num2, y2);
					for (int k = 0; k < array.Length; k++)
					{
						if (TileChecks.InGameWorldLeft(num) && TileChecks.InGameWorldBottom(num3) && WorldGen.SolidTile(num, num3) && Main.tile[num, num3].TileType == array[k])
						{
							type = Main.tile[num, num3].TileType;
						}
						if (TileChecks.InGameWorldRight(num2) && TileChecks.InGameWorldBottom(num3) && WorldGen.SolidTile(num2, num3) && Main.tile[num2, num3].TileType == array[k])
						{
							type2 = Main.tile[num2, num3].TileType;
						}
					}
					if (mode > 1)
					{
						SpecialFillDown(num, num3);
						SpecialFillDown(num2, num3);
						SpecialClearUp(num, y2);
						SpecialClearUp(num2, y2);
					}
					if (mode > 0)
					{
						ClearUp(num, y2);
						ClearUp(num2, y2);
					}
					FillDown(num, num3, type);
					FillDown(num2, num3, type2);
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(114).AddIngredient(base.Mod.Find<ModItem>("UnlimitedDynamite").Type).AddIngredient(3, 1998)
				.AddIngredient(2, 1998)
				.AddIngredient(169, 1998)
				.AddIngredient(176, 1998)
				.AddIngredient(172, 999)
				.AddIngredient(409, 999)
				.AddRecipeGroup("Luiafk:EvilStoneBlock", 999)
				.AddIngredient(3086, 499)
				.AddIngredient(3081, 499)
				.AddIngredient(1101, 499)
				.AddRecipeGroup("Luiafk:DungeonBrick", 499)
				.AddTile(134)
				.Register();
		}

		private static void Change(int x, int y, int type = -1)
		{
			TileChecks.ClearEverything(x, y);
			if (type != -1)
			{
				WorldGen.PlaceTile(x, y, type, mute: true);
			}
			TileChecks.SquareUpdate(x, y);
		}

		private static void FillDown(int x, int y, int type)
		{
			if (TileChecks.InGameWorld(x, y) && TileChecks.NoTemple(x, y) && TileChecks.NoBlueDungeon(x, y) && TileChecks.NoGreenDungeon(x, y) && TileChecks.NoPinkDungeon(x, y) && TileChecks.NoUndergroundDesert(x, y) && TileChecks.NoOrbOrAltar(x, y))
			{
				Change(x, y, type);
			}
		}

		private static void ClearUp(int x, int y)
		{
			if (TileChecks.InGameWorld(x, y) && TileChecks.NoTemple(x, y) && TileChecks.NoBlueDungeon(x, y) && TileChecks.NoGreenDungeon(x, y) && TileChecks.NoPinkDungeon(x, y) && TileChecks.NoUndergroundDesert(x, y))
			{
				Change(x, y);
			}
		}

		private static void SpecialClearUp(int x, int y)
		{
			if (TileChecks.InGameWorld(x, y) && (TileChecks.TempleAndGolemIsDead(x, y) || !TileChecks.NoBlueDungeon(x, y) || !TileChecks.NoGreenDungeon(x, y) || !TileChecks.NoPinkDungeon(x, y)))
			{
				TileChecks.ClearLiquid(x, y);
				TileChecks.ClearTileWithNet(x, y);
			}
		}

		private static void SpecialFillDown(int x, int y)
		{
			ushort num = 1;
			if (TileChecks.InGameWorld(x, y) && TileChecks.NoOrbOrAltar(x, y))
			{
				if (TileChecks.TempleAndGolemIsDead(x, y))
				{
					num = 226;
				}
				else if (!TileChecks.NoBlueDungeon(x, y))
				{
					num = 41;
				}
				else if (!TileChecks.NoPinkDungeon(x, y))
				{
					num = 44;
				}
				else if (!TileChecks.NoGreenDungeon(x, y))
				{
					num = 43;
				}
				else if (Main.tile[x, y].WallType == 187)
				{
					num = 397;
				}
				else if (Main.tile[x, y].WallType == 220)
				{
					num = 398;
				}
				else if (Main.tile[x, y].WallType == 221)
				{
					num = 399;
				}
				else if (Main.tile[x, y].WallType == 222)
				{
					num = 402;
				}
				if (num != 1)
				{
					Change(x, y, num);
				}
			}
		}
	}
}
