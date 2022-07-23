using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class AllInOneChest : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Mobile All-in-One Chest and Merchant");
			base.Tooltip.SetDefault("Summons a floating Piggy Bank, Safe, Void Vault, and Defender's Forge.\nSummons a Fairy that will buy and sell goods.\nSmart cursor disabled while using banks.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Clone(base.Item, 3213);
			base.Item.shoot = base.Mod.Find<ModProjectile>("SafeProjectile").Type;
		}

		public override bool? UseItem(Player player)
		{
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (Main.netMode == 2)
			{
				modPlayer.mobileMerchantDelete = NPC.NewNPC(null, (int)player.Center.X, (int)player.Center.Y - 48, base.Mod.Find<ModNPC>("MobileMerchant").Type, 0, 0f, 0f, player.whoAmI);
			}
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo s, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			Projectile.NewProjectile(null, player.Center.X, player.Center.Y + 48f, 0f, 0f, base.Mod.Find<ModProjectile>("DefendersForgeProjectile").Type, 0, 0f, player.whoAmI);
			Projectile.NewProjectile(null, player.Center.X - 48f, player.Center.Y, 0f, 0f, base.Mod.Find<ModProjectile>("PiggyBankProjectile").Type, 0, 0f, player.whoAmI);
			Projectile.NewProjectile(null, player.Center.X + 48f, player.Center.Y, 0f, 0f, base.Mod.Find<ModProjectile>("SafeProjectile").Type, 0, 0f, player.whoAmI);
			Projectile.NewProjectile(null, player.Center, Vector2.Zero, 734, 0, 0f, player.whoAmI);
			LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (Main.netMode == 0)
			{
				modPlayer.mobileMerchantDelete = NPC.NewNPC(null, (int)player.Center.X, (int)player.Center.Y - 48, base.Mod.Find<ModNPC>("MobileMerchant").Type, 0, 0f, 0f, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "DefendersForge").AddIngredient(null, "PiggySafe").AddIngredient(4131, 1).AddTile(18)
				.Register();
		}
	}
}
