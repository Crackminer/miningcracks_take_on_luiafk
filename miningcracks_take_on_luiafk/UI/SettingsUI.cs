using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal class SettingsUI : UIState
	{
		internal Point position;

		internal MyImageButton battler;

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
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.BuffPeace, "Ultimate Peaceful")
			{
				HAlign = 0.14f,
				VAlign = 0.5f
			};
			myImageButton2.OnClick += Peace;
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.BuffGravitation, "Gravity Control")
			{
				HAlign = 0.26f,
				VAlign = 0.5f
			};
			myImageButton3.OnClick += Grav;
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.BuffFeatherFall, "Featherfall")
			{
				HAlign = 0.38f,
				VAlign = 0.5f
			};
			myImageButton4.OnClick += Feather;
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.BuffInferno, "Inferno Visual")
			{
				HAlign = 0.5f,
				VAlign = 0.5f
			};
			myImageButton5.OnClick += Infernal;
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.BuffInvis, "Invisibility")
			{
				HAlign = 0.62f,
				VAlign = 0.5f
			};
			myImageButton6.OnClick += Invis;
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.BuffCrate, "Crate Potion")
			{
				HAlign = 0.74f,
				VAlign = 0.5f
			};
			myImageButton7.OnClick += Crates;
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.BuffSpelunker, "Spelunker")
			{
				HAlign = 0.86f,
				VAlign = 0.5f
			};
			myImageButton8.OnClick += Spelunk;
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.BuffDangerSense, "Danger and Hunter")
			{
				HAlign = 0.98f,
				VAlign = 0.5f
			};
			myImageButton9.OnClick += Danger;
			myUIPanel.Append(myImageButton9);
			Append(myUIPanel);
		}

        public void Battler(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			//myImageButton.active = !myImageButton.active;
			if (!myImageButton.active)
			{
				myImageButton.active = true;
				myImageButton.SetVisibility(0.6f, 1f);
			}
			UILearning.LuiP.StartBattlerCountdown();
		}

		public void disableBattler()
        {
			battler.active = false;
			battler.SetVisibility(1f, 0.6f);
		}

		public void Peace(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.UltPeaceful;
				//UILearning.LuiP.editSpawnRate(battler: false);
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.UltPeaceful;
			}
		}

		public void Grav(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Grav;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Grav;
			}
		}

		public void Feather(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Feather;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Feather;
			}
		}

		public void Infernal(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Inferno;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Inferno;
			}
		}

		public void Invis(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Invis;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Invis;
			}
		}

		public void Crates(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Crate;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Crate;
			}
		}

		public void Spelunk(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Spelunker;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.Spelunker;
			}
		}

		public void Danger(UIMouseEvent evt, UIElement element)
		{
			MyImageButton myImageButton = (MyImageButton)element;
			myImageButton.active = !myImageButton.active;
			if (myImageButton.active)
			{
				myImageButton.SetVisibility(0.6f, 1f);
				UILearning.LuiP.uiBuffs ^= PotToggles.DangerHunter;
			}
			else
			{
				myImageButton.SetVisibility(1f, 0.6f);
				UILearning.LuiP.uiBuffs ^= PotToggles.DangerHunter;
			}
		}
	}
}
