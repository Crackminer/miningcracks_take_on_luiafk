using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.MobileBanks
{
	public class MobileMerchant : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Fairy Merchant");
			base.Tooltip.SetDefault("Summons a Fairy that will buy and sell goods.");
			Main.RegisterItemAnimation(base.Item.type, new DrawAnimationVertical(7, 16));
			base.SacrificeTotal = 1;
		}

		public override void SetDefaults()
		{
			base.Item.useStyle = 4;
			base.Item.useAnimation = 20;
			base.Item.useTime = 20;
			base.Item.width = 54;
			base.Item.height = 34;
			base.Item.noUseGraphic = true;
			base.Item.autoReuse = false;
			base.Item.rare = 10;
			base.Item.value = 200000;
		}

		public override bool? UseItem(Player player)
		{
									LuiafkPlayer modPlayer = player.GetModPlayer<LuiafkPlayer>();
			if (Main.netMode != 1)
			{
				modPlayer.mobileMerchantDelete = NPC.NewNPC(null, (int)player.Center.X, (int)player.Center.Y - 48, base.Mod.Find<ModNPC>("MobileMerchant").Type, 0, 0f, 0f, player.whoAmI);
			}
			return true;
		}
	}
}
