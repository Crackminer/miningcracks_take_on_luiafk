using System.IO;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Solutions
{
	public class UnlimitedMultiSolution : ModItem
	{
		private static readonly ushort[] grassWallArray = new ushort[9] { 63, 69, 81, 80, 70, 64, 40, 14, 73 };

		private static readonly ushort[] stoneWallArray = new ushort[9] { 1, 3, 83, 80, 28, 64, 71, 14, 73 };

		private static readonly ushort[] hardenedSandWallArray = new ushort[9] { 216, 217, 218, 80, 219, 64, 71, 14, 73 };

		private static readonly ushort[] sandstoneWallArray = new ushort[9] { 187, 220, 221, 80, 222, 64, 71, 14, 73 };

		private static readonly ushort[] mossStoneTileArray = new ushort[9] { 1, 25, 203, 59, 117, 59, 161, 57, 196 };

		private static readonly ushort[] grassTileArray = new ushort[9] { 2, 23, 199, 59, 109, 59, 147, 57, 189 };

		private static readonly ushort[] iceTileArray = new ushort[9] { 1, 163, 200, 59, 164, 59, 161, 57, 196 };

		private static readonly ushort[] sandTileArray = new ushort[9] { 53, 112, 234, 59, 116, 59, 147, 57, 189 };

		private static readonly ushort[] hardenedSandTileArray = new ushort[9] { 397, 398, 399, 59, 402, 59, 161, 57, 189 };

		private static readonly ushort[] sandstoneTileArray = new ushort[9] { 396, 400, 401, 59, 403, 59, 161, 57, 196 };

		private static readonly ushort[] thornsTileArray = new ushort[9] { 52, 32, 352, 59, 115, 69, 161, 57, 196 };

		private static readonly ushort[] dirtTileArray = new ushort[9] { 0, 0, 0, 59, 0, 59, 147, 57, 189 };

		private static readonly ushort[] snowTileArray = new ushort[9] { 0, 147, 147, 59, 147, 59, 147, 57, 189 };

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Multi Solution");
			base.Tooltip.SetDefault("Change biomes however you want.\nRight-click to choose biome.\nWorks like normal solution if used with Clentaminator.\nGreen Solution will be used if Hell/Cloud/Ice Solution are chosen.\nCan also be used as an item.\nClick a tile to select it as the corner of a rectangle.\nOnce you've selected 2 points right-click and click the convert button.\nThe area inside of those 2 points will then be converted.\nMushroom biome and new biomes will convert the same tiles as Jungle solution.\nAll biomes will convert Jungle/Mushroom/Cloud/Hell/Snow.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 4;
			base.Item.useTurn = true;
			base.Item.useAnimation = 45;
			base.Item.useTime = 45;
			base.Item.autoReuse = false;
			base.Item.consumable = false;
			base.Item.ammo = AmmoID.Solution;
			base.Item.maxStack = 1;
			base.Item.width = 20;
			base.Item.height = 20;
			base.Item.value = 1;
			base.Item.rare = 10;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<MultiSolutionUI>().holding = true;
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			base.Item.shoot = 0;
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<MultiSolutionUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<MultiSolutionUI>());
				}
				return false;
			}
			return true;
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2) return false;
				if (player.whoAmI == Main.myPlayer)
			{
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				if (modPlayer.uiMultiSolutionTileX[2] == -1)
				{
					modPlayer.uiMultiSolutionTileX[0] = Player.tileTargetX;
					modPlayer.uiMultiSolutionTileY[0] = Player.tileTargetY;
					modPlayer.uiMultiSolutionTileX[2] = 1;
					TileChecks.PrintCoords(modPlayer.uiMultiSolutionTileX[0], modPlayer.uiMultiSolutionTileY[0], new Color(255, 0, 255), "Location saved.");
				}
				else
				{
					modPlayer.uiMultiSolutionTileX[1] = Player.tileTargetX;
					modPlayer.uiMultiSolutionTileY[1] = Player.tileTargetY;
					modPlayer.uiMultiSolutionTileX[2] = -1;
					TileChecks.PrintCoords(modPlayer.uiMultiSolutionTileX[1], modPlayer.uiMultiSolutionTileY[1], new Color(0, 255, 255), "Location saved.");
				}
			}
			return true;
		}

		internal static void ConvertClicked()
		{
			LuiafkPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>();
			if (modPlayer.uiMultiSolutionTileX[0] != -1 && modPlayer.uiMultiSolutionTileX[1] != -1)
			{
				if (Main.netMode == 0)
				{
					HandleConvert(modPlayer.uiMultiSolutionTileX[0], modPlayer.uiMultiSolutionTileX[1], modPlayer.uiMultiSolutionTileY[0], modPlayer.uiMultiSolutionTileY[1], modPlayer.uiMultiSolutionType);
				}
				else if (Main.netMode == 1)
				{
					SolutionPacket(modPlayer.uiMultiSolutionTileX[0], modPlayer.uiMultiSolutionTileX[1], modPlayer.uiMultiSolutionTileY[0], modPlayer.uiMultiSolutionTileY[1], modPlayer.uiMultiSolutionType);
				}
			}
		}

		private static void SolutionPacket(int x, int xx, int y, int yy, int solution)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(9);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(xx);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(yy);
			((BinaryWriter)packet).Write(solution);
			packet.Send();
		}

		internal static void HandleConvert(int x, int xx, int y, int yy, int solution)
		{
			ushort num = grassWallArray[solution];
			ushort num2 = stoneWallArray[solution];
			ushort num3 = hardenedSandWallArray[solution];
			ushort num4 = sandstoneWallArray[solution];
			ushort num5 = mossStoneTileArray[solution];
			ushort num6 = grassTileArray[solution];
			ushort num7 = iceTileArray[solution];
			ushort num8 = sandTileArray[solution];
			ushort num9 = hardenedSandTileArray[solution];
			ushort num10 = sandstoneTileArray[solution];
			_ = thornsTileArray[solution];
			ushort num11 = dirtTileArray[solution];
			ushort num12 = snowTileArray[solution];
			int num13 = ((x > xx) ? xx : x);
			int num14 = ((x > xx) ? x : xx);
			int num15 = ((y > yy) ? yy : y);
			int num16 = ((y > yy) ? y : yy);
			if (num13 < 45)
			{
				num13 = 0;
			}
			if (num14 > Main.maxTilesX - 45)
			{
				num14 = Main.maxTilesX;
			}
			if (num15 < 45)
			{
				num15 = 0;
			}
			if (num16 > Main.maxTilesY - 45)
			{
				num16 = Main.maxTilesY;
			}
			for (int i = num13; i < num14; i++)
			{
				for (int j = num15; j < num16; j++)
				{
					Tile tile = Main.tile[i, j];
					if (Main.tile[i, j] == null)
					{
						continue;
					}
					int tileType = tile.TileType;
					int wallType = tile.WallType;
					if (tile.WallType != 0)
					{
						if (wallType != num && wallType != 71 && ((wallType >= 63 && wallType < 82) || wallType == 40 || wallType == 14 || wallType == 2))
						{
							tile.WallType = num;
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else if (wallType != num2 && (wallType == 1 || wallType == 3 || wallType == 28 || wallType == 83 || wallType == 64 || wallType == 71))
						{
							tile.WallType = num2;
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else if (wallType != num3 && (wallType == 216 || wallType == 217 || wallType == 218 || wallType == 219))
						{
							tile.WallType = num3;
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else if (wallType != num4 && (wallType == 187 || wallType == 220 || wallType == 221 || wallType == 222))
						{
							tile.WallType = num4;
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
					}
					if (!tile.HasTile)
					{
						continue;
					}
					if (tileType != num5 && (tileType == 1 || (tileType >= 179 && tileType < 184) || tileType == 381 || tileType == 25 || tileType == 117 || tileType == 203 || tileType == 57 || tileType == 196))
					{
						tile.TileType = num5;
						if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num12 && tileType == 147)
					{
						tile.TileType = num12;
						if ((solution == 5 || solution == 3 || solution == 0) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							switch (solution)
							{
							case 0:
								tile.TileType = 2;
								break;
							case 3:
								tile.TileType = 70;
								break;
							case 5:
								tile.TileType = 60;
								break;
							}
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num11 && (tileType == 0 || tileType == 59 || tileType == 189))
					{
						tile.TileType = num11;
						if (TileChecks.PlaceGrassTileCheck(i, j))
						{
							switch (solution)
							{
							case 0:
								tile.TileType = 2;
								break;
							case 1:
								tile.TileType = 23;
								break;
							case 2:
								tile.TileType = 199;
								break;
							case 3:
								tile.TileType = 70;
								break;
							case 4:
								tile.TileType = 109;
								break;
							case 5:
								tile.TileType = 60;
								break;
							}
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType == 3 || tileType == 24 || tileType == 61 || tileType == 73 || tileType == 74 || tileType == 110 || tileType == 113 || tileType == 201 || tileType == 32 || tileType == 352 || tileType == 69 || tileType == 165 || tileType == 205 || tileType == 115)
					{
						tile.ClearTile();
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num6 && (tileType == 2 || tileType == 23 || tileType == 60 || tileType == 199 || tileType == 109 || tileType == 70))
					{
						tile.TileType = num6;
						if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num7 && (tileType == 161 || tileType == 163 || tileType == 200 || tileType == 164))
					{
						tile.TileType = num7;
						if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num8 && (tileType == 53 || tileType == 112 || tileType == 234 || tileType == 116))
					{
						if (Main.tile[i, j - 1].TileType != 80 || (solution >= 0 && solution < 3) || solution == 4)
						{
							tile.TileType = num8;
							if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
							{
								tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
							}
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
						else
						{
							tile.TileType = 53;
							NetMessage.SendTileSquare(-1, i, j, 1);
						}
					}
					else if (tileType != num9 && (tileType == 397 || tileType == 398 || tileType == 399 || tileType == 402))
					{
						tile.TileType = num9;
						if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
					else if (tileType != num10 && (tileType == 396 || tileType == 400 || tileType == 403 || tileType == 401))
					{
						tile.TileType = num10;
						if ((solution == 5 || solution == 3) && TileChecks.PlaceGrassTileCheck(i, j))
						{
							tile.TileType = (ushort)((solution == 5) ? 60u : 70u);
						}
						NetMessage.SendTileSquare(-1, i, j, 1);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "UnlimitedBlueSolution").AddIngredient(null, "UnlimitedDarkBlueSolution").AddIngredient(null, "UnlimitedDarkGreenSolution")
				.AddIngredient(null, "UnlimitedGreenSolution")
				.AddIngredient(null, "UnlimitedPurpleSolution")
				.AddIngredient(null, "UnlimitedRedSolution")
				.AddTile(18)
				.Register();
		}
	}
}
