using Terraria.ID;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Thrown
{
	public class UnlimitedMerchantKiller : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Unlimited Merchant Killer");
			base.Tooltip.SetDefault("'Cause they never asked if they could move in.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 1;
			base.Item.shootSpeed = 9f;
			base.Item.shoot = base.Mod.Find<ModProjectile>("UnlimitedMerchantKillerProjectile").Type;
			base.Item.knockBack = 6.5f;
			base.Item.damage = 10000;
			base.Item.width = 38;
			base.Item.height = 42;
			base.Item.maxStack = 1;
			base.Item.consumable = false;
			base.Item.UseSound = SoundID.Item1;
			base.Item.useAnimation = 15;
			base.Item.useTime = 15;
			base.Item.noUseGraphic = true;
			base.Item.noMelee = true;
			base.Item.value = 1;
			base.Item.DamageType = DamageClass.Throwing;
			base.Item.rare = 10;
		}
	}
}
