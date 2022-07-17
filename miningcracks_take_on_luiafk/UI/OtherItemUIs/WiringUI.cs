using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using System.Collections.Generic;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class WiringUI : RightClickUI
	{
		internal List<MyImageButton> allButtons = new();
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
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.WireGreen, "Green")
			{
				VAlign = 0.5f,
				HAlign = 0.2f
			};
			myImageButton2.OnClick += wireClick;
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WireBlue, "Blue")
			{
				VAlign = 0.5f,
				HAlign = 0.4f
			};
			myImageButton3.OnClick += wireClick;
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WireYellow, "Yellow")
			{
				VAlign = 0.5f,
				HAlign = 0.6f
			};
			myImageButton4.OnClick += wireClick;
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WireActuator, "Actuator")
			{
				VAlign = 0.5f,
				HAlign = 0.8f
			};
			myImageButton5.OnClick += wireClick;
			allButtons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WireCutter, "Cutter")
			{
				VAlign = 0.5f,
				HAlign = 1f
			};
			myImageButton6.OnClick += wireClick;
			allButtons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			Append(myUIPanel);
		}

		public void wireClick(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
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

		public void buttonUpdates()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			if((UILearning.LuiP.uiWireMode & MultiToolMode.Red) != 0)
            {
				allButtons.ToArray()[0].active = true;
				allButtons.ToArray()[0].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiWireMode & MultiToolMode.Green) != 0)
			{
				allButtons.ToArray()[1].active = true;
				allButtons.ToArray()[1].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiWireMode & MultiToolMode.Blue) != 0)
			{
				allButtons.ToArray()[2].active = true;
				allButtons.ToArray()[2].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiWireMode & MultiToolMode.Yellow) != 0)
			{
				allButtons.ToArray()[3].active = true;
				allButtons.ToArray()[3].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiWireMode & MultiToolMode.Actuator) != 0)
			{
				allButtons.ToArray()[4].active = true;
				allButtons.ToArray()[4].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiWireMode & MultiToolMode.Cutter) != 0)
			{
				allButtons.ToArray()[5].active = true;
				allButtons.ToArray()[5].SetVisibility(1f, 1f);
			}
		}

		internal override void resetValues()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			UILearning.LuiP.uiWireMode = 0x00;

			buttonUpdates();
		}
	}
}
