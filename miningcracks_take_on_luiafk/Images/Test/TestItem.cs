using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Test
{
	public class TestItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Test Item");
			base.Tooltip.SetDefault("Item for testing stuff.\nMay do nothing.\nMay do cool stuff.\nMay break your game.\nMay break your computer.\nI wouldn't use this if I were you.");
		}

		public override void SetDefaults()
		{
			Defaults.UnlUse(base.Item);
		}

		public override void UpdateInventory(Player player)
		{
		}

		public override void HoldItem(Player player)
		{
		}

		public override bool CanUseItem(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo ammo, Vector2 position, Vector2 velocity, int type, int damage, float knockBack)
		{
			return true;
		}

		public override bool? UseItem(Player player)
		{
			return true;
		}
	}
}
