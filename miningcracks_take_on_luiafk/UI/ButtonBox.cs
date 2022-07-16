using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal abstract class ButtonBox : UIElement
	{
		private static readonly string[] wandText = new string[15]
		{
			"Grass", "Corrupt Grass", "Crimson Grass", "Hallow Grass", "Mushroom Grass", "Jungle Grass", "Wood Wand", "Leaf Wand", "Wand/Regrowth Off", "Green Moss",
			"Brown Moss", "Red Moss", "Blue Moss", "Purple Moss", "Lava Moss"
		};

		private static readonly string[] wireText = new string[6] { "Red", "Green", "Blue", "Yellow", "Actuator", "Cutter" };

		private static readonly string[] buildingText = new string[9] { "Stone Slab", "Gray Brick", "Wood", "Pearlwood", "Boreal Wood", "Palm Wood", "Ebonwood", "Shadewood", "Rich Mahogany" };

		private static readonly int[] buildingTileType = new int[9] { 273, 38, 30, 159, 321, 322, 157, 208, 158 };

		private static readonly int[] buildingWallType = new int[9] { 147, 5, 4, 43, 149, 151, 41, 85, 42 };

		private static readonly int[] platformStyle = new int[7] { 0, 3, 19, 17, 1, 5, 2 };

		private static readonly string[] paintColors = new string[31]
		{
			"", "Red", "Orange", "Yellow", "Lime", "Green", "Teal", "Cyan", "Sky Blue", "Blue",
			"Purple", "Violet", "Pink", "Deep Red", "Deep Orange", "Deep Yellow", "Deep Lime", "Deep Green", "Deep Teal", "Deep Cyan",
			"Deep Sky Blue", "Deep Blue", "Deep Purple", "Deep Violet", "Deep Pink", "Black", "White", "Gray", "Brown", "Shadow",
			"Negative"
		};

		private static readonly string[] paintModes = new string[3] { "Paint Tiles", "Paint Walls", "Remove Paint" };

		private static readonly string[] solutionTypeText = new string[9] { "Green Solution", "Purple Solution", "Red Solution", "Dark Blue Solution", "Blue Solution", "Dark Green Solution", "Snow/Ice Solution\nNot used with Clentaminator", "Hell Solution\nNot used with Clentaminator", "Cloud Solution\nNot used with Clentaminator" };

		private static readonly string[] hoikRodText = new string[9] { "Full Block", "Half Block", "Up and Right", "Up and Left", "Down and Right", "Down and Left", "Active/Inactive", "Reverse Actuation\nOverrides Active/Inactive", "Gap Between Blocks" };

		private static readonly string[] potionsText = new string[9] { "Ultimate Battler\nOverrides Ultimate Peaceful", "Ultimate Peaceful", "Gravity Control", "Featherfall", "Inferno Visual", "Invisibility", "Crate Potion", "Spelunker", "Danger and Hunter" };

		private static readonly string[] biomeCreatorText = new string[9] { "Crimson", "Corruption", "Ice", "Jungle", "Mushroom", "Hallow", "Crimson Ice", "Corruption Ice", "Hallow Ice" };

		private static readonly int[] biomeCreatorType = new int[9] { 203, 25, 161, 59, 59, 117, 200, 163, 164 };

		private static readonly string[] poolBuilderText = new string[5] { "Multi-purpose Sponge", "Water Bucket", "Lava Bucket", "Honey Bucket", "Fishing Pool Builder" };

		protected const string ArenaText = "Place Campfires and Bubbles";

		protected List<Button> buttons = new List<Button>();

		protected Background bg;

		protected Point position = new Point(Main.screenWidth / 2, Main.screenHeight / 11);

		protected virtual int Size { get; } = 32;


		protected virtual int Border { get; } = 10;


		protected static LuiafkPlayer LuiP { get; private set; }

		protected static string WandText(int i)
		{
			return wandText[i];
		}

		protected static string WireText(int i)
		{
			return wireText[i];
		}

		protected static string BuildingText(int i)
		{
			return buildingText[i];
		}

		internal static int BuildingTileType(int i)
		{
			return buildingTileType[i];
		}

		internal static int BuildingWallType(int i)
		{
			return buildingWallType[i];
		}

		internal static int PlatformStyle(int i)
		{
			return platformStyle[i];
		}

		protected static string PaintColors(int i)
		{
			return paintColors[i];
		}

		protected static string PaintModes(int i)
		{
			return paintModes[i];
		}

		protected static string SolutionTypeText(int i)
		{
			return solutionTypeText[i];
		}

		protected static string HoikRodText(int i)
		{
			return hoikRodText[i];
		}

		protected static string PotionsText(int i)
		{
			return potionsText[i];
		}

		protected static string BiomeCreatorText(int i)
		{
			return biomeCreatorText[i];
		}

		internal static int BiomeCreatorType(int i)
		{
			return biomeCreatorType[i];
		}

		internal static string PoolBuilderText(int i)
		{
			return poolBuilderText[i];
		}

		internal static void OnEnterWorld()
		{
			LuiP = Main.player[Main.myPlayer].GetModPlayer<LuiafkPlayer>();
			UILearning.BuffUI.position = LuiP.uiBuffPosition;
		}

		internal ButtonBox(int x, int y)
		{
			bg = new Background(new Vector2((float)x, (float)y));
		}

		internal ButtonBox(float x, float y)
		{
			bg = new Background(new Vector2(x, y));
		}

		internal void DoStuff(SpriteBatch sb)
		{
			Draw(sb);
			Update();
		}

		public override void Draw(SpriteBatch sb)
		{
			bg.Draw(sb, new Vector2((float)position.X, (float)position.Y));
			foreach (Button button in buttons)
			{
				button.Draw(sb, position.X, position.Y);
			}
		}

		protected virtual void Update()
		{
			using (List<Button>.Enumerator enumerator = buttons.GetEnumerator())
			{
				while (enumerator.MoveNext() && !enumerator.Current.Update(position.X, position.Y))
				{
				}
			}
		}
	}
}
