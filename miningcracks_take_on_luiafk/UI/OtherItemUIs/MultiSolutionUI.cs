using System.Collections.Generic;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Solutions;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class MultiSolutionUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();

		internal MultiSolutionUI()
			: base(9, 2)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(320f, 0f);
			myUIPanel.Height.Set(74f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.SolutionCorruption, "Purple Solution")
			{
				VAlign = 0.1f,
				HAlign = 0f
			};
			myImageButton.OnClick += multipleClick;
			buttons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.SolutionCrimson, "Red Solution")
			{
				VAlign = 0.1f,
				HAlign = 0.125f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.SolutionGrass, "Green Solution")
			{
				VAlign = 0.1f,
				HAlign = 0.25f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.SolutionHallow, "Blue Solution")
			{
				VAlign = 0.1f,
				HAlign = 0.375f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.SolutionHell, "Hell Solution\nNot used with Clentaminator")
			{
				VAlign = 0.1f,
				HAlign = 0.5f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.SolutionIce, "Snow/Ice Solution\nNot used with Clentaminator")
			{
				VAlign = 0.1f,
				HAlign = 0.625f
			};
			myImageButton6.OnClick += multipleClick;
			buttons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton element = new MyImageButton(Textures.SolutionJungle, "Dark Green Solution")
			{
				VAlign = 0.1f,
				HAlign = 0.75f
			};
			element.OnClick += multipleClick;
			buttons.Add(element);
			myUIPanel.Append(element);
			MyImageButton myImageButton7 = new MyImageButton(Textures.SolutionMushroom, "Dark Blue Solution")
			{
				VAlign = 0.1f,
				HAlign = 0.875f
			};
			myImageButton7.OnClick += multipleClick;
			buttons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.SolutionSky, "Cloud Solution\nNot used with Clentaminator")
			{
				VAlign = 0.1f,
				HAlign = 1f
			};
			myImageButton8.OnClick += multipleClick;
			buttons.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.SolutionUse, "")
			{
				VAlign = 0.9f,
				HAlign = 0.5f
			};
			myImageButton9.SetVisibility(1f, 1f);
			myImageButton9.OnClick += useClick;
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
			int uiMultiSolutionType;
			switch (myImageButton.hoverText)
			{
			case "Green Solution":
				uiMultiSolutionType = 0;
				break;
			case "Purple Solution":
				uiMultiSolutionType = 1;
				break;
			case "Red Solution":
				uiMultiSolutionType = 2;
				break;
			case "Dark Blue Solution":
				uiMultiSolutionType = 3;
				break;
			case "Blue Solution":
				uiMultiSolutionType = 4;
				break;
			case "Dark Green Solution":
				uiMultiSolutionType = 5;
				break;
			case "Snow/Ice Solution\nNot used with Clentaminator":
				uiMultiSolutionType = 6;
				break;
			case "Hell Solution\nNot used with Clentaminator":
				uiMultiSolutionType = 7;
				break;
			case "Cloud Solution\nNot used with Clentaminator":
				uiMultiSolutionType = 8;
				break;
			default:
				uiMultiSolutionType = 100;
				break;
			}
			UILearning.LuiP.uiMultiSolutionType = uiMultiSolutionType;
		}

		public void useClick(UIMouseEvent evt, UIElement element)
		{
			UnlimitedMultiSolution.ConvertClicked();
		}

		public void buttonUpdates()
		{
			foreach (MyImageButton button in buttons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			switch (UILearning.LuiP.uiMultiSolutionType)
			{
				case 1:
					buttons.ToArray()[0].active = true;
					buttons.ToArray()[0].SetVisibility(0.6f, 1f);
					break;
				case 2:
					buttons.ToArray()[1].active = true;
					buttons.ToArray()[1].SetVisibility(0.6f, 1f);
					break;
				case 0:
					buttons.ToArray()[2].active = true;
					buttons.ToArray()[2].SetVisibility(0.6f, 1f);
					break;
				case 4:
					buttons.ToArray()[3].active = true;
					buttons.ToArray()[3].SetVisibility(0.6f, 1f);
					break;
				case 7:
					buttons.ToArray()[4].active = true;
					buttons.ToArray()[4].SetVisibility(0.6f, 1f);
					break;
				case 6:
					buttons.ToArray()[5].active = true;
					buttons.ToArray()[5].SetVisibility(0.6f, 1f);
					break;
				case 5:
					buttons.ToArray()[6].active = true;
					buttons.ToArray()[6].SetVisibility(0.6f, 1f);
					break;
				case 3:
					buttons.ToArray()[7].active = true;
					buttons.ToArray()[7].SetVisibility(0.6f, 1f);
					break;
				case 8:
					buttons.ToArray()[8].active = true;
					buttons.ToArray()[8].SetVisibility(0.6f, 1f);
					break;
				default: break;
			}
		}

		internal override void resetValues()
		{
			foreach (MyImageButton button in buttons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			UILearning.LuiP.uiMultiSolutionType = 0;

			buttonUpdates();
		}
	}
}
