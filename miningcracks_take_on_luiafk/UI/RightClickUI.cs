using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.UI.AutoBuilderUIs;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using Terraria;
using Terraria.GameInput;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal abstract class RightClickUI : UIState
	{
		internal bool holding;

		internal bool onMenu;

		internal Point position;

		internal const int Border = 10;

		internal const int Size = 32;

		internal int x;

		internal int y;

		internal float xf;

		internal float yf;

		internal RightClickUI(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		internal RightClickUI(float x, float y)
		{
			xf = x;
			yf = y;
		}

		internal void Reset()
		{
			holding = false;
		}

		internal static Dictionary<Type, RightClickUI> Create()
		{
			return new Dictionary<Type, RightClickUI>
			{
				{
					typeof(BuildingMaterialsUI),
					new BuildingMaterialsUI()
				},
				{
					typeof(skyUI),
					new skyUI()
				},
				{
					typeof(HoikRodUI),
					new HoikRodUI()
				},
				{
					typeof(PaintToolUI),
					new PaintToolUI()
				},
				{
					typeof(MultiSolutionUI),
					new MultiSolutionUI()
				},
				{
					typeof(UltimateBucketUI),
					new UltimateBucketUI()
				},
				{
					typeof(WiringUI),
					new WiringUI()
				},
				{
					typeof(HouseUI),
					new HouseUI()
				},
				{
					typeof(SubAndSkyUI),
					new SubAndSkyUI()
				},
				{
					typeof(PoolBuilderUI),
					new PoolBuilderUI()
				},
				{
					typeof(HellevatorUI),
					new HellevatorUI()
				},
				{
					typeof(FishingBiomeUI),
					new FishingBiomeUI()
				},
				{
					typeof(ArenaBuilderUI),
					new ArenaBuilderUI()
				},
				{
					typeof(ComboRodUI),
					new ComboRodUI()
				}
			};
		}

		internal abstract void resetValues();

		internal void RightClick()
		{
			Player player = Main.player[Main.myPlayer];
			if (holding)
			{
				if (player.mouseInterface || player.lastMouseInterface || player.dead || Main.mouseItem.type > 0 || player.itemTime > 0)
				{
					onMenu = false;
				}
				else if (Main.mouseRight && Main.mouseRightRelease && !PlayerInput.LockGamepadTileUseButton && player.noThrow == 0 && !Main.HoveringOverAnNPC && player.talkNPC == -1)
				{
					if (onMenu)
					{
						onMenu = false;
					}
					else if (!Main.SmartInteractShowingGenuine)
					{
						onMenu = true;
						position = (Main.MouseScreen * 16f).ToPoint();
					}
				}
			}
			else
			{
				onMenu = false;
			}
		}
	}
}
