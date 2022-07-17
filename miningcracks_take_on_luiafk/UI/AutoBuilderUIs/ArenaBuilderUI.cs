using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.AutoBuilderUIs
{
	internal class ArenaBuilderUI : RightClickUI
	{
		public List<MyImageButton> buttons = new List<MyImageButton>();
		public List<MyImageButton> allButtons = new List<MyImageButton>();

		internal ArenaBuilderUI()
			: base(9, 1)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(320f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.MiscLight, "Light On/Off")
			{
				VAlign = 0.5f,
				HAlign = 0.02f
			};
			myImageButton.OnClick += lightClick;
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.MiscCampFire, "Place Campfires and Bubbles")
			{
				VAlign = 0.5f,
				HAlign = 0.14f
			};
			myImageButton2.OnClick += campClick;
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WallWood, "Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.26f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WallPearlWood, "Pearlwood")
			{
				VAlign = 0.5f,
				HAlign = 0.38f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WallBorealWood, "Boreal Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.5f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			allButtons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WallPalmWood, "Palm Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.62f
			};
			myImageButton6.OnClick += multipleClick;
			buttons.Add(myImageButton6);
			allButtons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.WallEbonWood, "Ebonwood")
			{
				VAlign = 0.5f,
				HAlign = 0.74f
			};
			myImageButton7.OnClick += multipleClick;
			buttons.Add(myImageButton7);
			allButtons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.WallShadeWood, "Shadewood")
			{
				VAlign = 0.5f,
				HAlign = 0.86f
			};
			myImageButton8.OnClick += multipleClick;
			buttons.Add(myImageButton8);
			allButtons.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.WallLivingWood, "Rich Mahogany")
			{
				VAlign = 0.5f,
				HAlign = 0.98f
			};
			myImageButton9.OnClick += multipleClick;
			buttons.Add(myImageButton9);
			allButtons.Add(myImageButton9);
			myUIPanel.Append(myImageButton9);
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
			int uiMaterial;
			switch (myImageButton.hoverText)
			{
			case "Wood":
				uiMaterial = 2;
				break;
			case "Pearlwood":
				uiMaterial = 3;
				break;
			case "Boreal Wood":
				uiMaterial = 4;
				break;
			case "Palm Wood":
				uiMaterial = 5;
				break;
			case "Ebonwood":
				uiMaterial = 6;
				break;
			case "Shadewood":
				uiMaterial = 7;
				break;
			case "Rich Mahogany":
				uiMaterial = 8;
				break;
			default:
				uiMaterial = 100;
				break;
			}
			UILearning.LuiP.uiMaterial = uiMaterial;
		}

		public void lightClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiLight = !UILearning.LuiP.uiLight;
		}

		public void campClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiCampfire = !UILearning.LuiP.uiCampfire;
		}

		public void buttonUpdates()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			if (UILearning.LuiP.uiLight)
			{
				allButtons.ToArray()[0].active = true;
				allButtons.ToArray()[0].SetVisibility(0.6f, 1f);
			}

			if(UILearning.LuiP.uiCampfire)
            {
				allButtons.ToArray()[1].active = true;
				allButtons.ToArray()[1].SetVisibility(0.6f, 1f);
			}

			switch (UILearning.LuiP.uiMaterial)
			{
				case 2:
					allButtons.ToArray()[2].active = true;
					allButtons.ToArray()[2].SetVisibility(0.6f, 1f);
					break;
				case 3:
					allButtons.ToArray()[3].active = true;
					allButtons.ToArray()[3].SetVisibility(0.6f, 1f);
					break;
				case 4:
					allButtons.ToArray()[4].active = true;
					allButtons.ToArray()[4].SetVisibility(0.6f, 1f);
					break;
				case 5:
					allButtons.ToArray()[5].active = true;
					allButtons.ToArray()[5].SetVisibility(0.6f, 1f);
					break;
				case 6:
					allButtons.ToArray()[6].active = true;
					allButtons.ToArray()[6].SetVisibility(0.6f, 1f);
					break;
				case 7:
					allButtons.ToArray()[7].active = true;
					allButtons.ToArray()[7].SetVisibility(0.6f, 1f);
					break;
				case 8:
					allButtons.ToArray()[8].active = true;
					allButtons.ToArray()[8].SetVisibility(0.6f, 1f);
					break;
				default: break;
			}
		}

		internal override void resetValues()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			UILearning.LuiP.uiLight = false;

			UILearning.LuiP.uiCampfire = false;

			UILearning.LuiP.uiMaterial = 0;

			buttonUpdates();
		}
	}
}
