using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.AutoBuilderUIs
{
	internal class SubAndSkyUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();
		internal List<MyImageButton> allButtons = new List<MyImageButton>();

		internal SubAndSkyUI()
			: base(9, 2)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(395f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton10 = new MyImageButton(Textures.MiscLight, "Light On/Off")
			{
				VAlign = 0.5f,
				HAlign = 0.0f
			};
			myImageButton10.OnClick += lightClick;
			allButtons.Add(myImageButton10);
			myUIPanel.Append(myImageButton10);
			MyImageButton myImageButton = new MyImageButton(Textures.WallStoneSlab, "Stone Slab\nDon't use with Platform Mode")
			{
				VAlign = 0.5f,
				HAlign = 0.09f
			};
			myImageButton.OnClick += multipleClick;
			buttons.Add(myImageButton);
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.WallGrayBrick, "Gray Brick\nDon't use with Platform Mode")
			{
				VAlign = 0.5f,
				HAlign = 0.18f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WallWood, "Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.27f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WallPearlWood, "Pearlwood")
			{
				VAlign = 0.5f,
				HAlign = 0.36f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WallBorealWood, "Boreal Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.45f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			allButtons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WallPalmWood, "Palm Wood")
			{
				VAlign = 0.5f,
				HAlign = 0.54f
			};
			myImageButton6.OnClick += multipleClick;
			buttons.Add(myImageButton6);
			allButtons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.WallEbonWood, "Ebonwood")
			{
				VAlign = 0.5f,
				HAlign = 0.63f
			};
			myImageButton7.OnClick += multipleClick;
			buttons.Add(myImageButton7);
			allButtons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.WallShadeWood, "Shadewood")
			{
				VAlign = 0.5f,
				HAlign = 0.72f
			};
			myImageButton8.OnClick += multipleClick;
			buttons.Add(myImageButton8);
			allButtons.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.WallLivingWood, "Rich Mahogany")
			{
				VAlign = 0.5f,
				HAlign = 0.81f
			};
			myImageButton9.OnClick += multipleClick;
			buttons.Add(myImageButton9);
			allButtons.Add(myImageButton9);
			myUIPanel.Append(myImageButton9);
			MyImageButton myImageButton11 = new MyImageButton(Textures.MiscWalls, "Walls On/Off")
			{
				VAlign = 0.5f,
				HAlign = 0.90f
			};
			myImageButton11.OnClick += wallClick;
			allButtons.Add(myImageButton11);
			myUIPanel.Append(myImageButton11);
			MyImageButton myImageButton12 = new MyImageButton(Textures.MiscPlatform, "Platform Builder\nClick again for Minecart")
			{
				VAlign = 0.5f,
				HAlign = 1f
			};
			myImageButton12.SetVisibility(1f, 1f);
			allButtons.Add(myImageButton12);
			myImageButton12.OnClick += subOrSkyClick;
			myUIPanel.Append(myImageButton12);
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
			case "Stone Slab\nDon't use with Platform Mode":
				uiMaterial = 0;
				break;
			case "Gray Brick\nDon't use with Platform Mode":
				uiMaterial = 1;
				break;
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

		public void wallClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiObsidian = !UILearning.LuiP.uiObsidian;
		}

		private void subOrSkyClick(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)(UIImageButton)element;
			if (myImageButton.active)
			{
				myImageButton.active = false;
				myImageButton.SetImage(Textures.MiscPlatform);
				myImageButton.hoverText = "Platform Builder\nClick again for Minecart";
			}
			else
			{
				myImageButton.active = true;
				myImageButton.SetImage(Textures.MiscMineTrack);
				myImageButton.hoverText = "Minecart Builder\nClick again for Platforms";
			}
			UILearning.LuiP.uiSubOrMinecart = !UILearning.LuiP.uiSubOrMinecart;
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

			if(UILearning.LuiP.uiObsidian)
            {
				allButtons.ToArray()[10].active = true;
				allButtons.ToArray()[10].SetVisibility(0.6f, 1f);
			}

			if(UILearning.LuiP.uiSubOrMinecart)
            {
				allButtons.ToArray()[11].active = true;
				allButtons.ToArray()[11].SetVisibility(0.6f, 1f);
				allButtons.ToArray()[12].SetImage(Textures.MiscMineTrack);
			}

			switch(UILearning.LuiP.uiMaterial)
            {
				case 0:
					allButtons.ToArray()[1].active = true;
					allButtons.ToArray()[1].SetVisibility(0.6f, 1f); 
					break;
				case 1:
					allButtons.ToArray()[2].active = true;
					allButtons.ToArray()[2].SetVisibility(0.6f, 1f);
					break;
				case 2:
					allButtons.ToArray()[3].active = true;
					allButtons.ToArray()[3].SetVisibility(0.6f, 1f);
					break;
				case 3:
					allButtons.ToArray()[4].active = true;
					allButtons.ToArray()[4].SetVisibility(0.6f, 1f);
					break;
				case 4:
					allButtons.ToArray()[5].active = true;
					allButtons.ToArray()[5].SetVisibility(0.6f, 1f);
					break;
				case 5:
					allButtons.ToArray()[6].active = true;
					allButtons.ToArray()[6].SetVisibility(0.6f, 1f);
					break;
				case 6:
					allButtons.ToArray()[7].active = true;
					allButtons.ToArray()[7].SetVisibility(0.6f, 1f);
					break;
				case 7:
					allButtons.ToArray()[8].active = true;
					allButtons.ToArray()[8].SetVisibility(0.6f, 1f);
					break;
				case 8:
					allButtons.ToArray()[9].active = true;
					allButtons.ToArray()[9].SetVisibility(0.6f, 1f);
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

			UILearning.LuiP.uiSubOrMinecart = false;

			UILearning.LuiP.uiObsidian = false;

			UILearning.LuiP.uiMaterial = 0;

			buttonUpdates();
		}

	}
}
