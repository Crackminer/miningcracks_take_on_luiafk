using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class HoikRodUI : RightClickUI
	{
		public List<MyImageButton> buttons = new List<MyImageButton>();

		internal List<MyImageButton> buttons2 = new List<MyImageButton>();


		internal HoikRodUI()
			: base(9, 1)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(332f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.HoikFull, "Full Block")
			{
				VAlign = 0.5f,
				HAlign = 0.06f
			};
			myImageButton.OnClick += multipleClick;
			buttons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.HoikHalf, "Half Block")
			{
				VAlign = 0.5f,
				HAlign = 0.17f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.HoikSlopeUpLeft, "Up and Left")
			{
				VAlign = 0.5f,
				HAlign = 0.28f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.HoikSlopeUpRight, "Up and Right")
			{
				VAlign = 0.5f,
				HAlign = 0.39f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.HoikSlopeDownLeft, "Down and Left")
			{
				VAlign = 0.5f,
				HAlign = 0.5f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.HoikSlopeDownRight, "Down and Right")
			{
				VAlign = 0.5f,
				HAlign = 0.61f
			};
			myImageButton6.OnClick += multipleClick;
			buttons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.HoikActuated, "Active/Inactive")
			{
				VAlign = 0.5f,
				HAlign = 0.72f
			};
			myImageButton7.OnClick += activateClick;
			buttons2.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.HoikReverse, "Reverse Actuation\nOverrides Active/Inactive")
			{
				VAlign = 0.5f,
				HAlign = 0.83f
			};
			myImageButton8.OnClick += reverseClick;
			buttons2.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyTextBox element = new MyTextBox("Gap Between Blocks")
			{
				VAlign = 0.8f,
				HAlign = 0.94f
			};
			myUIPanel.Append(element);
			Append(myUIPanel);
		}

        public void multipleClick(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			foreach (MyImageButton button in buttons)
			{
				if (button.active && myImageButton.hoverText != button.hoverText)
				{
					button.active = false;
					button.SetVisibility(1f, 0.6f);
				}
			}
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
			}
			byte uiHoikRodSelected;
			switch (myImageButton.hoverText)
			{
			case "Full Block":
				uiHoikRodSelected = 0;
				break;
			case "Half Block":
				uiHoikRodSelected = 1;
				break;
			case "Up and Left":
				uiHoikRodSelected = 4;
				break;
			case "Up and Right":
				uiHoikRodSelected = 5;
				break;
			case "Down and Left":
				uiHoikRodSelected = 2;
				break;
			case "Down and Right":
				uiHoikRodSelected = 3;
				break;
			default:
				uiHoikRodSelected = 10;
				break;
			}
			UILearning.LuiP.uiHoikRodSelected = uiHoikRodSelected;
		}

		public void activateClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiHoikRodActive = !UILearning.LuiP.uiHoikRodActive;
		}

		public void reverseClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiHoikRodReverse = !UILearning.LuiP.uiHoikRodReverse;
		}

		public void buttonUpdates()
		{
			foreach (MyImageButton button in buttons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			foreach (MyImageButton button in buttons2)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			switch (UILearning.LuiP.uiHoikRodSelected)
			{
				case 0:
					buttons.ToArray()[0].active = true;
					buttons.ToArray()[0].SetVisibility(0.6f, 1f);
					break;
				case 1:
					buttons.ToArray()[1].active = true;
					buttons.ToArray()[1].SetVisibility(0.6f, 1f);
					break;
				case 4:
					buttons.ToArray()[2].active = true;
					buttons.ToArray()[2].SetVisibility(0.6f, 1f);
					break;
				case 5:
					buttons.ToArray()[3].active = true;
					buttons.ToArray()[3].SetVisibility(0.6f, 1f);
					break;
				case 2:
					buttons.ToArray()[4].active = true;
					buttons.ToArray()[4].SetVisibility(0.6f, 1f);
					break;
				case 3:
					buttons.ToArray()[5].active = true;
					buttons.ToArray()[5].SetVisibility(0.6f, 1f);
					break;
				default: break;
			}

			if(UILearning.LuiP.uiHoikRodActive)
            {
				buttons2.ToArray()[0].active = true;
				buttons2.ToArray()[0].SetVisibility(0.6f, 1f);
			}

			if (UILearning.LuiP.uiHoikRodReverse)
			{
				buttons2.ToArray()[1].active = true;
				buttons2.ToArray()[1].SetVisibility(0.6f, 1f);
			}
		}
	}
}
