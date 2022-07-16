using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class ArenaBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Arena Platform Builder");
			base.Tooltip.SetDefault("Builds a platform ~200 blocks wide.\nRight click to choose options, choose platform material and extras\nChoosing the campfire will place campfires, blocks for Star/Heart in a bottle\nAnd will also place bubble blocks for honey placement.\nChoosing the light will make the platform be lit up all the way along.\nWon't destroy tiles.\nClick where you want the right side of the platform to end.");
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
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<ArenaBuilderUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<ArenaBuilderUI>());
					UILearning.RightClickUIs<ArenaBuilderUI>().buttonUpdates();
					if (Main.FrameSkipMode == Terraria.Enums.FrameSkipMode.On) Main.FrameSkipMode = Terraria.Enums.FrameSkipMode.Subtle;
				}
				return false;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<ArenaBuilderUI>().holding = true;
			}
			player.rulerLine = true;
		}

		public override bool? UseItem(Player player)
		{
			if (player.whoAmI != Main.myPlayer)
			{
				return true;
			}
			if (player.altFunctionUse == 2)
			{
				return false;
			}
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (!player.noBuilding && modPlayer.uiMaterial > 1)
			{
				int tileTargetX = Player.tileTargetX;
				int tileTargetY = Player.tileTargetY;
				if (Main.netMode == 0)
				{
					HandleBuilding(modPlayer.uiMaterial, tileTargetX, tileTargetY, modPlayer.uiLight, modPlayer.uiCampfire);
					return true;
				}
				ArenaBuilderPacket(modPlayer.uiMaterial, tileTargetX, tileTargetY, modPlayer.uiLight, modPlayer.uiCampfire);
			}
			return true;
		}

		private static void ArenaBuilderPacket(int style, int x, int y, bool lights, bool campfire)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(10);
			((BinaryWriter)packet).Write(style);
			((BinaryWriter)packet).Write(x);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(lights);
			((BinaryWriter)packet).Write(campfire);
			packet.Send();
		}

		internal static void HandleBuilding(int style, int x, int y, bool lights, bool campfire)
		{
			int style2 = ButtonBox.PlatformStyle(style - 2);
			int type = ButtonBox.BuildingTileType(style);
			int type2 = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
			for (int i = 0; i < 195; i++)
			{
				int num = x - i;
				TileChecks.TileSafe(num, y);
				if (!TileChecks.InGameWorldLeft(num))
				{
					continue;
				}
				if ((!campfire || (i != 47 && i != 48 && i != 145 && i != 146)) && !Main.tile[num, y].HasTile)
				{
					WorldGen.PlaceTile(num, y, 19, mute: true, forced: false, -1, style2);
				}
				TileChecks.TileSafe(num, y - 3);
				if (lights && i % 10 == 0 && !Main.tile[num, y - 3].HasTile)
				{
					WorldGen.PlaceTile(num, y - 3, type2, mute: true);
					TileChecks.SquareUpdate(num, y - 3);
				}
				if (campfire && i > 21 && (i - 22) % 30 == 0)
				{
					TileChecks.TileSafe(num - 1, y - 2);
					if (!Main.tile[num - 1, y - 2].HasTile)
					{
						WorldGen.PlaceTile(num - 1, y - 2, 379, mute: true);
					}
					TileChecks.TileSafe(num, y - 1);
					if (!Main.tile[num, y - 1].HasTile)
					{
						WorldGen.PlaceTile(num, y - 1, 379, mute: true);
					}
					TileChecks.TileSafe(num + 1, y - 2);
					if (!Main.tile[num + 1, y - 2].HasTile)
					{
						WorldGen.PlaceTile(num + 1, y - 2, 379, mute: true);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendTileSquare(-1, num, y - 1, 3);
					}
				}
				if (campfire && (i == 47 || i == 48 || i == 145 || i == 146) && !Main.tile[num, y].HasTile)
				{
					WorldGen.PlaceTile(num, y, type, mute: true);
				}
				TileChecks.SquareUpdate(num, y);
				if (campfire && (i == 48 || i == 147))
				{
					WorldGen.PlaceTile(num + 1, y - 1, 215, mute: true);
					if (Main.netMode == 2)
					{
						NetMessage.SendTileSquare(-1, num + 1, y - 1, 3);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Wood", 300).AddRecipeGroup("Luiafk:Torches", 60).AddIngredient(2325)
				.AddTile(18)
				.Register();
		}
	}
}
