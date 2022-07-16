using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class WiringUI : RightClickUI
	{
		internal WiringUI()
			: base(6, 1)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(210f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.WireRed, "Red")
			{
				VAlign = 0.5f,
				HAlign = 0f
			};
			myImageButton.OnClick += wireClick;
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.WireGreen, "Green")
			{
				VAlign = 0.5f,
				HAlign = 0.2f
			};
			myImageButton2.OnClick += wireClick;
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WireBlue, "Blue")
			{
				VAlign = 0.5f,
				HAlign = 0.4f
			};
			myImageButton3.OnClick += wireClick;
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WireYellow, "Yellow")
			{
				VAlign = 0.5f,
				HAlign = 0.6f
			};
			myImageButton4.OnClick += wireClick;
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WireActuator, "Actuator")
			{
				VAlign = 0.5f,
				HAlign = 0.8f
			};
			myImageButton5.OnClick += wireClick;
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WireCutter, "Cutter")
			{
				VAlign = 0.5f,
				HAlign = 1f
			};
			myImageButton6.OnClick += wireClick;
			myUIPanel.Append(myImageButton6);
			Append(myUIPanel);
		}

		public void wireClick(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
			}
			int num;
			switch (myImageButton.hoverText)
			{
			case "Red":
				num = 0;
				break;
			case "Green":
				num = 1;
				break;
			case "Blue":
				num = 2;
				break;
			case "Yellow":
				num = 3;
				break;
			case "Actuator":
				num = 4;
				break;
			case "Cutter":
				num = 5;
				break;
			default:
				num = 100;
				break;
			}
			UILearning.LuiP.uiWireMode ^= (MultiToolMode)(byte)(1 << num);
		}
	}
}
