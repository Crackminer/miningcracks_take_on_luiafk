using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.AutoBuilderUIs
{
	internal class FishingBiomeUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();
		internal List<MyImageButton> allButtons = new List<MyImageButton>();

		internal List<MyImageButton> buttons2 = new List<MyImageButton>();

		internal FishingBiomeUI()
			: base(10, 2)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(340f, 0f);
			myUIPanel.Height.Set(80f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.MiscLight, "Light On/Off")
			{
				VAlign = 0.1f,
				HAlign = 0f
			};
			myImageButton.OnClick += lightClick;
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.WallStoneSlab, "Stone Slab")
			{
				VAlign = 0.1f,
				HAlign = 0.11f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.WallGrayBrick, "Gray Brick")
			{
				VAlign = 0.1f,
				HAlign = 0.22f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.WallWood, "Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.33f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.WallPearlWood, "Pearlwood")
			{
				VAlign = 0.1f,
				HAlign = 0.44f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			allButtons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.WallBorealWood, "Boreal Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.55f
			};
			myImageButton6.OnClick += multipleClick;
			buttons.Add(myImageButton6);
			allButtons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.WallPalmWood, "Palm Wood")
			{
				VAlign = 0.1f,
				HAlign = 0.66f
			};
			myImageButton7.OnClick += multipleClick;
			buttons.Add(myImageButton7);
			allButtons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.WallEbonWood, "Ebonwood")
			{
				VAlign = 0.1f,
				HAlign = 0.77f
			};
			myImageButton8.OnClick += multipleClick;
			buttons.Add(myImageButton8);
			allButtons.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.WallShadeWood, "Shadewood")
			{
				VAlign = 0.1f,
				HAlign = 0.88f
			};
			myImageButton9.OnClick += multipleClick;
			buttons.Add(myImageButton9);
			allButtons.Add(myImageButton9);
			myUIPanel.Append(myImageButton9);
			MyImageButton myImageButton10 = new MyImageButton(Textures.WallLivingWood, "Rich Mahogany")
			{
				VAlign = 0.1f,
				HAlign = 0.99f
			};
			myImageButton10.OnClick += multipleClick;
			buttons.Add(myImageButton10);
			allButtons.Add(myImageButton10);
			myUIPanel.Append(myImageButton10);
			MyImageButton myImageButton11 = new MyImageButton(Textures.BiomeCrimson, "Crimson")
			{
				VAlign = 0.9f,
				HAlign = 0f
			};
			myImageButton11.OnClick += multipleClick2;
			buttons2.Add(myImageButton11);
			myUIPanel.Append(myImageButton11);
			MyImageButton myImageButton12 = new MyImageButton(Textures.BiomeCorruption, "Corruption")
			{
				VAlign = 0.9f,
				HAlign = 0.11f
			};
			myImageButton12.OnClick += multipleClick2;
			buttons2.Add(myImageButton12);
			myUIPanel.Append(myImageButton12);
			MyImageButton myImageButton13 = new MyImageButton(Textures.BiomeHallow, "Hallow\nHardmode Only")
			{
				VAlign = 0.9f,
				HAlign = 0.22f
			};
			myImageButton13.OnClick += multipleClick2;
			buttons2.Add(myImageButton13);
			myUIPanel.Append(myImageButton13);
			MyImageButton myImageButton14 = new MyImageButton(Textures.BiomeIce, "Ice")
			{
				VAlign = 0.9f,
				HAlign = 0.33f
			};
			myImageButton14.OnClick += multipleClick2;
			buttons2.Add(myImageButton14);
			myUIPanel.Append(myImageButton14);
			MyImageButton myImageButton15 = new MyImageButton(Textures.BiomeIceCrimson, "Crimson Ice")
			{
				VAlign = 0.9f,
				HAlign = 0.44f
			};
			myImageButton15.OnClick += multipleClick2;
			buttons2.Add(myImageButton15);
			myUIPanel.Append(myImageButton15);
			MyImageButton myImageButton16 = new MyImageButton(Textures.BiomeIceCorruption, "Corruption Ice")
			{
				VAlign = 0.9f,
				HAlign = 0.55f
			};
			myImageButton16.OnClick += multipleClick2;
			buttons2.Add(myImageButton16);
			myUIPanel.Append(myImageButton16);
			MyImageButton myImageButton17 = new MyImageButton(Textures.BiomeIceHallow, "Hallow Ice\nHardmode Only")
			{
				VAlign = 0.9f,
				HAlign = 0.66f
			};
			myImageButton17.OnClick += multipleClick2;
			buttons2.Add(myImageButton17);
			myUIPanel.Append(myImageButton17);
			MyImageButton myImageButton18 = new MyImageButton(Textures.BiomeJungle, "Jungle")
			{
				VAlign = 0.9f,
				HAlign = 0.77f
			};
			myImageButton18.OnClick += multipleClick2;
			buttons2.Add(myImageButton18);
			myUIPanel.Append(myImageButton18);
			MyImageButton myImageButton19 = new MyImageButton(Textures.BiomeMushroom, "Mushroom")
			{
				VAlign = 0.9f,
				HAlign = 0.88f
			};
			myImageButton19.OnClick += multipleClick2;
			buttons2.Add(myImageButton19);
			myUIPanel.Append(myImageButton19);
			MyImageButton myImageButton20 = new MyImageButton(Textures.MiscWalls, "Walls On/Off")
			{
				VAlign = 0.9f,
				HAlign = 0.99f
			};
			myImageButton20.OnClick += wallClick;
			allButtons.Add(myImageButton20);
			myUIPanel.Append(myImageButton20);
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
			int uiBiome;
			switch (myImageButton.hoverText)
			{
			case "Crimson":
				uiBiome = 0;
				break;
			case "Corruption":
				uiBiome = 1;
				break;
			case "Hallow\nHardmode Only":
				uiBiome = 5;
				break;
			case "Ice":
				uiBiome = 2;
				break;
			case "Crimson Ice":
				uiBiome = 6;
				break;
			case "Corruption Ice":
				uiBiome = 7;
				break;
			case "Hallow Ice\nHardmode Only":
				uiBiome = 8;
				break;
			case "Jungle":
				uiBiome = 3;
				break;
			case "Mushroom":
				uiBiome = 4;
				break;
			default:
				uiBiome = 100;
				break;
			}
			UILearning.LuiP.uiBiome = uiBiome;
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

		public void buttonUpdates()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			foreach (MyImageButton button in buttons2)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			if (UILearning.LuiP.uiLight)
			{
				allButtons.ToArray()[0].active = true;
				allButtons.ToArray()[0].SetVisibility(0.6f, 1f);
			}

			if (UILearning.LuiP.uiObsidian)
			{
				allButtons.ToArray()[10].active = true;
				allButtons.ToArray()[10].SetVisibility(0.6f, 1f);
			}

			switch (UILearning.LuiP.uiMaterial)
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

			switch(UILearning.LuiP.uiBiome)
            {
				case 0:
					allButtons.ToArray()[0].active = true;
					allButtons.ToArray()[0].SetVisibility(0.6f, 1f);
					break;
				case 1:
					allButtons.ToArray()[1].active = true;
					allButtons.ToArray()[1].SetVisibility(0.6f, 1f);
					break;
				case 5:
					allButtons.ToArray()[2].active = true;
					allButtons.ToArray()[2].SetVisibility(0.6f, 1f);
					break;
				case 2:
					allButtons.ToArray()[3].active = true;
					allButtons.ToArray()[3].SetVisibility(0.6f, 1f);
					break;
				case 6:
					allButtons.ToArray()[4].active = true;
					allButtons.ToArray()[4].SetVisibility(0.6f, 1f);
					break;
				case 7:
					allButtons.ToArray()[5].active = true;
					allButtons.ToArray()[5].SetVisibility(0.6f, 1f);
					break;
				case 8:
					allButtons.ToArray()[6].active = true;
					allButtons.ToArray()[6].SetVisibility(0.6f, 1f);
					break;
				case 3:
					allButtons.ToArray()[7].active = true;
					allButtons.ToArray()[7].SetVisibility(0.6f, 1f);
					break;
				case 4:
					allButtons.ToArray()[8].active = true;
					allButtons.ToArray()[8].SetVisibility(0.6f, 1f);
					break;
				default: break;
			}
		}
	}
}
