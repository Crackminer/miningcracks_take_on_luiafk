using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace miningcracks_take_on_luiafk.UI
{
	public class UILearning : ModSystem
	{
		private static Dictionary<Type, RightClickUI> rightClickUIs;

		internal static UserInterface BuffInterface;

		internal static UserInterface RightInterface;

		internal static UserInterface ComboInterface;

		internal static LuiafkPlayer LuiP;

		private static GameTime _lastUpdateUiGameTime;

		internal static SettingsUI BuffUI { get; private set; }

		internal static BoxPlace BoxPlaceUI { get; private set; }

		public override void Load()
		{
		}

		public static void MyLoad()
		{
			_lastUpdateUiGameTime = new GameTime();
			_lastUpdateUiGameTime = new GameTime();
			BuffInterface = new UserInterface();
			RightInterface = new UserInterface();
			ComboInterface = new UserInterface();
			BoxPlaceUI = new BoxPlace();
			BuffUI = new SettingsUI();
			rightClickUIs = RightClickUI.Create();
			BuffUI.Activate();
			foreach (RightClickUI value in rightClickUIs.Values)
			{
				value.Activate();
			}
		}

		public override void Unload()
		{
			rightClickUIs = null;
			BuffUI = null;
			BoxPlaceUI = null;
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if (_lastUpdateUiGameTime == gameTime) return;
			_lastUpdateUiGameTime = gameTime;
			if (BuffInterface?.CurrentState != null)
			{
				BuffInterface?.Update(gameTime);
			}
			if (RightInterface?.CurrentState != null)
			{
				RightInterface?.Update(gameTime);
			}
			if (ComboInterface?.CurrentState != null)
			{
				ComboInterface?.Update(gameTime);
			}
		}

		internal static T RightClickUIs<T>() where T : RightClickUI
		{
			return (T)rightClickUIs[typeof(T)];
		}

		internal static void ResetUIs()
		{
			BoxPlaceUI.Reset();
			foreach (KeyValuePair<Type, RightClickUI> rightClickUI in rightClickUIs)
			{
				rightClickUI.Value.Reset();
			}
		}

		internal static void set_battler()
        {
			BuffUI.disableBattler();
		}

		internal static void OnEnterWorld()
		{
			LuiP = Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>();
            BuffUI.position = LuiP.uiBuffPosition;
			foreach(RightClickUI rui in rightClickUIs.Values)
            {
				rui.resetValues();
            }
			BuffUI.resetValues();
        }

        private static LegacyGameInterfaceLayer SmartLayer()
		{
			GameInterfaceDrawMethod drawMethod = delegate
			{
				PaintToolUI paintToolUI = RightClickUIs<PaintToolUI>();
				bool correctItem = paintToolUI.holding || RightClickUIs<ComboRodUI>().holding;
				DrawSmartCursor(Main.spriteBatch, paintToolUI.target, correctItem);
				return true;
			};
			return new LegacyGameInterfaceLayer("Luiafk: Smart", drawMethod);
		}

		private static LegacyGameInterfaceLayer CoordLayer(LuiafkPlayer luiP)
		{
			return new LegacyGameInterfaceLayer("Luiafk: Coords", delegate
			{
				if (luiP.mouseTileCoords)
				{
					DrawMouseCoords(Main.spriteBatch);
				}
				return true;
			}, InterfaceScaleType.UI);
		}

		private static void DrawMouseCoords(SpriteBatch sb)
		{
			TileChecks.TileSafe(Player.tileTargetX, Player.tileTargetY);
			string text = "X: " + Player.tileTargetX + "\nY: " + Player.tileTargetY + "\nType: " + Main.tile[Player.tileTargetX, Player.tileTargetY].TileType;
			Vector2 vec = new Vector2((float)(Main.screenWidth >> 1), (float)((Main.screenHeight >> 1) - 75)) - FontAssets.MouseText.Value.MeasureString(text) / 2f;
			ChatManager.DrawColorCodedStringWithShadow(sb, FontAssets.MouseText.Value, text, vec.Floor(), new Color(255, 85, 0), 0f, Vector2.Zero, Vector2.One);
		}

		private static void DrawSmartCursor(SpriteBatch sb, Point16 target, bool correctItem)
		{
			if (correctItem && Main.SmartCursorIsUsed && !(target == Point16.NegativeOne))
			{
				sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle((target.X << 4) - (int)Main.screenPosition.X, (target.Y << 4) - (int)Main.screenPosition.Y, 16, 16), new Color(255, 0, 0, 128));
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			Player player = Main.player[Main.myPlayer];
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			int num = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Ruler"));
			if (num != -1)
			{
				layers.Insert(num, DrawHitbox.Layer(modPlayer));
				layers.Insert(num, BoxPlaceUI.BoxLayer());
				layers.Insert(num, SmartLayer());
			}
			num = layers.FindIndex((GameInterfaceLayer layer) => layer.Name.Equals("Vanilla: Cursor"));
			if (num != -1)
			{
				layers.Insert(num, new LegacyGameInterfaceLayer("Luiafk: BuffButtons", delegate
				{
					BuffInterface.Draw(Main.spriteBatch, new GameTime());
					return true;
				}, InterfaceScaleType.UI));
				layers.Insert(num, DrillUI.Layer(player, modPlayer));
				layers.Insert(num, CoordLayer(modPlayer));
				layers.Insert(num, new LegacyGameInterfaceLayer("luiafk: ComboRodUI", delegate
				{
					ComboInterface.Draw(Main.spriteBatch, new GameTime());
					return true;
				}, InterfaceScaleType.UI));
				layers.Insert(num, new LegacyGameInterfaceLayer("luiafk: RightClickUI", delegate
				{
					RightInterface.Draw(Main.spriteBatch, new GameTime());
					return true;
				}, InterfaceScaleType.UI));
			}
		}
	}
}
