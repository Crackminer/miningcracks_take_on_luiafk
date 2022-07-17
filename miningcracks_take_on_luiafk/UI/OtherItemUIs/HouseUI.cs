using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class HouseUI : RightClickUI
	{
		internal List<MyImageButton> allButtons = new List<MyImageButton>();

		internal HouseUI()
			: base(1, 1)
		{
			initUI();
		}

		public void initUI()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(40f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.PaddingLeft = 0f;
			myUIPanel.PaddingRight = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.MiscLight, "Light On/Off")
			{
				VAlign = 0.5f,
				HAlign = 0.5f
			};
			myImageButton.OnClick += lightClick;
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			
			Append(myUIPanel);
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
        }

		internal override void resetValues()
		{
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(1f, 0.6f);
			}

			UILearning.LuiP.uiLight = false;

			buttonUpdates();
		}
	}
}
