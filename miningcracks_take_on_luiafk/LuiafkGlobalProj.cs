using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Images.Items.Fishing;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk
{
	public class LuiafkGlobalProj : GlobalProjectile
	{
		public override bool PreAI(Projectile projectile)
		{
			if (projectile.aiStyle == 61 && Main.player[projectile.owner].GetModPlayer<LuiafkPlayer>().holdingFishingRod)
			{
				Fishing.FishingBobber(projectile);
				return false;
			}
			return true;
		}

		public override bool PreDraw(Projectile projectile, ref Color lightColor)
		{
			if (projectile.aiStyle == 61 && Main.player[projectile.owner].GetModPlayer<LuiafkPlayer>().holdingFishingRod)
			{
				Fishing.ProjDrawing(projectile);
				return false;
			}
			return true;
		}

		public override bool PreDrawExtras(Projectile projectile)
		{
			if (projectile.aiStyle == 61)
			{
				return !Main.player[projectile.owner].GetModPlayer<LuiafkPlayer>().holdingFishingRod;
			}
			return true;
		}
	}
}
