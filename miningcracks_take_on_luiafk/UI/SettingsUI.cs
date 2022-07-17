using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using System.Collections.Generic;
using Terraria;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal class SettingsUI : UIState
	{
		internal Point position;

		internal MyImageButton battler;

		internal List<MyImageButton> allButtons = new();

		internal const int Border = 10;

		internal const int Size = 32;

		internal SettingsUI()
		{
		}

		public override void OnInitialize()
		{
			MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.Width.Set(320f, 0f);
			myUIPanel.Height.Set(40f, 0f);
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.BuffBattler, "Ultimate Battler\nOverrides Ultimate Peaceful")
			{
				HAlign = 0.02f,
				VAlign = 0.5f
			};
			myImageButton.OnClick += Battler;
			battler = myImageButton;
			allButtons.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.BuffPeace, "Ultimate Peaceful")
			{
				HAlign = 0.14f,
				VAlign = 0.5f
			};
			myImageButton2.OnClick += Peace;
			allButtons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.BuffGravitation, "Gravity Control")
			{
				HAlign = 0.26f,
				VAlign = 0.5f
			};
			myImageButton3.OnClick += Grav;
			allButtons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.BuffFeatherFall, "Featherfall")
			{
				HAlign = 0.38f,
				VAlign = 0.5f
			};
			myImageButton4.OnClick += Feather;
			allButtons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.BuffInferno, "Inferno Visual")
			{
				HAlign = 0.5f,
				VAlign = 0.5f
			};
			myImageButton5.OnClick += Infernal;
			allButtons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.BuffInvis, "Invisibility")
			{
				HAlign = 0.62f,
				VAlign = 0.5f
			};
			myImageButton6.OnClick += Invis;
			allButtons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.BuffCrate, "Crate Potion")
			{
				HAlign = 0.74f,
				VAlign = 0.5f
			};
			myImageButton7.OnClick += Crates;
			allButtons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.BuffSpelunker, "Spelunker")
			{
				HAlign = 0.86f,
				VAlign = 0.5f
			};
			myImageButton8.OnClick += Spelunk;
			allButtons.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.BuffDangerSense, "Danger and Hunter")
			{
				HAlign = 0.98f,
				VAlign = 0.5f
			};
			myImageButton9.OnClick += Danger;
			allButtons.Add(myImageButton9);
			myUIPanel.Append(myImageButton9);
			Append(myUIPanel);
		}

		public void buttonUpdates()
        {
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			if ((UILearning.LuiP.uiBuffs & PotToggles.UltBattler) != 0)
            {
				allButtons.ToArray()[0].active = true;
				allButtons.ToArray()[0].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.UltPeaceful) != 0)
			{
				allButtons.ToArray()[1].active = true;
				allButtons.ToArray()[1].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Grav) != 0)
			{
				allButtons.ToArray()[2].active = true;
				allButtons.ToArray()[2].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Feather) != 0)
			{
				allButtons.ToArray()[3].active = true;
				allButtons.ToArray()[3].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Inferno) != 0)
			{
				allButtons.ToArray()[4].active = true;
				allButtons.ToArray()[4].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Invis) != 0)
			{
				allButtons.ToArray()[5].active = true;
				allButtons.ToArray()[5].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Crate) != 0)
			{
				allButtons.ToArray()[6].active = true;
				allButtons.ToArray()[6].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.Spelunker) != 0)
			{
				allButtons.ToArray()[7].active = true;
				allButtons.ToArray()[7].SetVisibility(1f, 1f);
			}
			if ((UILearning.LuiP.uiBuffs & PotToggles.DangerHunter) != 0)
			{
				allButtons.ToArray()[8].active = true;
				allButtons.ToArray()[8].SetVisibility(1f, 1f);
			}
		}

        public void Battler(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			if (!myImageButton.active)
			{
				myImageButton.active = true;
				myImageButton.SetVisibility(1f, 1f);
			}
			UILearning.LuiP.StartBattlerCountdown();
		}

		public void disableBattler()
        {
			battler.active = false;
			battler.SetVisibility(0.6f, 0.6f);
		}

		public void Peace(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.UltPeaceful;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.UltPeaceful;
			}
		}

		public void Grav(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Grav;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Grav;
			}
		}

		public void Feather(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Feather;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Feather;
			}
		}

		public void Infernal(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Inferno;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Inferno;
			}
		}

		public void Invis(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Invis;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Invis;
			}
		}

		public void Crates(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Crate;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Crate;
			}
		}

		public void Spelunk(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Spelunker;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Spelunker;
			}
		}

		public void Danger(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(1f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.DangerHunter;
			}
			else
			{
				myImageButton.SetVisibility(0.6f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.DangerHunter;
			}
		}

		public void resetValues()
        {
			foreach (MyImageButton button in allButtons)
			{
				button.active = false;
				button.SetVisibility(0.6f, 0.6f);
			}

			UILearning.LuiP.uiBuffs = 0b000000000;

			buttonUpdates();
		}
	}
}
