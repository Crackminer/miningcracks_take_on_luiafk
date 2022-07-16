using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class FishingBiomeBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fishing Biome Builder");
			base.Tooltip.SetDefault("Builds a biome for fishing.\nRight-click to choose options.\nSelect obsidian to place jungle or mushroom wall behind the tiles.\nSelect wood/stone material for outer barrier.\nToggle the light to choose whether you want it lit or not.\nPearlstone/Hallow Ice only usable in Hardmode.\nBiome takes up a 22 x 18 block space, click where you want the bottom right tile.");
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

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<FishingBiomeUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<FishingBiomeUI>());
					UILearning.RightClickUIs<FishingBiomeUI>().buttonUpdates();
					if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On) Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			player.rulerLine = true;
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<FishingBiomeUI>().holding = true;
			}
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			if (player.whoAmI == Main.myPlayer && !player.noBuilding)
			{
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				int tileTargetX = Player.tileTargetX;
				int tileTargetY = Player.tileTargetY;
				if (Main.netMode == 0)
				{
					HandleBuilding(tileTargetX, tileTargetY, modPlayer.uiBiome, modPlayer.uiMaterial, modPlayer.uiObsidian, modPlayer.uiLight);
				}
				else
				{
					FishingPacket(tileTargetX, tileTargetY, modPlayer.uiBiome, modPlayer.uiMaterial, modPlayer.uiObsidian, modPlayer.uiLight);
				}
			}
			return true;
		}

		private static void FishingPacket(int x, int y, int tileType, int wallType, bool obsidian, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(7);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(tileType);
			((BinaryWriter)packet).Write(wallType);
			((BinaryWriter)packet).Write(obsidian);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int x, int y, int tileType, int wallType, bool obsidian, bool lights)
		{
			if (!Main.hardMode && (tileType == 5 || tileType == 8))
			{
				return;
			}
			int[,] array = new int[18, 22]
			{
				{
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 3, 2, 2,
					2, 2, 2, 2, 3, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 3, 2, 2,
					2, 2, 2, 2, 3, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1
				}
			};
			int[,] array2 = new int[18, 22]
			{
				{
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 3, 2, 0,
					2, 0, 2, 0, 2, 3, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 3, 2, 0,
					2, 0, 2, 0, 2, 3, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				},
				{
					1, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 0, 2, 0, 2, 0, 2, 0, 2, 0,
					2, 1
				},
				{
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1
				}
			};
			int type = 0;
			int type2 = ButtonBox.BuildingTileType(wallType);
			int num = ButtonBox.BiomeCreatorType(tileType);
			if (lights)
			{
				int type3;
				switch (tileType)
				{
				case 0:
					type3 = LuiafkMod.Instance.Find<ModTile>("CrimstoneLit").Type;
					break;
				case 1:
					type3 = LuiafkMod.Instance.Find<ModTile>("EbonstoneLit").Type;
					break;
				case 2:
					type3 = LuiafkMod.Instance.Find<ModTile>("IceLit").Type;
					break;
				case 3:
				case 4:
					type3 = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
					break;
				case 5:
					type3 = LuiafkMod.Instance.Find<ModTile>("PearlstoneLit").Type;
					break;
				case 6:
					type3 = LuiafkMod.Instance.Find<ModTile>("CrimsonIceLit").Type;
					break;
				case 7:
					type3 = LuiafkMod.Instance.Find<ModTile>("CorruptIceLit").Type;
					break;
				default:
					type3 = LuiafkMod.Instance.Find<ModTile>("HallowIceLit").Type;
					break;
				}
				type = type3;
			}
			for (int num2 = 17; num2 >= 0; num2--)
			{
				for (int num3 = 21; num3 >= 0; num3--)
				{
					int num4 = x - num3;
					int num5 = y - num2;
					TileChecks.TileSafe(num4, num5);
					if (TileChecks.InGameWorld(num4, num5) && TileChecks.NoOrbOrAltar(num4, num5) && TileChecks.NoTemple(num4, num5))
					{
						TileChecks.ClearEverything(num4, num5);
						if (obsidian && (tileType == 3 || tileType == 4) && num2 > 0 && num2 < 17 && num3 > 0 && num3 < 21)
						{
							WorldGen.PlaceWall(num4, num5, (tileType == 3) ? 67 : 74, mute: true);
						}
						if ((array[num2, num3] == 1 && tileType != 3 && tileType != 4) || (array2[num2, num3] == 1 && (tileType == 3 || tileType == 4)))
						{
							WorldGen.PlaceTile(num4, num5, type2, mute: true);
						}
						else if (((array[num2, num3] == 2 || (array[num2, num3] == 3 && !lights)) && tileType != 3 && tileType != 4) || (array2[num2, num3] == 2 && (tileType == 3 || tileType == 4)))
						{
							WorldGen.PlaceTile(num4, num5, num, mute: true);
						}
						if (array2[num2, num3] == 2 && tileType == 3)
						{
							WorldGen.PlaceTile(num4, num5, num + 1, mute: true);
						}
						if (array2[num2, num3] == 2 && tileType == 4)
						{
							WorldGen.PlaceTile(num4, num5, num + 11, mute: true);
						}
						if (array[num2, num3] == 3 && lights && tileType != 3 && tileType != 4)
						{
							WorldGen.PlaceTile(num4, num5, type, mute: true);
						}
						else if (array2[num2, num3] == 3 && lights && (tileType == 3 || tileType == 4))
						{
							WorldGen.PlaceTile(num4, num5, type, mute: true);
						}
						TileChecks.SquareUpdate(num4, num5);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(167, 30).AddIngredient(3, 100).AddRecipeGroup("Wood", 100)
				.AddRecipeGroup("Luiafk:EvilStoneBlock", 100)
				.AddRecipeGroup("Luiafk:IceSnowBlock", 100)
				.AddIngredient(176, 100)
				.AddIngredient(195, 10)
				.AddIngredient(194, 10)
				.AddTile(16)
				.Register();
		}
	}
}
