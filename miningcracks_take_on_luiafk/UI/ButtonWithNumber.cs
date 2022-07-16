using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;

namespace miningcracks_take_on_luiafk.UI
{
	internal class ButtonWithNumber : Button
	{
		internal ButtonWithNumber(int x, int y, int size, string text, Texture2D texture, Func<bool> state, Action pressed, int texPosX = -1, int texPosY = -1)
			: base(x, y, size, text, texture, state, pressed, texPosX, texPosY)
		{
		}

		internal void DrawText(SpriteBatch sb, int xOffset, int yOffset, string text, Vector2 textOffset)
		{
												DynamicSpriteFontExtensionMethods.DrawString(sb, FontAssets.ItemStack.Value, text, new Vector2((float)(base.X + xOffset), (float)(base.Y + yOffset)), new Color(0, 0, 255), 0f, textOffset, 2f, (SpriteEffects)0, 0f);
		}
	}
}
