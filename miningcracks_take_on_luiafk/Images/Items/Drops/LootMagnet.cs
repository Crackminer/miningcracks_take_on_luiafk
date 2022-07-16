using Microsoft.Xna.Framework;
using miningcracks_take_on_luiafk.Utility;
using Terraria;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Drops
{
	public class LootMagnet : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Loot Magnet");
			base.Tooltip.SetDefault("Loots everything.");
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.holdStyle = 2;
		}

		public override void HoldItem(Player player)
		{
																																										for (int i = 0; i < 400; i++)
			{
				Item item = Main.item[i];
				if (item.active && item.noGrabDelay == 0 && ItemLoader.CanPickup(item, player))
				{
					item.beingGrabbed = true;
					Vector2 val = player.Center - item.Center;
					Vector2 val2 = item.velocity * 4f;
					Vector2 val3 = val;
					item.velocity = (val2 + val * (20f / ((Vector2)(val3)).Length())) * 0.2f;
				}
			}
		}
	}
}
