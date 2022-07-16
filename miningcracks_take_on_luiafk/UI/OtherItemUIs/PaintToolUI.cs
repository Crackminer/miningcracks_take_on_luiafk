using System.Collections.Generic;
using Microsoft.Xna.Framework;

using miningcracks_take_on_luiafk.Utility;
using Terraria.DataStructures;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI.OtherItemUIs
{
	internal class PaintToolUI : RightClickUI
	{
		internal Point16 target = Point16.NegativeOne;

		internal List<MyImageButton> buttons = new List<MyImageButton>();

		internal List<MyImageButton> buttons2 = new List<MyImageButton>();

		internal PaintToolUI()
			: base(3.9375f, 2.8125f)
		{
			initUI();
		}

		public void initUI()
		{
									MyUIPanel myUIPanel = new MyUIPanel();
			myUIPanel.Width.Set(175f, 0f);
			myUIPanel.Height.Set(115f, 0f);
			myUIPanel.PaddingTop = 0f;
			myUIPanel.PaddingBottom = 0f;
			myUIPanel.BackgroundColor = new Color(4, 13, 128, 3);
			MyImageButton myImageButton = new MyImageButton(Textures.PaintModeTile, "Paint Tiles")
			{
				VAlign = 0.1f,
				HAlign = 0f
			};
			myImageButton.OnClick += paintMode;
			buttons2.Add(myImageButton);
			myUIPanel.Append(myImageButton);
			MyImageButton myImageButton2 = new MyImageButton(Textures.ColorBlue, "Blue")
			{
				VAlign = 0.1f,
				HAlign = 0.167f
			};
			myImageButton2.OnClick += paintType;
			buttons.Add(myImageButton2);
			myUIPanel.Append(myImageButton2);
			MyImageButton myImageButton3 = new MyImageButton(Textures.ColorCyan, "Cyan")
			{
				VAlign = 0.1f,
				HAlign = 0.334f
			};
			myImageButton3.OnClick += paintType;
			buttons.Add(myImageButton3);
			myUIPanel.Append(myImageButton3);
			MyImageButton myImageButton4 = new MyImageButton(Textures.ColorGreen, "Green")
			{
				VAlign = 0.1f,
				HAlign = 0.5f
			};
			myImageButton4.OnClick += paintType;
			buttons.Add(myImageButton4);
			myUIPanel.Append(myImageButton4);
			MyImageButton myImageButton5 = new MyImageButton(Textures.ColorLime, "Lime")
			{
				VAlign = 0.1f,
				HAlign = 0.667f
			};
			myImageButton5.OnClick += paintType;
			buttons.Add(myImageButton5);
			myUIPanel.Append(myImageButton5);
			MyImageButton myImageButton6 = new MyImageButton(Textures.ColorOrange, "Orange")
			{
				VAlign = 0.1f,
				HAlign = 0.834f
			};
			myImageButton6.OnClick += paintType;
			buttons.Add(myImageButton6);
			myUIPanel.Append(myImageButton6);
			MyImageButton myImageButton7 = new MyImageButton(Textures.ColorPink, "Pink")
			{
				VAlign = 0.1f,
				HAlign = 1f
			};
			myImageButton7.OnClick += paintType;
			buttons.Add(myImageButton7);
			myUIPanel.Append(myImageButton7);
			MyImageButton myImageButton8 = new MyImageButton(Textures.PaintModeWall, "Paint Walls")
			{
				VAlign = 0.35f,
				HAlign = 0f
			};
			myImageButton8.OnClick += paintMode;
			buttons2.Add(myImageButton8);
			myUIPanel.Append(myImageButton8);
			MyImageButton myImageButton9 = new MyImageButton(Textures.ColorPurple, "Purple")
			{
				VAlign = 0.35f,
				HAlign = 0.167f
			};
			myImageButton9.OnClick += paintType;
			buttons.Add(myImageButton9);
			myUIPanel.Append(myImageButton9);
			MyImageButton myImageButton10 = new MyImageButton(Textures.ColorRed, "Red")
			{
				VAlign = 0.35f,
				HAlign = 0.334f
			};
			myImageButton10.OnClick += paintType;
			buttons.Add(myImageButton10);
			myUIPanel.Append(myImageButton10);
			MyImageButton myImageButton11 = new MyImageButton(Textures.ColorSkyBlue, "Sky Blue")
			{
				VAlign = 0.35f,
				HAlign = 0.5f
			};
			myImageButton11.OnClick += paintType;
			buttons.Add(myImageButton11);
			myUIPanel.Append(myImageButton11);
			MyImageButton myImageButton12 = new MyImageButton(Textures.ColorTeal, "Teal")
			{
				VAlign = 0.35f,
				HAlign = 0.667f
			};
			myImageButton12.OnClick += paintType;
			buttons.Add(myImageButton12);
			myUIPanel.Append(myImageButton12);
			MyImageButton myImageButton13 = new MyImageButton(Textures.ColorViolet, "Violet")
			{
				VAlign = 0.35f,
				HAlign = 0.834f
			};
			myImageButton13.OnClick += paintType;
			buttons.Add(myImageButton13);
			myUIPanel.Append(myImageButton13);
			MyImageButton myImageButton14 = new MyImageButton(Textures.ColorYellow, "Yellow")
			{
				VAlign = 0.35f,
				HAlign = 1f
			};
			myImageButton14.OnClick += paintType;
			buttons.Add(myImageButton14);
			myUIPanel.Append(myImageButton14);
			MyImageButton myImageButton15 = new MyImageButton(Textures.PaintModeNone, "Remove Paint")
			{
				VAlign = 0.6f,
				HAlign = 0f
			};
			myImageButton15.OnClick += paintMode;
			buttons2.Add(myImageButton15);
			myUIPanel.Append(myImageButton15);
			MyImageButton myImageButton16 = new MyImageButton(Textures.ColorDeepBlue, "Deep Blue")
			{
				VAlign = 0.6f,
				HAlign = 0.167f
			};
			myImageButton16.OnClick += paintType;
			buttons.Add(myImageButton16);
			myUIPanel.Append(myImageButton16);
			MyImageButton myImageButton17 = new MyImageButton(Textures.ColorDeepCyan, "Deep Cyan")
			{
				VAlign = 0.6f,
				HAlign = 0.334f
			};
			myImageButton17.OnClick += paintType;
			buttons.Add(myImageButton17);
			myUIPanel.Append(myImageButton17);
			MyImageButton myImageButton18 = new MyImageButton(Textures.ColorDeepGreen, "Deep Green")
			{
				VAlign = 0.6f,
				HAlign = 0.5f
			};
			myImageButton18.OnClick += paintType;
			buttons.Add(myImageButton18);
			myUIPanel.Append(myImageButton18);
			MyImageButton myImageButton19 = new MyImageButton(Textures.ColorDeepLime, "Deep Lime")
			{
				VAlign = 0.6f,
				HAlign = 0.667f
			};
			myImageButton19.OnClick += paintType;
			buttons.Add(myImageButton19);
			myUIPanel.Append(myImageButton19);
			MyImageButton myImageButton20 = new MyImageButton(Textures.ColorDeepOrange, "Deep Orange")
			{
				VAlign = 0.6f,
				HAlign = 0.834f
			};
			myImageButton20.OnClick += paintType;
			buttons.Add(myImageButton20);
			myUIPanel.Append(myImageButton20);
			MyImageButton myImageButton21 = new MyImageButton(Textures.ColorDeepPink, "Deep Pink")
			{
				VAlign = 0.6f,
				HAlign = 1f
			};
			myImageButton21.OnClick += paintType;
			buttons.Add(myImageButton21);
			myUIPanel.Append(myImageButton21);
			MyImageButton myImageButton22 = new MyImageButton(Textures.ColorDeepPurple, "Deep Purple")
			{
				VAlign = 0.85f,
				HAlign = 0.167f
			};
			myImageButton22.OnClick += paintType;
			buttons.Add(myImageButton22);
			myUIPanel.Append(myImageButton22);
			MyImageButton myImageButton23 = new MyImageButton(Textures.ColorDeepRed, "Deep Red")
			{
				VAlign = 0.85f,
				HAlign = 0.334f
			};
			myImageButton23.OnClick += paintType;
			buttons.Add(myImageButton23);
			myUIPanel.Append(myImageButton23);
			MyImageButton myImageButton24 = new MyImageButton(Textures.ColorDeepSkyBlue, "Deep Sky Blue")
			{
				VAlign = 0.85f,
				HAlign = 0.5f
			};
			myImageButton24.OnClick += paintType;
			buttons.Add(myImageButton24);
			myUIPanel.Append(myImageButton24);
			MyImageButton myImageButton25 = new MyImageButton(Textures.ColorDeepTeal, "Deep Teal")
			{
				VAlign = 0.85f,
				HAlign = 0.667f
			};
			myImageButton25.OnClick += paintType;
			buttons.Add(myImageButton25);
			myUIPanel.Append(myImageButton25);
			MyImageButton myImageButton26 = new MyImageButton(Textures.ColorDeepViolet, "Deep Violet")
			{
				VAlign = 0.85f,
				HAlign = 0.834f
			};
			myImageButton26.OnClick += paintType;
			buttons.Add(myImageButton26);
			myUIPanel.Append(myImageButton26);
			MyImageButton myImageButton27 = new MyImageButton(Textures.ColorDeepYellow, "Deep Yellow")
			{
				VAlign = 0.85f,
				HAlign = 1f
			};
			myImageButton27.OnClick += paintType;
			buttons.Add(myImageButton27);
			myUIPanel.Append(myImageButton27);
			MyImageButton myImageButton28 = new MyImageButton(Textures.ColorWhite, "White")
			{
				VAlign = 1.1f,
				HAlign = 0.167f
			};
			myImageButton28.OnClick += paintType;
			buttons.Add(myImageButton28);
			myUIPanel.Append(myImageButton28);
			MyImageButton myImageButton29 = new MyImageButton(Textures.ColorBlack, "Black")
			{
				VAlign = 1.1f,
				HAlign = 0.334f
			};
			myImageButton29.OnClick += paintType;
			buttons.Add(myImageButton29);
			myUIPanel.Append(myImageButton29);
			MyImageButton myImageButton30 = new MyImageButton(Textures.ColorBrown, "Brown")
			{
				VAlign = 1.1f,
				HAlign = 0.5f
			};
			myImageButton30.OnClick += paintType;
			buttons.Add(myImageButton30);
			myUIPanel.Append(myImageButton30);
			MyImageButton myImageButton31 = new MyImageButton(Textures.ColorGray, "Gray")
			{
				VAlign = 1.1f,
				HAlign = 0.667f
			};
			myImageButton31.OnClick += paintType;
			buttons.Add(myImageButton31);
			myUIPanel.Append(myImageButton31);
			MyImageButton myImageButton32 = new MyImageButton(Textures.ColorShadow, "Shadow")
			{
				VAlign = 1.1f,
				HAlign = 0.834f
			};
			myImageButton32.OnClick += paintType;
			buttons.Add(myImageButton32);
			myUIPanel.Append(myImageButton32);
			MyImageButton myImageButton33 = new MyImageButton(Textures.ColorNegative, "Negative")
			{
				VAlign = 1.1f,
				HAlign = 1f
			};
			myImageButton33.OnClick += paintType;
			buttons.Add(myImageButton33);
			myUIPanel.Append(myImageButton33);
			Append(myUIPanel);
		}

		public void paintType(UIMouseEvent evt, UIElement element)
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
			int uiPaintType;
			switch (myImageButton.hoverText)
			{
			case "Red":
				uiPaintType = 1;
				break;
			case "Orange":
				uiPaintType = 2;
				break;
			case "Yellow":
				uiPaintType = 3;
				break;
			case "Lime":
				uiPaintType = 4;
				break;
			case "Green":
				uiPaintType = 5;
				break;
			case "Teal":
				uiPaintType = 6;
				break;
			case "Cyan":
				uiPaintType = 7;
				break;
			case "Sky Blue":
				uiPaintType = 8;
				break;
			case "Blue":
				uiPaintType = 9;
				break;
			case "Purple":
				uiPaintType = 10;
				break;
			case "Violet":
				uiPaintType = 11;
				break;
			case "Pink":
				uiPaintType = 12;
				break;
			case "Deep Red":
				uiPaintType = 13;
				break;
			case "Deep Orange":
				uiPaintType = 14;
				break;
			case "Deep Yellow":
				uiPaintType = 15;
				break;
			case "Deep Lime":
				uiPaintType = 16;
				break;
			case "Deep Green":
				uiPaintType = 17;
				break;
			case "Deep Teal":
				uiPaintType = 18;
				break;
			case "Deep Cyan":
				uiPaintType = 19;
				break;
			case "Deep Sky Blue":
				uiPaintType = 20;
				break;
			case "Deep Blue":
				uiPaintType = 21;
				break;
			case "Deep Purple":
				uiPaintType = 22;
				break;
			case "Deep Violet":
				uiPaintType = 23;
				break;
			case "Deep Pink":
				uiPaintType = 24;
				break;
			case "Black":
				uiPaintType = 25;
				break;
			case "White":
				uiPaintType = 26;
				break;
			case "Gray":
				uiPaintType = 27;
				break;
			case "Brown":
				uiPaintType = 28;
				break;
			case "Shadow":
				uiPaintType = 29;
				break;
			case "Negative":
				uiPaintType = 30;
				break;
			default:
				uiPaintType = 100;
				break;
			}
			UILearning.LuiP.uiPaintType = uiPaintType;
		}

		public void paintMode(UIMouseEvent evt, UIElement element)
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
			int num;
			switch (myImageButton.hoverText)
			{
			case "Paint Tiles":
				num = 0;
				break;
			case "Paint Walls":
				num = 1;
				break;
			case "Remove Paint":
				num = 2;
				break;
			default:
				num = 100;
				break;
			}
			UILearning.LuiP.uiPaintMode ^= (PaintType)(byte)(1 << num);
		}
	}
}
