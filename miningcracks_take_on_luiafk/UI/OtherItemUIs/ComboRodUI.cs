using System.Collections.Generic;
using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class ComboRodUI : RightClickUI
	{
		internal List<MyImageButton> buttons = new List<MyImageButton>();
		internal MyUIPanel panel;

		internal ComboRodUI()
			: base(1, 3)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(180f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			panel = myUIPanel;
			MyImageButton myImageButton = new MyImageButton(Textures.ComboPaint, "Paint Mode")
			{
				VAlign = 0.5f,
				HAlign = 0f
			};
			myImageButton.OnClick += multipleClick;
			buttons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.ComboWall, "Wall Mode")
			{
				VAlign = 0.5f,
				HAlign = 0.25f
			};
			myImageButton2.OnClick += multipleClick;
			buttons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.ComboHoik, "Tile Mode")
			{
				VAlign = 0.5f,
				HAlign = 0.5f
			};
			myImageButton3.OnClick += multipleClick;
			buttons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.ComboWire, "Wire Mode")
			{
				VAlign = 0.5f,
				HAlign = 0.75f
			};
			myImageButton4.OnClick += multipleClick;
			buttons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.ComboLiquid, "Bucket Mode")
			{
				VAlign = 0.5f,
				HAlign = 1f
			};
			myImageButton5.OnClick += multipleClick;
			buttons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
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
					button.SetVisibility(0.6f, 0.6f);
				}
			}
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
			case "Paint Mode":
				num = 0;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<PaintToolUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<PaintToolUI>());
					UILearning.RightClickUIs<PaintToolUI>().buttonUpdates();
				}
				break;
			case "Wall Mode":
				num = 2;
				UILearning.RightInterface?.SetState(null);
				break;
			case "Tile Mode":
				num = 1;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<HoikRodUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<HoikRodUI>());
					UILearning.RightClickUIs<HoikRodUI>().buttonUpdates();
				}
				break;
			case "Wire Mode":
				num = 3;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<WiringUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<WiringUI>());
					UILearning.RightClickUIs<WiringUI>().buttonUpdates();
				}
				break;
			case "Bucket Mode":
				num = 4;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<UltimateBucketUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<UltimateBucketUI>());
					UILearning.RightClickUIs<UltimateBucketUI>().buttonUpdates();
				}
				break;
			default:
				num = 100;
				break;
			}
			UILearning.LuiP.uiComboMode = (BuildingRodModes)num;
		}

		public void buttonUpdate()
        {
			foreach (MyImageButton button in buttons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			switch(UILearning.LuiP.uiComboMode)
            {
				case BuildingRodModes.Paint:
					buttons.ToArray()[0].active = true;
					buttons.ToArray()[0].SetVisibility(1f, 1f);
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<PaintToolUI>());
					UILearning.RightClickUIs<PaintToolUI>().buttonUpdates();
					break;
				case BuildingRodModes.Walls:
					buttons.ToArray()[1].active = true;
					buttons.ToArray()[1].SetVisibility(1f, 1f);
					UILearning.RightInterface?.SetState(null);
					break;
				case BuildingRodModes.Tiles:
					buttons.ToArray()[2].active = true;
					buttons.ToArray()[2].SetVisibility(1f, 1f);
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<HoikRodUI>());
					UILearning.RightClickUIs<HoikRodUI>().buttonUpdates();
					break;
				case BuildingRodModes.Wire:
					buttons.ToArray()[3].active = true;
					buttons.ToArray()[3].SetVisibility(1f, 1f);
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<WiringUI>());
					UILearning.RightClickUIs<WiringUI>().buttonUpdates();
					break;
				case BuildingRodModes.Liquid:
					buttons.ToArray()[4].active = true;
					buttons.ToArray()[4].SetVisibility(1f, 1f);
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<UltimateBucketUI>());
					UILearning.RightClickUIs<UltimateBucketUI>().buttonUpdates();
					break;
				default: break;
            }

			panel.Top.Pixels -= 40;
		}

		internal override void resetValues()
		{
			foreach (MyImageButton button in buttons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			UILearning.LuiP.uiComboMode = 0;

			buttonUpdate();
		}
	}
}
