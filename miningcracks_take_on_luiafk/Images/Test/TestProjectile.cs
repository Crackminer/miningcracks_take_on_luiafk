using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Test
{
	public class TestProjectile : ModProjectile
	{
		private const float radius = 175f;

		private const int numPoints = 1400;

		private const float theta = (float)Math.PI / 700f;

		private readonly float tan = (float)Math.Tan(0.004487989630017962);

		private readonly float cos = (float)Math.Cos(0.004487989630017962);

		public bool CanHit(Vector2 targetPosition)
		{
									return Collision.CanHitLine(base.Projectile.Center, 0, 0, targetPosition, 0, 0);
		}

		public void DrawPoint(Vector2 targetPos)
		{
																								Main.spriteBatch.Draw(TextureAssets.MagicPixel.Value, targetPos - Main.screenPosition, (Rectangle?)new Rectangle(0, 0, 1, 1), CanHit(targetPos) ? Color.Blue : Color.Red);
		}

		public override bool PreDraw(ref Color lightColor)
		{
																																				Vector2 center = base.Projectile.Center;
			float num = 175f;
			float num2 = 0f;
			Vector2 targetPos = default(Vector2);
			targetPos = new(num, num2);
			DrawPoint(center);
			DrawPoint(targetPos);
			targetPos = new(num + center.X, num2 + center.Y);
			DrawPoint(targetPos);
			for (int i = 0; i < 1400; i++)
			{
				float num3 = 0f - num2;
				float num4 = num;
				num += num3 * tan;
				num2 += num4 * tan;
				num *= cos;
				num2 *= cos;
				targetPos = new(num + center.X, num2 + center.Y);
				DrawPoint(targetPos);
			}
			return false;
		}

		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("TestProjectile");
		}

		public override void SetDefaults()
		{
			base.Projectile.alpha = 0;
			base.Projectile.aiStyle = -1;
			base.Projectile.timeLeft = 1000;
		}

		public override bool PreAI()
		{
			return true;
		}

		public override void AI()
		{
		}

		public override void PostAI()
		{
		}
	}
}
