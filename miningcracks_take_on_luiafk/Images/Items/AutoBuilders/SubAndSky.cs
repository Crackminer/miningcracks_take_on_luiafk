using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class SubAndSky : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Minecart or Platform Builder");
			base.Tooltip.SetDefault("Right-click to choose options.\nWill be lit up all the way along if you have the light on.\nPlatform material can be Obsidian (takes priority), or the woods.\nIf you have Unlimited Asphalt Platforms in your inventory, these will be placed instead.\nChoosing Obsidian will make the Minecart lay without walls/floor.\nPlacing platforms will destroy tiles.\nClick where you want the Minecart Track or the Platform to be\nWill go through the temple if Golem is dead.\nDeletes tiles 1 below the platform/track, 5 above (7 tiles high total).");
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
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<SubAndSkyUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<SubAndSkyUI>());
					UILearning.RightClickUIs<SubAndSkyUI>().buttonUpdates();
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
				UILearning.RightClickUIs<SubAndSkyUI>().holding = true;
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
				int y = Player.tileTargetY - 5;
				bool asphalt = player.HasItem(base.Mod.Find<ModItem>("AsphaltPlatform").Type);
				LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
				if (Main.netMode == 0)
				{
					HandleBuilding(modPlayer.uiMaterial, y, modPlayer.uiObsidian, modPlayer.uiSubOrMinecart, asphalt, modPlayer.uiLight);
					return true;
				}
				SubwayPacket(modPlayer.uiMaterial, y, modPlayer.uiObsidian, modPlayer.uiSubOrMinecart, asphalt, modPlayer.uiLight);
			}
			return true;
		}

		private static void SubwayPacket(int tile, int y, bool obsidian, bool platformOrMine, bool asphalt, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(4);
			((BinaryWriter)packet).Write(tile);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(obsidian);
			((BinaryWriter)packet).Write(platformOrMine);
			((BinaryWriter)packet).Write(asphalt);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int tile, int y, bool obsidian, bool platformOrMine, bool asphalt, bool lights)
		{
			if (tile < 2 && !obsidian && !asphalt && !platformOrMine)
			{
				return;
			}
			int[] array = new int[7] { 1, 0, 0, 0, 0, 2, 1 };
			int type = ButtonBox.BuildingWallType(tile);
			int type2 = ButtonBox.BuildingTileType(tile);
			int style = ButtonBox.PlatformStyle((tile - 2 >= 0) ? (tile - 2) : 0);
			int type3 = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
			int type4 = LuiafkMod.Instance.Find<ModTile>("AsphaltPlatform").Type;
			if (obsidian)
			{
				style = 13;
			}
			for (int i = 0; Main.maxTilesX - 43 - i > 39; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					int num = Main.maxTilesX - 43 - i;
					int num2 = y + j;
					TileChecks.TileSafe(num, num2);
					if (!TileChecks.InGameWorldLeft(num) || !TileChecks.NoTempleOrGolemIsDead(num, num2))
					{
						continue;
					}
					TileChecks.ClearEverything(num, num2);
					if (platformOrMine && obsidian)
					{
						if (j > 0 && j < 6 && i > 0)
						{
							WorldGen.PlaceWall(num, num2, type, mute: true);
						}
						if (i == 0 || i == Main.maxTilesX - 84)
						{
							WorldGen.PlaceTile(num, num2, type2, mute: true);
						}
						if (array[j] == 1)
						{
							WorldGen.PlaceTile(num, num2, type2, mute: true);
						}
					}
					if (platformOrMine)
					{
						if (array[j] == 2 && i != 0 && i != Main.maxTilesX - 84)
						{
							WorldGen.PlaceTile(num, num2, 314, mute: true);
						}
					}
					else if (asphalt)
					{
						if (array[j] == 2)
						{
							WorldGen.PlaceTile(num, num2, type4, mute: true);
						}
					}
					else if (array[j] == 2)
					{
						WorldGen.PlaceTile(num, num2, 19, mute: true, forced: false, -1, style);
					}
					if (j == 3 && i % 10 == 1 && lights)
					{
						WorldGen.PlaceTile(num, num2, type3, mute: true);
					}
					TileChecks.SquareUpdate(num, num2);
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(base.Mod.Find<ModItem>("SubwayBuilder").Type).AddIngredient(base.Mod.Find<ModItem>("SkyPlatformBuilder").Type).AddIngredient(173, 999)
				.AddTile(16)
				.Register();
		}
	}
}
