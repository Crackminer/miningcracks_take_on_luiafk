using System.IO;

using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.AutoBuilders
{
	public class SkyPlatformBuilder : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Skybridge Builder");
			base.Tooltip.SetDefault("Builds a platform the length of the map.\nRight-click to choose options.\nWill be lit up all the way along if you have the light on.\nWon't destroy tiles.\nClick where you want the platform to be.");
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
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<skyUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<skyUI>());
					UILearning.RightClickUIs<skyUI>().buttonUpdates();
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
				UILearning.RightClickUIs<skyUI>().holding = true;
			}
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
			if (player.whoAmI == Main.myPlayer && !player.noBuilding && modPlayer.uiMaterial > 1)
			{
				int tileTargetY = Player.tileTargetY;
				if (Main.netMode == 0)
				{
					HandleBuilding(ButtonBox.PlatformStyle(modPlayer.uiMaterial - 2), tileTargetY, modPlayer.uiLight);
				}
				else
				{
					SkyPlatformPacket(ButtonBox.PlatformStyle(modPlayer.uiMaterial - 2), tileTargetY, modPlayer.uiLight);
				}
			}
			return true;
		}

		private static void SkyPlatformPacket(int style, int y, bool lights)
		{
			ModPacket packet = LuiafkMod.Instance.GetPacket();
			((BinaryWriter)packet).Write(3);
			((BinaryWriter)packet).Write(style);
			((BinaryWriter)packet).Write(y);
			((BinaryWriter)packet).Write(lights);
			packet.Send();
		}

		internal static void HandleBuilding(int style, int y, bool lights)
		{
			int type = LuiafkMod.Instance.Find<ModTile>("HouseEnabler").Type;
			for (int i = 0; Main.maxTilesX - 43 - i > 39; i++)
			{
				int num = Main.maxTilesX - 43 - i;
				if (TileChecks.InGameWorldLeft(num))
				{
					WorldGen.PlaceTile(num, y, 19, mute: true, forced: false, -1, style);
					TileChecks.TileSafe(num, y - 3);
					if (lights && i % 10 == 0 && !Main.tile[num, y - 3].HasTile)
					{
						WorldGen.PlaceTile(num, y - 3, type, mute: true);
					}
					if (Main.netMode == 2)
					{
						NetMessage.SendTileSquare(-1, num, y, 1);
						NetMessage.SendTileSquare(-1, num, y - 3, 1);
					}
				}
			}
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddRecipeGroup("Wood", 1998).AddIngredient(751, 50).AddIngredient(2325, 3)
				.AddIngredient(305, 2)
				.AddTile(18)
				.Register();
		}
	}
}
