using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Mounts
{
	public class DrillMountMount : ModMount
	{
		public override void SetStaticDefaults()
		{
									base.MountData.buff = base.Mod.Find<ModBuff>("DrillMountBuff").Type;
			base.MountData.totalFrames = 1;
			base.MountData.spawnDust = 257;
			base.MountData.spawnDustNoGravity = true;
			base.MountData.emitsLight = true;
			base.MountData.lightColor = new Vector3(1.3f, 1.3f, 1.3f);
			int[] array = new int[base.MountData.totalFrames];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = 0;
			}
			base.MountData.playerYOffsets = array;
			base.MountData.xOffset = 0;
			base.MountData.bodyFrame = 0;
			base.MountData.yOffset = 24;
			base.MountData.playerHeadOffset = 0;
			base.MountData.standingFrameCount = 1;
			base.MountData.standingFrameDelay = 0;
			base.MountData.standingFrameStart = 0;
			base.MountData.runningFrameCount = 0;
			base.MountData.runningFrameDelay = 0;
			base.MountData.runningFrameStart = 0;
			base.MountData.flyingFrameCount = 0;
			base.MountData.flyingFrameDelay = 0;
			base.MountData.flyingFrameStart = 0;
			base.MountData.inAirFrameCount = 0;
			base.MountData.inAirFrameDelay = 0;
			base.MountData.inAirFrameStart = 0;
			base.MountData.idleFrameCount = 0;
			base.MountData.idleFrameDelay = 0;
			base.MountData.idleFrameStart = 0;
			base.MountData.idleFrameLoop = true;
			base.MountData.swimFrameCount = base.MountData.inAirFrameCount;
			base.MountData.swimFrameDelay = base.MountData.inAirFrameDelay;
			base.MountData.swimFrameStart = base.MountData.inAirFrameStart;
			if (Main.netMode != 2)
			{
				base.MountData.textureWidth = base.MountData.backTexture.Width();
				base.MountData.textureHeight = base.MountData.backTexture.Height();
			}
		}

		public override bool UpdateFrame(Player player, int state, Vector2 velocity)
		{
			player.mount._frame = 0;
			player.mount._flipDraw = ((player.direction == 1) ? true : false);
			return false;
		}
	}
}
