using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.UI;
using miningcracks_take_on_luiafk.UI.OtherItemUIs;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Tools
{
	public class BuildingRod : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Hoiktuation Rod");
			base.Tooltip.SetDefault("Right-click to choose options.\nSelect block style and actuation state, reverse actuation takes priority over Active/Inactive.\nChoose a gap between blocks placed/actuated for easy hoik building.\nWill place the block in your bottom right inventory slot if used where there are no tiles.\nAny tiles already there, or placed from inventory will be changed according to chosen settings.\nClick and drag like the Grand Design.");
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
			if (player.whoAmI == Main.myPlayer)
			{
				UILearning.RightClickUIs<HoikRodUI>().holding = true;
				MiscMethods.ThisItemIcon(player, base.Item);
			}
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				base.Item.shoot = 0;
				if (UILearning.RightInterface?.CurrentState != null && UILearning.RightInterface?.CurrentState == UILearning.RightClickUIs<HoikRodUI>())
				{
					UILearning.RightInterface?.SetState(null);
				}
				else
				{
					UILearning.RightInterface?.SetState(UILearning.RightClickUIs<HoikRodUI>());
				}
				return false;
			}
			else
			{
				base.Item.shoot = base.Mod.Find<ModProjectile>("ActuatorProjectile").Type;
			}
			return true;
		}

		public override void AddRecipes()
		{
			CreateRecipe().AddIngredient(null, "ActuationRod").AddIngredient(217).AddIngredient(2325, 5)
				.AddRecipeGroup("Luiafk:PlatGoldBar", 10)
				.AddTile(16)
				.Register();
		}
	}
}
