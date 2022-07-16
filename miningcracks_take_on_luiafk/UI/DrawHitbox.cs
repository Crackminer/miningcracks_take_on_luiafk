using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal static class DrawHitbox
	{
		internal static LegacyGameInterfaceLayer Layer(LuiafkPlayer luiP)
		{
			return new LegacyGameInterfaceLayer("Luiafk: Hitbox", delegate
			{
				Update(Main.spriteBatch, luiP);
				return true;
			});
		}

		internal static void Update(SpriteBatch sb, LuiafkPlayer luiP)
		{
																																							if (luiP.uiDrawWeaponHitbox)
			{
				foreach (Rectangle item in LuiafkGlobalItem.useItem)
				{
					MiscMethods.DrawRectangleOutline(sb, item, new Color(255, 0, 0));
				}
				LuiafkGlobalItem.useItem.Clear();
			}
			if (luiP.uiDrawItemHitbox)
			{
				for (int i = 0; i < 400; i++)
				{
					if (Main.item[i].active)
					{
						MiscMethods.DrawRectangleOutline(sb, Main.item[i].Hitbox, new Color(255, 0, 0));
					}
				}
			}
			if (luiP.uiDrawProjHitbox)
			{
				for (int j = 0; j < 1000; j++)
				{
					if (Main.projectile[j].active)
					{
						MiscMethods.DrawRectangleOutline(sb, Main.projectile[j].Hitbox, new Color(255, 0, 0));
					}
				}
			}
			if (luiP.uiDrawNPCHitbox)
			{
				for (int k = 0; k < 200; k++)
				{
					if (Main.npc[k].active)
					{
						MiscMethods.DrawRectangleOutline(sb, Main.npc[k].Hitbox, new Color(255, 0, 0));
					}
				}
			}
			if (!luiP.uiDrawPlayerHitbox)
			{
				return;
			}
			for (int l = 0; l < 255; l++)
			{
				if (Main.player[l].active && !Main.player[l].dead)
				{
					MiscMethods.DrawRectangleOutline(sb, Main.player[l].Hitbox, new Color(255, 0, 0));
				}
			}
		}
	}
}
