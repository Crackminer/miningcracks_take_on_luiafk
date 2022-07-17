using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class Hellevator : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Auto Hellevator");
			base.Tooltip.SetDefault("Builds a hellevator.\nRight-click to choose options.\nWill be lit up all the way down if you have the light on.\nWill only place rope if you have one of the Unlimited Rope items in your inventory.\nClick where you want the top right hellevator wall.\nWill stop if it hits the Temple.\nHellevator is 7 tiles wide (5 tile hole).");
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
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<HellevatorUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<HellevatorUI>());
					UILearning.RightClickUIs<HellevatorUI>().buttonUpdates();
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
				UILearning.RightClickUIs<HellevatorUI>().holding = true;
			}
		}

		private static int RopeType(Player player)
		{
			int[,] obj = new int[12, 2]
			{
				{ 0, 213 },
				{ 0, 213 },
				{ 0, 353 },
				{ 0, 353 },
				{ 0, 365 },
				{ 0, 365 },
				{ 0, 366 },
				{ 0, 366 },
				{ 0, 449 },
				{ 0, 450 },
				{ 0, 451 },
				{ 0, 214 }
			};
			obj[0, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedRope").Type;
			obj[1, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedRopeCoil").Type;
			obj[2, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedVineRope").Type;
			obj[3, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedVineRopeCoil").Type;
			obj[4, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedSilkRope").Type;
			obj[5, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedSilkRopeCoil").Type;
			obj[6, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedWebRope").Type;
			obj[7, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedWebRopeCoil").Type;
			obj[8, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedBlueStreamer").Type;
			obj[9, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedGreenStreamer").Type;
			obj[10, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedPinkStreamer").Type;
			obj[11, 0] = LuiafkMod.Instance.Find<ModItem>("UnlimitedChain").Type;
			int[,] array = obj;
			for (int i = 0; i < 50; i++)
			{
				int type = player.inventory[i].type;
				for (int j = 0; j < array.GetLength(0); j++)
				{
					if (type == array[j, 0])
					{
						return array[j, 1];
					}
				}
			}
			return 0;
		}

		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			if (Main.myPlayer == player.whoAmI && !player.noBuilding)
			{
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				int tileTargetX = Player.tileTargetX;
				int tileTargetY = Player.tileTargetY;
				int num = RopeType(player);
				if (Main.netMode == 0)
				{
					HandleBuilding(ButtonBox.BuildingWallType(modPlayer.uiMaterial), ButtonBox.BuildingTileType(modPlayer.uiMaterial), tileTargetX, tileTargetY, modPlayer.uiRope ? num : 0, modPlayer.uiLight);
					return true;
				}
				HellevatorPacket(ButtonBox.BuildingWallType(modPlayer.uiMaterial), ButtonBox.BuildingTileType(modPlayer.uiMaterial), tileTargetX, tileTargetY, modPlayer.uiRope ? num : 0, modPlayer.uiLight);
			}
			return true;
		}

		private static void HellevatorPacket(int wall, int tile, int x, int y, int rope, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(1);
			((BinaryWriter)packet).Write(wall);
			((BinaryWriter)packet).Write(tile);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(rope);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int wall, int tile, int x, int y, int rope, bool lights)
		{
			int[] array = new int[7] { 1, 0, 0, 0, 0, 0, 1 };
			int type = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
			for (int i = 0; y + i < Main.maxTilesY - 41; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					int num = x - j;
					int num2 = y + i;
					TileChecks.TileSafe(num, num2);
					if (TileChecks.NoTemple(num, num2))
					{
						TileChecks.ClearEverything(num, num2);
						if (j > 0 && j < 6 && i > 0)
						{
							WorldGen.PlaceWall(num, num2, wall, mute: true);
						}
						if (rope != 0 && j == 3)
						{
							WorldGen.PlaceTile(num, num2, rope, mute: true);
						}
						if (array[j] == 1)
						{
							WorldGen.PlaceTile(num, num2, tile, mute: true);
						}
						else if ((j == 1 || j == 5) && i % 10 == 0 && lights)
						{
							WorldGen.PlaceTile(num, num2, type, mute: true);
						}
						TileChecks.SquareUpdate(num, num2);
						continue;
					}
					return;
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedDynamite")).AddIngredient(2119, 500).AddIngredient(129, 500)
				.AddRecipeGroup("Wood", 500)
				.AddIngredient(base.Mod.Find<ModItem>("UnlimitedTorches"))
				.AddTile(16)
				.Register();
		}
	}
}
