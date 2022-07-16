using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal class BoxPlace
	{
		private bool holding;

		internal Point16 Start { get; private set; } = Point16.NegativeOne;


		internal Point16 End { get; private set; } = Point16.NegativeOne;


		internal void Reset()
		{
			holding = false;
		}

		internal void Update(BoxType bt)
		{
												holding = true;
			Player player = Main.player[Main.myPlayer];
			if (Main.mouseRight || Main.blockMouse || player.mouseInterface || Main.SmartCursorIsUsed || (!Main.mouseLeft && Main.mouseLeftRelease) || player.dead || player.noBuilding)
			{
				Start = Point16.NegativeOne;
				End = Point16.NegativeOne;
				return;
			}
			if (Main.mouseLeft)
			{
				if (Start == Point16.NegativeOne)
				{
					if (SmartCursor.OutOfRange(player, player.inventory[player.selectedItem], Player.tileTargetX, Player.tileTargetY))
					{
						Start = SmartCursor.FindClosestToPosition(FindType.Box, player, new Vector2((float)Player.tileTargetX, (float)Player.tileTargetY));
					}
					else
					{
						Start = new Point16(Player.tileTargetX, Player.tileTargetY);
					}
				}
				else if (SmartCursor.OutOfRange(player, player.inventory[player.selectedItem], Start.X, Start.Y))
				{
					Start = SmartCursor.FindClosestToPosition(FindType.Box, player, new Vector2((float)Start.X, (float)Start.Y));
				}
				if (SmartCursor.OutOfRange(player, player.inventory[player.selectedItem], Player.tileTargetX, Player.tileTargetY))
				{
					End = SmartCursor.FindClosestToPosition(FindType.Box, player, new Vector2((float)Player.tileTargetX, (float)Player.tileTargetY));
				}
				else
				{
					End = new Point16(Player.tileTargetX, Player.tileTargetY);
				}
				if (bt == BoxType.Paint)
				{
					UILearning.RightClickUIs<PaintToolUI>().onMenu = false;
				}
				UILearning.RightClickUIs<ComboRodUI>().onMenu = false;
			}
			if (!Main.mouseLeft && !Main.mouseLeftRelease && Start != Point16.NegativeOne && End != Point16.NegativeOne)
			{
				SmartCursor.BoxPlace(player, this, bt);
			}
		}

		internal LegacyGameInterfaceLayer BoxLayer()
		{
			return new LegacyGameInterfaceLayer("Luiafk: Box", delegate
			{
				Draw(Main.spriteBatch);
				return true;
			});
		}

		private void Draw(SpriteBatch sb)
		{
									if (holding && !Main.SmartCursorIsUsed && Main.mouseLeft && !(Start == Point16.NegativeOne) && !(End == Point16.NegativeOne))
			{
				sb.Draw(TextureAssets.MagicPixel.Value, new Rectangle((((Start.X <= End.X) ? Start.X : End.X) << 4) - (int)Main.screenPosition.X, (((Start.Y <= End.Y) ? Start.Y : End.Y) << 4) - (int)Main.screenPosition.Y, ((End.X > Start.X) ? (End.X - Start.X) : (Start.X - End.X)) + 1 << 4, ((End.Y > Start.Y) ? (End.Y - Start.Y) : (Start.Y - End.Y)) + 1 << 4), new Color(255, 0, 0, 128));
			}
		}
	}
}
