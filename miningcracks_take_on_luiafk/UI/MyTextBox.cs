using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal class MyTextBox : UIText
	{
		public string text;

		public string hoverText;

		public MyTextBox(string text, float textScale = 1.6f, bool large = false)
			: base("1", textScale, large)
		{
			this.text = text;
			Width.Set(32f, 0f);
			Height.Set(32f, 0f);
			hoverText = "Gap Between Blocks";
		}

		public override void Click(UIMouseEvent evt)
		{
			base.Click(evt);
			switch (text)
			{
			case "0":
				SetText("1", 1.6f, large: false);
				text = "1";
				UILearning.LuiP.uiHoikRodGap = 1;
				break;
			case "1":
				SetText("2", 1.6f, large: false);
				text = "2";
				UILearning.LuiP.uiHoikRodGap = 2;
				break;
			case "2":
				SetText("3", 1.6f, large: false);
				text = "3";
				UILearning.LuiP.uiHoikRodGap = 3;
				break;
			case "3":
				SetText("0", 1.6f, large: false);
				text = "0";
				UILearning.LuiP.uiHoikRodGap = 0;
				break;
			default:
				SetText("0", 1.6f, large: false);
				text = "0";
				UILearning.LuiP.uiHoikRodGap = 0;
				break;
			}
		}

		public override void Update(GameTime gameTime)
		{
			if (base.IsMouseHovering)
			{
				Main.instance.MouseText(hoverText, 0, 0);
				Main.mouseText = true;
			}
			base.Update(gameTime);
		}
	}
}
