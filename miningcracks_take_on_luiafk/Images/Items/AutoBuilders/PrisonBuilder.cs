using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class PrisonBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Prison Builder");
			base.Tooltip.SetDefault("Builds an NPC prison.\nRight-click to choose options.\nWill be lit up if the light is on (will count as a house either way).\nClick where you want the bottom right block.\nPrison is 5 tiles wide, 12 tiles high.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item, 30);
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
				int tileTargetX = Player.tileTargetX;
				int tileTargetY = Player.tileTargetY;
				if (Main.netMode == 0)
				{
					HandleBuilding(tileTargetX, tileTargetY, modPlayer.uiMaterial, modPlayer.uiLight);
				}
				else
				{
					PrisonPacket(tileTargetX, tileTargetY, modPlayer.uiMaterial, modPlayer.uiLight);
				}
			}
			return true;
		}

		private static void PrisonPacket(int x, int y, int tileType, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(6);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(tileType);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int x, int y, int tileType, bool lights)
		{
			int[,] array = new int[12, 5]
			{
				{ 1, 1, 1, 1, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 2, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 0, 0, 0, 1 },
				{ 1, 1, 1, 1, 1 }
			};
			int type = (lights ? LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type : LuiafkMod.Instance.Find<ModTile>("HouseEnablerDark").Type);
			int type2 = ButtonBox.BuildingWallType(tileType);
			int type3 = ButtonBox.BuildingTileType(tileType);
			for (int num = array.GetLength(0) - 1; num >= 0; num--)
			{
				for (int i = 0; i < 5; i++)
				{
					int num2 = x - i;
					int num3 = y - num;
					TileChecks.TileSafe(num2, num3);
					if (TileChecks.InGameWorld(num2, num3) && TileChecks.NoTempleOrGolemIsDead(num2, num3) && TileChecks.NoOrbOrAltar(num2, num3))
					{
						TileChecks.ClearEverything(num2, num3);
						if (num > 0 && num < array.GetLength(0) - 1 && i > 0 && i < array.GetLength(1) - 1)
						{
							WorldGen.PlaceWall(num2, num3, type2, mute: true);
						}
						if (array[num, i] == 1)
						{
							WorldGen.PlaceTile(num2, num3, type3, mute: true);
						}
						else if (array[num, i] == 2)
						{
							WorldGen.PlaceTile(num2, num3, type, mute: true);
						}
						TileChecks.SquareUpdate(num2, num3);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Wood", 200).AddIngredient(base.Mod.Find<ModItem>("HouseTile").Type).AddTile(16)
				.Register();
		}
	}
}
