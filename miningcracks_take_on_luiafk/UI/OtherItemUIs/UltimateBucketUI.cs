using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class UltimateBucketUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();
		internal List<MyImageButton> allButtons = new List<MyImageButton>();

		internal UltimateBucketUI()
			: base(4, 1)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(140f, 0f);
			myUIPanel.Height.Set(50f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.MiscSponge, "Multi-purpose Sponge")
			{
				VAlign = 0.5f,
				HAlign = 0f
			};
			myImageButton.OnClick += multipleClick;
			buttons.Add(myImageButton);
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.MiscWater, "Water Bucket")
			{
				VAlign = 0.5f,
				HAlign = 0.333f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.MiscLava, "Lava Bucket")
			{
				VAlign = 0.5f,
				HAlign = 0.666f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.MiscHoney, "Honey Bucket")
			{
				VAlign = 0.5f,
				HAlign = 1f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
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

		public void buttonUpdates()
		{
			foreach(MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			switch(UILearning.LuiP.uiBucketType)
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
				default: break;
            }
		}
	}
}
