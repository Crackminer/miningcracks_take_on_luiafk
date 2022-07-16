using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class ActuationRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Improved Actuation Rod");
			base.Tooltip.SetDefault("Reverses actuation state of blocks.\nWorks without an actuator on the tile.\nClick and drag like the Grand Design.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
			base.Item.channel = true;
			base.Item.shoot = base.Mod.Find<ModProjectile>("ActuatorProjectile").Type;
			base.Item.shootSpeed = 10f;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (Main.netMode != 2)
			{
				int num = player.mount.PlayerOffsetHitbox - 5;
				player.itemLocation.X = player.position.X + (float)player.width * 0.5f + (float)TextureAssets.Item[base.Item.type].Value.Width * 0.18f * (float)player.direction + (float)(10 * -player.direction);
				player.itemLocation.Y = player.position.Y + 24f + (float)num;
			}
		}

		public override void HoldItem(Player player)
		{
			MiscMethods.ThisItemIcon(player, base.Item);
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(3620).AddIngredient(849, 100).AddIngredient(538, 10)
				.AddRecipeGroup("Luiafk:PressurePlate", 5)
				.AddTile(16)
				.Register();
		}
	}
}
