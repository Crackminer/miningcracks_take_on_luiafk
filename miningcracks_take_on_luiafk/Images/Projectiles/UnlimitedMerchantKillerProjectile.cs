using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Projectiles
{
	public class UnlimitedMerchantKillerProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Boiled Mothron Egg");
		}

		public override void SetDefaults()
		{
			base.Projectile.width = 38;
			base.Projectile.height = 42;
			base.Projectile.aiStyle = 2;
			base.Projectile.friendly = true;
			base.Projectile.DamageType = DamageClass.Throwing;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return target.townNPC;
		}
	}
}
