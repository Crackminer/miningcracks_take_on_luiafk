using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.AutoBuilderUIs
{
	internal class PoolBuilderUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();
		internal List<MyImageButton> allButtons = new List<MyImageButton>();

		internal List<MyImageButton> buttons2 = new List<MyImageButton>();

		public PoolBuilderUI()
			: base(9, 2)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(320f, 0f);
			myUIPanel.Height.Set(80f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.WallStoneSlab, "Stone Slab")
			{
				VAlign = 0.1f,
				HAlign = 0.02f
			};
			buttons.Add(myImageButton);
			allButtons.Add(myImageButton);
			myImageButton.OnClick += multipleClick;
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.WallGrayBrick, "Gray Brick")
			{
				VAlign = 0.1f,
				HAlign = 0.14f
			};
			buttons.Add(myImageButton2);
			allButtons.Add(myImageButton2);
			myImageButton2.OnClick += multipleClick;
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WallWood, "Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.26f
			};
			buttons.Add(myImageButton3);
			allButtons.Add(myImageButton3);
			myImageButton3.OnClick += multipleClick;
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WallPearlWood, "Pearlwood")
			{
				VAlign = 0.1f,
				HAlign = 0.38f
			};
			buttons.Add(myImageButton4);
			allButtons.Add(myImageButton4);
			myImageButton4.OnClick += multipleClick;
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WallBorealWood, "Boreal Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.5f
			};
			buttons.Add(myImageButton5);
			allButtons.Add(myImageButton5);
			myImageButton5.OnClick += multipleClick;
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WallPalmWood, "Palm Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.62f
			};
			buttons.Add(myImageButton6);
			allButtons.Add(myImageButton6);
			myImageButton6.OnClick += multipleClick;
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.WallEbonWood, "Ebonwood")
			{
				VAlign = 0.1f,
				HAlign = 0.74f
			};
			buttons.Add(myImageButton7);
			allButtons.Add(myImageButton7);
			myImageButton7.OnClick += multipleClick;
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.WallShadeWood, "Shadewood")
			{
				VAlign = 0.1f,
				HAlign = 0.86f
			};
			buttons.Add(myImageButton8);
			allButtons.Add(myImageButton8);
			myImageButton8.OnClick += multipleClick;
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.WallLivingWood, "Rich Mahogany")
			{
				VAlign = 0.1f,
				HAlign = 0.98f
			};
			buttons.Add(myImageButton9);
			allButtons.Add(myImageButton9);
			myImageButton9.OnClick += multipleClick;
			myUIPanel.Append(myImageButton9);
			MyImageButton myImageButton10 = new MyImageButton(Textures.MiscSponge, "Multi-purpose Sponge")
			{
				VAlign = 0.9f,
				HAlign = 0.14f
			};
			buttons2.Add(myImageButton10);
			allButtons.Add(myImageButton10);
			myImageButton10.OnClick += multipleClick2;
			myUIPanel.Append(myImageButton10);
			MyImageButton myImageButton11 = new MyImageButton(Textures.MiscWater, "Water Bucket")
			{
				VAlign = 0.9f,
				HAlign = 0.26f
			};
			buttons2.Add(myImageButton11);
			allButtons.Add(myImageButton11);
			myImageButton11.OnClick += multipleClick2;
			myUIPanel.Append(myImageButton11);
			MyImageButton myImageButton12 = new MyImageButton(Textures.MiscLava, "Lava Bucket")
			{
				VAlign = 0.9f,
				HAlign = 0.38f
			};
			buttons2.Add(myImageButton12);
			allButtons.Add(myImageButton12);
			myImageButton12.OnClick += multipleClick2;
			myUIPanel.Append(myImageButton12);
			MyImageButton myImageButton13 = new MyImageButton(Textures.MiscHoney, "Honey Bucket")
			{
				VAlign = 0.9f,
				HAlign = 0.62f
			};
			buttons2.Add(myImageButton13);
			allButtons.Add(myImageButton13);
			myImageButton13.OnClick += multipleClick2;
			myUIPanel.Append(myImageButton13);
			MyImageButton myImageButton14 = new MyImageButton(Textures.MiscFishing, "Fishing Pool Builder")
			{
				VAlign = 0.9f,
				HAlign = 0.74f
			};
			myImageButton14.OnClick += fishClick;
			allButtons.Add(myImageButton14);
			myUIPanel.Append(myImageButton14);
			MyImageButton myImageButton15 = new MyImageButton(Textures.MiscWalls, "Walls On/Off")
			{
				VAlign = 0.9f,
				HAlign = 0.86f
			};
			myImageButton15.OnClick += wallClick;
			allButtons.Add(myImageButton15);
			myUIPanel.Append(myImageButton15);
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
			case "Stone Slab":
				uiMaterial = 0;
				break;
			case "Gray Brick":
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

		public void multipleClick2(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			foreach (MyImageButton item in buttons2)
			{
				if (item.active && myImageButton.hoverText != item.hoverText)
				{
					item.active = false;
					item.SetVisibility(1f, 0.6f);
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
			int uiBucketType;
			switch (myImageButton.hoverText)
			{
			case "Multi-purpose Sponge":
				uiBucketType = 0;
				break;
			case "Water Bucket":
				uiBucketType = 1;
				break;
			case "Lava Bucket":
				uiBucketType = 2;
				break;
			case "Honey Bucket":
				uiBucketType = 3;
				break;
			default:
				uiBucketType = 100;
				break;
			}
			UILearning.LuiP.uiBucketType = uiBucketType;
		}

		public void fishClick(UIMouseEvent evt, UIElement element)
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
			UILearning.LuiP.uiPoolBuild = !UILearning.LuiP.uiPoolBuild;
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

		public void buttonUpdates()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			if (UILearning.LuiP.uiObsidian)
			{
				allButtons.ToArray()[14].active = true;
				allButtons.ToArray()[14].SetVisibility(0.6f, 1f);
			}

			if (UILearning.LuiP.uiPoolBuild)
            {
				allButtons.ToArray()[13].active = true;
				allButtons.ToArray()[13].SetVisibility(0.6f, 1f);
			}

			switch (UILearning.LuiP.uiMaterial)
			{
				case 0:
					allButtons.ToArray()[0].active = true;
					allButtons.ToArray()[0].SetVisibility(0.6f, 1f);
					break;
				case 1:
					allButtons.ToArray()[1].active = true;
					allButtons.ToArray()[1].SetVisibility(0.6f, 1f);
					break;
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

			switch (UILearning.LuiP.uiBucketType)
			{
				case 0:
					allButtons.ToArray()[9].active = true;
					allButtons.ToArray()[9].SetVisibility(0.6f, 1f);
					break;
				case 1:
					allButtons.ToArray()[10].active = true;
					allButtons.ToArray()[10].SetVisibility(0.6f, 1f);
					break;
				case 2:
					allButtons.ToArray()[11].active = true;
					allButtons.ToArray()[11].SetVisibility(0.6f, 1f);
					break;
				case 3:
					allButtons.ToArray()[12].active = true;
					allButtons.ToArray()[12].SetVisibility(0.6f, 1f);
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

			UILearning.LuiP.uiObsidian = false;

			UILearning.LuiP.uiPoolBuild = false;

			UILearning.LuiP.uiMaterial = 0;

			UILearning.LuiP.uiBucketType = 0;

			buttonUpdates();
		}
	}
}
