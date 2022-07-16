using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent.UI.Elements;

namespace miningcracks_take_on_luiafk.UI
{
	public class MyImageButton : UIImageButton
	{
		public bool active;

		public Asset<Texture2D> thisTexture;

		public string hoverText;

		public MyImageButton(Asset<Texture2D> texture, string hoverText)
			: base(texture)
		{
			SetImage(texture);
			thisTexture = texture;
			this.hoverText = hoverText;
			Width.Set(32f, 0f);
			Height.Set(32f, 0f);
			SetVisibility(1f, 0.6f);
		}

		public override void Update(GameTime gameTime)
		{
			if (base.IsMouseHovering)
			{
				if (hoverText == "")
				{
					Main.instance.MouseText(AreaText(), 0, 0);
				}
				else
				{
					Main.instance.MouseText(hoverText, 0, 0);
				}
				Main.mouseText = true;
			}
			base.Update(gameTime);
		}

		public string AreaText()
		{
			int num = Math.Min(UILearning.LuiP.uiMultiSolutionTileX[0], UILearning.LuiP.uiMultiSolutionTileX[1]);
			int num2 = Math.Max(UILearning.LuiP.uiMultiSolutionTileX[0], UILearning.LuiP.uiMultiSolutionTileX[1]);
			int y = Math.Min(UILearning.LuiP.uiMultiSolutionTileY[0], UILearning.LuiP.uiMultiSolutionTileY[1]);
			int y2 = Math.Max(UILearning.LuiP.uiMultiSolutionTileY[0], UILearning.LuiP.uiMultiSolutionTileY[1]);
			if (num == -1 || num2 == -1)
			{
				return "You must click 2 locations\nbefore you can convert.";
			}
			return "Convert rectangle at:\n" + TileChecks.CoordsString(num, y) + "\n" + TileChecks.CoordsString(num2, y2);
		}
	}
}
