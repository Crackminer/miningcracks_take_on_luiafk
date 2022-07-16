using miningcracks_take_on_luiafk.Utility;
using Terraria.ModLoader;

namespace miningcracks_take_on_luiafk.Images.Items.Drops
{
	public class MagicEssence : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.DisplayName.SetDefault("Magic Essence");
			base.Tooltip.SetDefault("Imbued with magical power.\nSmells a little like cheese.");
			base.SacrificeTotal = 15;
		}

		public override void SetDefaults()
		{
			Defaults.Base(base.Item);
			base.Item.maxStack = 9999;
		}
	}
}
