using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class FishingBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Pool Builder");
			base.Tooltip.SetDefault("Use to build a fishing pool or place/remove liquid.\nRight-click to choose options.\nWorks like the Ultimate Liquid Manipulator when Fishing Pool Builder is off.\nWith Fishing Pool Builder on using it will create a fishing pool with your chosen liquid.\nPool will be empty if you choose the sponge (no platforms or outer tiles).\nWith obsidian on a back wall will be placed (sponge included).\nPool takes up a 22 x 18 block space, click where you want the top right tile.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.useTurn = true;
			base.Item.useAnimation = 12;
			base.Item.useTime = 5;
			base.Item.autoReuse = true;
			base.Item.consumable = false;
			Defaults.Base(base.Item);
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<PoolBuilderUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<PoolBuilderUI>());
					UILearning.RightClickUIs<PoolBuilderUI>().buttonUpdates();
				}
				return false;
			}
			if (player.GetModPlayer<LuiafkPlayer>().uiPoolBuild)
			{
				base.Item.autoReuse = false;
				base.Item.useTime = 90;
				base.Item.useAnimation = 90;
			}
			else
			{
				base.Item.autoReuse = true;
				base.Item.useTime = 5;
				base.Item.useAnimation = 12;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				player.rulerLine = true;
				UILearning.RightClickUIs<PoolBuilderUI>().holding = true;
				if (!player.GetModPlayer<LuiafkPlayer>().uiPoolBuild)
				{
					Liquids.HoldBucket(player);
				}
				else if (!Main.GamepadDisableCursorItemIcon && !player.mouseInterface && !Main.mouseText)
				{
					player.cursorItemIconEnabled = true;
					Main.ItemIconCacheUpdate(base.Item.type);
					player.cursorItemIconID = base.Item.type;
				}
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
				if (!modPlayer.uiPoolBuild)
				{
					return Liquids.UseUltBucket(player);
				}
				int tileTargetX = Player.tileTargetX;
				int y = Player.tileTargetY + 17;
				if (Main.netMode == 0)
				{
					HandleBuilding(tileTargetX, y, modPlayer.uiMaterial, modPlayer.uiBucketType, modPlayer.uiObsidian);
				}
				else
				{
					FishingPacket(tileTargetX, y, modPlayer.uiMaterial, modPlayer.uiBucketType, modPlayer.uiObsidian);
				}
			}
			return true;
		}

		private static void FishingPacket(int x, int y, int tileType, int liquid, bool obsidian)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(5);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(tileType);
			((BinaryWriter)packet).Write(liquid);
			((BinaryWriter)packet).Write(obsidian);
			packet.Send();
		}

		internal static void HandleBuilding(int x, int y, int tileType, int liquid, bool obsidian)
		{
			int[,] array = new int[18, 22]
			{
				{
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
					1, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
					0, 1
				},
				{
					1, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
					2, 1
				}
			};
			int type = ButtonBox.BuildingWallType(tileType);
			int type2 = ButtonBox.BuildingTileType(tileType);
			int num = ((tileType > 1) ? ButtonBox.PlatformStyle(tileType - 2) : 0);
			for (int num2 = 17; num2 >= 0; num2--)
			{
				for (int num3 = 21; num3 >= 0; num3--)
				{
					int num4 = x - num3;
					int num5 = y - num2;
					TileChecks.TileSafe(num4, num5);
					if (TileChecks.InGameWorld(num4, num5) && TileChecks.NoTempleOrGolemIsDead(num4, num5))
					{
						TileChecks.ClearEverything(num4, num5);
						if (array[num2, num3] == 0 && liquid > 0)
						{
							Tile tile = Main.tile[num4, num5];
							Main.tile[num4, num5].LiquidAmount = byte.MaxValue;
							switch (liquid)
							{
							case 2:
								tile.LiquidType = 1;
								break;
							case 3:
								tile.LiquidType = 2;
								break;
							}
						}
						if (Main.netMode == 2)
						{
							NetMessage.sendWater(num4, num5);
						}
						if (obsidian && num2 > 0 && num2 < 17 && num3 > 0 && num3 < 21)
						{
							WorldGen.PlaceWall(num4, num5, type, mute: true);
						}
						if (liquid > 0)
						{
							if (array[num2, num3] == 1)
							{
								WorldGen.PlaceTile(num4, num5, type2, mute: true);
							}
							else if (array[num2, num3] == 2)
							{
								WorldGen.PlaceTile(num4, num5, 19, mute: true, forced: false, -1, (tileType > 1) ? num : 0);
							}
						}
						TileChecks.SquareUpdate(num4, num5);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UltimateBucket").Type).AddIngredient(2341).AddIngredient(167, 30)
				.AddIngredient(3, 250)
				.AddRecipeGroup("Wood", 250)
				.AddTile(16)
				.Register();
		}
	}
}
