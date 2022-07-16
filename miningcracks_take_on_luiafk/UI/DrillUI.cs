using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace miningcracks_take_on_luiafk.UI
{
	internal static class DrillUI
	{
		internal static List<Vector3> multiDrillPositions = new List<Vector3>();

		internal static Drilling.DrillData mountData = new Drilling.DrillData();

		internal static LegacyGameInterfaceLayer Layer(Player p, LuiafkPlayer luiP)
		{
			return new LegacyGameInterfaceLayer("Luiafk: Mount", delegate
			{
				MountBeamDraw(Main.spriteBatch, luiP, p);
				return true;
			});
		}

		internal static void MountBeamDraw(SpriteBatch sb, LuiafkPlayer luiP, Player p)
		{
																					if (!luiP.noDrill && (luiP.goodMove || p.mount.Type == LuiafkMod.Instance.Find<ModMount>("DrillMountMount").Type) && Main.mouseLeft && !Main.gamePaused && !Main.ingameOptionsWindow && !p.mouseInterface && p.itemAnimation == 0 && p.itemTime == 0)
			{
				Drilling.DrawDrill(p);
			}
			if (Main.netMode == 1)
			{
				return;
			}
			foreach (Vector3 multiDrillPosition in multiDrillPositions)
			{
				Drilling.DrawLinesAndDustMulti(Main.player[(int)multiDrillPosition.Z], new Vector2(multiDrillPosition.X, multiDrillPosition.Y));
			}
			multiDrillPositions.Clear();
		}
	}
}
