using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class SubwayBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Subway Builder");
			base.Tooltip.SetDefault("Builds a subway.\nRight-click to choose options.\nWill be lit up all the way along if you have the light on.\nClick where you want the Minecart Track to be.\nWill go through the temple if Golem is dead.\nDeletes tiles 1 below the track, 5 above (7 tiles high total).");
			base.SacrificeTotal = 1;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<BuildingMaterialsUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<BuildingMaterialsUI>());
					UILearning.RightClickUIs<BuildingMaterialsUI>().buttonUpdates();
					if(Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On)	Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			return true;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item, 90);
		}

		public override void HoldItem(Player player)
		{
			player.rulerLine = true;
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<BuildingMaterialsUI>().holding = true;
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
				int y = Player.tileTargetY - 5;
				if (Main.netMode == 0)
				{
					HandleBuilding(ButtonBox.BuildingWallType(modPlayer.uiMaterial), ButtonBox.BuildingTileType(modPlayer.uiMaterial), y, modPlayer.uiLight);
				}
				else
				{
					SubwayPacket(ButtonBox.BuildingWallType(modPlayer.uiMaterial), ButtonBox.BuildingTileType(modPlayer.uiMaterial), y, modPlayer.uiLight);
				}
			}
			return true;
		}

		private static void SubwayPacket(int wall, int tile, int y, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(2);
			((BinaryWriter)packet).Write(wall);
			((BinaryWriter)packet).Write(tile);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int wall, int tile, int y, bool lights)
		{
			int[] array = new int[7] { 1, 0, 0, 0, 0, 2, 1 };
			int type = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
			for (int i = 0; Main.maxTilesX - 43 - i > 39; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					int num = Main.maxTilesX - 43 - i;
					int num2 = y + j;
					TileChecks.TileSafe(num, num2);
					if (TileChecks.InGameWorldLeft(num) && TileChecks.NoTempleOrGolemIsDead(num, num2))
					{
						TileChecks.ClearEverything(num, num2);
						if (j > 0 && j < 6 && i > 0)
						{
							WorldGen.PlaceWall(num, num2, wall, mute: true);
						}
						if (i == 0 || i == Main.maxTilesX - 84)
						{
							WorldGen.PlaceTile(num, num2, tile, mute: true);
						}
						if (array[j] == 1)
						{
							WorldGen.PlaceTile(num, num2, tile, mute: true);
						}
						if (array[j] == 2 && i != 0 && i != Main.maxTilesX - 84)
						{
							WorldGen.PlaceTile(num, num2, 314, mute: true);
						}
						else if (j == 3 && i % 10 == 1 && lights)
						{
							WorldGen.PlaceTile(num, num2, type, mute: true);
						}
						TileChecks.SquareUpdate(num, num2);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("UnlimitedDynamite").Type).AddIngredient(2119, 500).AddIngredient(129, 500)
				.AddRecipeGroup("Wood", 500)
				.AddIngredient(2340, 3996)
				.AddIngredient(base.Mod.Find<ModItem>("UnlimitedTorches").Type)
				.AddTile(16)
				.Register();
		}
	}
}
